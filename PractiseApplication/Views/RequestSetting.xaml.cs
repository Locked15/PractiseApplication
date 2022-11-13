using PractiseApplication.Controllers;
using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using PractiseApplication.Views.Controls;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PractiseApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestSetting.xaml
    /// </summary>
    public partial class RequestSetting : Window
    {
        #region Fields.

        private RequestSettingController _controller;

        private RequestSettingModel _model;

        private User _user;
        #endregion

        #region Properties.

        public HomeWindow? Home { get; private set; }

        public (int? statusId, int? executionerId) BasicData { get; private set; }
        #endregion

        #region Functions.

        #region Initialization Functions.

        public RequestSetting(Request request, User currentUser, HomeWindow? home = null)
        {
            _controller = new RequestSettingController(request, request.RequestChats.ToList());
            _model = _controller.Model;
            BasicData = (_model.Request.RequestStatusId, _model.Request.ExecutionerId);
            _user = currentUser;

            Home = home;

            InitializeComponent();
            DataContext = _controller;
        }

        private void PerformActionAfterWindowIsLoaded(object sender, RoutedEventArgs e)
        {
            Title = string.Format(Title, _model.Request.Title);
            newStatusSelector.ItemsSource = BaseContext.Instance.RequestStatuses
                                                       .Where(s => s != _model.Request.RequestStatus)
                                                       .ToList();

            UpdateChatWithMessages();
            UpdateElementsAvailabilityByUserRole();
        }

        private void UpdateChatWithMessages()
        {
            _controller.UpdateMessages();

            chatMessages.Items.Clear();
            foreach (var message in _model.Messages.Reverse<RequestChat>())
            {
                var messageElement = new RequestChatMessage(message);
                OptimizeSizes(messageElement);

                chatMessages.Items.Add(messageElement);
            }
        }

        private void UpdateElementsAvailabilityByUserRole()
        {
            if (_user.RoleId < 2)
            {
                sentMessageAndChangeStatus.IsEnabled = false;
                newStatusSelector.IsEnabled = false;

                globalStatusSelector.IsEnabled = false;
            }

            if (_user.RoleId < 3)
            {
                executionerSelector.IsEnabled = false;
            }
        }
        #endregion

        #region Message Sending Functions.

        private void SendMessageOnClick(object sender, RoutedEventArgs e)
        {
            if (newMessageText.Text is var text && !string.IsNullOrWhiteSpace(text))
            {
                WriteMessageToDbContext(sender, text, true);
            }
            else
            {
                MessageBox.Show("Нельзя отправлять пустое сообщение.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void WriteMessageToDbContext(object sender, string text, bool clearTextBox = false)
        {
            if (sender is bool addStatusNotaBene && addStatusNotaBene)
            {
                var oldStatus = _controller.GetStatusById(BasicData.statusId);
                var newStatus = _model.Request.RequestStatus;

                text += $"\n\n{_user.Bind_UserName} изменил статус:\n{oldStatus?.Status} -> {newStatus?.Status}.";
            }
            RequestChat chat = new()
            {
                Request = _model.Request,
                RequestId = _model.Request.Id,
                Author = _user,
                AuthorId = _user.Id,
                Message = text,
                SentDate = DateTime.Now
            };

            BaseContext.Instance.RequestChats.Add(chat);
            BaseContext.Instance.SaveChanges();

            UpdateChatWithMessages();
            if (clearTextBox)
                newMessageText.Text = string.Empty;
        }

        private void SendMessageAndUpdateStatusOnClick(object sender, RoutedEventArgs e)
        {
            SetModelStatusBySelected();
            if (newMessageText.Text is var text && !string.IsNullOrWhiteSpace(text))
                SendMessageOnClick(true, default);

            BeginRequestSavingOnClick(false, default);
            CloseWindowAndHandleHomeUpdate();
        }
        #endregion

        #region Request Updating Functions.

        private void ShowSaveButtonOnGlobalSelectorsChange(object sender, SelectionChangedEventArgs e)
        {
            if (_model.Request?.Executioner?.Id != BasicData.executionerId || _model.Request?.RequestStatus?.Id != BasicData.statusId)
                saveChanges.Visibility = Visibility.Visible;
            else
                saveChanges.Visibility = Visibility.Hidden;
        }

        private void BeginRequestSavingOnClick(object sender, RoutedEventArgs e)
        {
            NormalizeGeneratingObject();
            SaveObjectToDbContext();

            saveChanges.Visibility = Visibility.Hidden;
        }

        private void NormalizeGeneratingObject()
        {
            if (_model.Request?.RequestStatus?.Id != BasicData.statusId)
            {
                WriteMessageToDbContext(false, $"{_user.Bind_UserName} изменил статус:\n" +
                                               $"{_controller.GetStatusById(BasicData.statusId)?.Status} -> {_model.Request?.RequestStatus?.Status}.");
            }
            if (_model.Request?.RequestStatus?.Id == 5)
            {
                _model.Request.EndDate = DateTime.Now;
            }

            _model.Request.ExecutionerId = _model.Request?.Executioner?.Id ?? null;
            _model.Request.RequestStatusId = _model.Request?.RequestStatus?.Id ?? null;
            BasicData = (_model.Request.RequestStatusId, _model.Request.ExecutionerId);
        }

        private void SetModelStatusBySelected()
        {
            _model.Request.RequestStatus = newStatusSelector.SelectedItem as RequestStatus;
            _model.Request.RequestStatusId = _model.Request.RequestStatus?.Id ?? 1;
        }

        private void SaveObjectToDbContext()
        {
            try
            {
                BaseContext.Instance.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении изменений: {ex.Message}.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region Resizing Functions.

        private void UpdateElementsOnSizeChange(object sender, SizeChangedEventArgs e)
        {
            foreach (UserControl control in chatMessages.Items)
            {
                OptimizeSizes(control);
            }
        }

        private void OptimizeSizes(UserControl control) =>
                control.Width = chatMessages.RenderSize.Width - 20;
        #endregion

        #region Exiting Functions.

        private void ConfirmWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы точно уверены?\n\nНесохраненные изменения будут потеряны!", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                // To prevent some bugs (like: "when we updates context, it stores updated object"), reset values to last saved.
                _model.Request.ExecutionerId = BasicData.executionerId;
                _model.Request.Executioner = BaseContext.Instance.Users.FirstOrDefault(u => u.Id == BasicData.executionerId);

                _model.Request.RequestStatusId = BasicData.statusId;
                _model.Request.RequestStatus = _controller.GetStatusById(BasicData.statusId);

                Home?.UpdateRequestsList();
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }

        private void CloseWindowAndHandleHomeUpdate()
        {
            Home?.UpdateRequestsList();
            Closing -= ConfirmWindowClosing;

            Close();
        }
        #endregion
        #endregion
    }
}
