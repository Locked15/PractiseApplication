using Microsoft.Win32;
using PractiseApplication.Controllers;
using PractiseApplication.Controllers.Standalone;
using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using PractiseApplication.Views.Controls;
using PractiseApplication.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PractiseApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        #region Fields.

        private DispatcherTimer? _requestsNewsService;

        private HomeWindowController _controller;

        private HomeWindowModel _model;
        #endregion

        #region Properties.

        public List<Request> SelectedRequests { get; private set; }
        #endregion

        #region Functions.

        #region Initializing Functions.

        public HomeWindow(User user)
        {
            InitializeComponent();
            _controller = DataContext as HomeWindowController ?? new();
            _model = (DataContext as HomeWindowController)?.Model ?? new HomeWindowModel();

            _model.User = user;
        }

        private void PerformActionsOnWindowLoaded(object sender, RoutedEventArgs e)
        {
            _controller.UpdateRequests();
            InitializeRequestNewsService();
            InitializeToolboxItemsVisibility();

            searchBox.TextChanged += OnRequestSelectionCriteriaChange;
            sortBox.SelectionChanged += OnRequestSelectionCriteriaChange;

            showOnlyTargeted.Checked += OnRequestSelectionCriteriaChange;
            showOnlyTargeted.Unchecked += OnRequestSelectionCriteriaChange;
            showOnlyTargeted.IsEnabled = _model.User.RoleId > 2 ? true : false;
            showOnlyTargeted.ToolTip = showOnlyTargeted.IsEnabled ? "Позволяет отобразить ещё нераспределенные заявки." :
                                                                    "Вы можете просматривать только Ваши заявки.";

            showOnlyActive.Checked += OnRequestSelectionCriteriaChange;
            showOnlyActive.Unchecked += OnRequestSelectionCriteriaChange;

            var states = new List<RequestStatus>()
            {
                new RequestStatus()
                {
                    Id = 0,
                    Status = "Все Типы"
                }
            };
            states.AddRange(BaseContext.Instance.RequestStatuses.ToList());
            stateBox.ItemsSource = states;
            stateBox.SelectionChanged += OnRequestSelectionCriteriaChange;

            stateBox.SelectedIndex = 0;
        }

        private void InitializeRequestNewsService()
        {
            _requestsNewsService = new DispatcherTimer(TimeSpan.FromSeconds(120),
                                                       DispatcherPriority.Background,
                                                       (sender, e) =>
                                                           {
                                                               if (_model.Requests.Count != _controller.GetAvailableRequests().Count)
                                                               {
                                                                   var newestRequest = _controller.GetAvailableRequests().Last();
                                                                   newsLine.Text = $"Появилась новая заявка:\n{newestRequest?.Location?.Bind_ComplexValue ?? "Неизвестно"}.";
                                                               }
                                                           },
                                                       Dispatcher.CurrentDispatcher);
            _requestsNewsService.Start();
        }

        private void InitializeToolboxItemsVisibility()
        {
            if (_model.User.RoleId < 2)
                adminToolsPanel.Visibility = Visibility.Hidden;
        }

        public void UpdateRequestsList() => 
               OnRequestSelectionCriteriaChange(default, default);
        #endregion

        #region Request List Filling Functions.

        private void OnRequestSelectionCriteriaChange(object sender, dynamic e)
        {
            SelectedRequests = _controller.GetAvailableRequests();
            SelectRequestsByTargetAndCompletion();
            SelectRequestsBySearch();
            SelectRequestsByFilter();
            SortRequestsBySelectedProperty();

            UpdateRequestsListElement();
        }

        private void SelectRequestsByTargetAndCompletion()
        {
            // If current user — 'Master', he can get not only targeted requests, but also not-targeted.
            if (_model.ShowOnlyTargetedRequests)
            {
                SelectedRequests = SelectedRequests.Where(r => r.RequesterId == _model.User.Id ||
                                                               r.ExecutionerId == _model.User.Id
                                                         ).ToList();
            }

            // 'Решенный' status have id = 5.
            if (_model.ShowOnlyActiveRequests)
            {
                SelectedRequests = SelectedRequests.Where(r => r.RequestStatusId != 5).ToList();
            }
        }

        private void SelectRequestsBySearch()
        {
            if (searchBox.Text.ToLower() is var search && !string.IsNullOrWhiteSpace(search))
            {
                SelectedRequests = SelectedRequests.Where(req => req.Title.ToLower().Contains(search) ||
                                                                 req.RequestType.Type.ToLower().Contains(search) ||
                                                                 req.RequestStatus.Status.ToLower().Contains(search)
                                                         ).ToList();
            }
        }

        private void SelectRequestsByFilter()
        {
            if (_model.StatusFilter.Id != 0)
            {
                SelectedRequests = SelectedRequests.Where(req => req.RequestStatus == _model.StatusFilter)
                                                   .ToList();
            }
        }

        private void SortRequestsBySelectedProperty()
        {
            switch (_model.SortIndex)
            {
                // Ascending:
                case 2:
                    SelectedRequests = SelectedRequests.OrderBy(req => req.RequestCompletionTime).ToList();
                    break;
                case 3:
                    SelectedRequests = SelectedRequests.OrderBy(req => req.RequestChats.Count).ToList();
                    break;
                case 4:
                    SelectedRequests = SelectedRequests.OrderBy(req => req.RequestTypeId).ToList();
                    break;

                // Descending:
                case 6:
                    SelectedRequests = SelectedRequests.OrderByDescending(req => req.RequestCompletionTime).ToList();
                    break;
                case 7:
                    SelectedRequests = SelectedRequests.OrderByDescending(req => req.RequestChats.Count).ToList();
                    break;
                case 8:
                    SelectedRequests = SelectedRequests.OrderByDescending(req => req.RequestTypeId).ToList();
                    break;
            }
        }

        private void UpdateRequestsListElement()
        {
            selectedRequestsList.Items.Clear();

            foreach (var request in SelectedRequests)
            {
                RequestElement element = new(request);
                OptimizeSizes(element);

                selectedRequestsList.Items.Add(element);
            }
        }
        #endregion

        #region Request Detail Setting Functions.

        private void OpenRequestDetailsOnDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selectedRequestsList.SelectedItem is var selected && selected is RequestElement element)
            {
                var request = element.Model;

                RequestSetting settingWindow = new(request, _model.User, this);
                settingWindow.Show();
            }
        }
        #endregion

        #region Exiting Functions.

        private void ConfirmUserExitingFromAccount(object sender, RoutedEventArgs e)
        {
            var sure = MessageBox.Show("Вы точно уверены, что хотите выйти?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (sure == MessageBoxResult.Yes)
            {
                EntryPoint backward = new();
                backward.Show();

                Close();
            }
        }

        private void StopNewsServiceOnClose(object sender, System.ComponentModel.CancelEventArgs e) =>
                _requestsNewsService?.Stop();
        #endregion

        #region Toolbox Functions.

        private void CreateNewUserAccountOnClick(object sender, RoutedEventArgs e) =>
                MessageBox.Show("⚒️ В разработке. ⚒️", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

        private void CreateNewLocationOnClick(object sender, RoutedEventArgs e)
        {
            LocationCreation dialog = new();
            dialog.ShowDialog();
        }

        private void RefreshRequestsListOnClick(object sender, RoutedEventArgs e) =>
                UpdateRequestsList();

        private void GenerateDocumentationOnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new()
            {
                Title = "Выбор Пути — HelpTable",
                Filter = "Документы Word (*.docx)|*.docx|Все файлы (*.*)|*.*",
                AddExtension = true
            };
            var result = dialog.ShowDialog();

            if (result.HasValue && result.Value)
            {
                try
                {
                    ReportController controller = new(dialog.FileName, _model.User);
                    controller.BeginDocumentCreation();

                    MessageBox.Show($"Документ успешно создан.\n\nПуть: {dialog.FileName}.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось создать отчёт.\n\nОшибка: {ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void OpenRequestCreationDialogOnClick(object sender, RoutedEventArgs e)
        {
            RequestGeneration dialog = new(_model.User);
            var result = dialog.ShowDialog();
            if (result.HasValue && result.Value)
                UpdateRequestsList();
        }
        #endregion

        #region Resize Functions.

        private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            foreach (UserControl control in selectedRequestsList.Items)
            {
                OptimizeSizes(control);
            }
        }

        private void OptimizeSizes(UserControl control)
        {
            control.Width = selectedRequestsList.RenderSize.Width - 17.5;
        }
        #endregion
        #endregion
    }
}
