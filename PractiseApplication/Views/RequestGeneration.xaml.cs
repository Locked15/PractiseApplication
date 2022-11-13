using PractiseApplication.Controllers;
using PractiseApplication.Controllers.Standalone;
using PractiseApplication.Models.Entities;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PractiseApplication.Views
{
    /// <summary>
    /// Логика взаимодействия для RequestGeneration.xaml
    /// </summary>
    public partial class RequestGeneration : Window
    {
        #region Fields.

        private User _user;

        private Request _model;
        #endregion

        #region Constructors.

        public RequestGeneration(User creator)
        {
            _user = creator;

            InitializeComponent();
            _model = (DataContext as RequestGenerationController)?.Model ?? new Request();
        }
        #endregion

        #region Events.

        private void FillSelectorsOnWindowLoaded(object sender, RoutedEventArgs e)
        {
            locationSelector.ItemsSource = BaseContext.Instance.Locations.ToList();
            typeSelector.ItemsSource = BaseContext.Instance.RequestTypes.ToList();
        }

        private void ConfirmUserExiting(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы точно хотите выйти?\n\nСохраненные изменения не сохранятся.", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }

        private void UpdateRequestTypeToolTipOnSelectionChange(object sender, SelectionChangedEventArgs e) =>
                typeSelector.ToolTip = _model.RequestType?.Description;

        private void DenyRequestCreation(object sender, RoutedEventArgs e) =>
                Close();

        private void TryToGenerateNewRequest(object sender, RoutedEventArgs e)
        {
            if (ValidateGeneratingObject())
            {
                Closing -= ConfirmUserExiting;

                NormalizeRequestObject();
                RequestController.GenerateNewRequestInContext(_model, true);
                GenerateSideObjectIfNeeded();

                TryToDefineDialogResult();
                Close();
            }
        }
        #endregion

        #region Functions.

        private bool ValidateGeneratingObject()
        {
            var errors = GetErrors();
            if (string.IsNullOrEmpty(errors))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"Обнаружены ошибки:\n{errors}.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                return false;
            }
        }

        private string GetErrors()
        {
            var errors = string.Empty;
            if (string.IsNullOrWhiteSpace(_model.Title))
                errors += "У запроса должен быть заголовок.\n";
            if (_model.Location == null)
                errors += "У запроса должна быть указана локация.\n";
            if (_model.RequestType == null)
                errors += "У запроса должен быть указан тип.\n";

            return errors;
        }

        private void NormalizeRequestObject()
        {
            _model.Requester = _user;
            _model.RequesterId = _user.Id;

            _model.RequestTypeId = _model.RequestType?.Id;
            _model.LocationId = _model.Location?.Id;
        }

        private void GenerateSideObjectIfNeeded()
        {
            if (!string.IsNullOrWhiteSpace(optionalMessageInput.Text))
            {
                RequestController.GenerateMessageToRequestInContext(optionalMessageInput.Text, _user, _model, false);
            }
        }

        private bool TryToDefineDialogResult()
        {
            // If we try to define "DialogResult", and current Window isn't one, we'll get an exception.
            try
            {
                DialogResult = true;
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }
        #endregion
    }
}
