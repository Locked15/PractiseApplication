using PractiseApplication.Controllers.Dialogs;
using PractiseApplication.Models.Entities;
using System.Windows;

namespace PractiseApplication.Views.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для LocationCreation.xaml
    /// </summary>
    public partial class LocationCreation : Window
    {
        #region Fields.

        private Location _model;
        #endregion

        #region Constructors.

        public LocationCreation()
        {
            InitializeComponent();
            _model = (DataContext as LocationCreationController)?.Model ?? new Location();
        }
        #endregion

        #region Events.

        private void TryToCreateNewLocationOnClick(object sender, RoutedEventArgs e)
        {
            if (ValidateData())
            {
                BaseContext.Instance.Locations.Add(_model);
                BaseContext.Instance.SaveChanges();

                Closing -= ConfirmUserOnDialogExit;
                Close();
            }
        }

        private void DenyLocationCreationOnClick(object sender, RoutedEventArgs e) =>
                Close();

        private void ConfirmUserOnDialogExit(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены?\n\nИзменения не сохранятся.", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = false;
                return;
            }

            e.Cancel = true;
        }
        #endregion

        #region Functions.

        private bool ValidateData() =>
                GetErrors() != string.Empty;

        private string GetErrors()
        {
            string error = string.Empty;
            if (!int.TryParse(floorInput.Text, out int floor))
                error += "Этаж указан неверно.\n";
            if (!int.TryParse(cabinetInput.Text, out int cabinet))
                error += "Номер кабинета указан неверно.\n";
            if (string.IsNullOrWhiteSpace(municipalityInput.Text))
                error += "Указан некорректный муниципалитет.";

            return error;
        }
        #endregion
    }
}
