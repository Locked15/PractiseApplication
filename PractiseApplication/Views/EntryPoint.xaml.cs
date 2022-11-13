using PractiseApplication.Controllers;
using PractiseApplication.Controllers.Standalone;
using PractiseApplication.Models;
using PractiseApplication.Models.Entities;
using System;
using System.IO;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Media.Imaging;

namespace PractiseApplication.Views
{
    /// <summary>
    /// Interaction logic for EntryPoint.xaml.
    /// </summary>
    public partial class EntryPoint : Window
    {
        #region Fields.

        private EntryPointModel _model;
        #endregion

        #region Constructors.

        public EntryPoint()
        {
            InitializeComponent();
            _model = (DataContext as EntryPointController)?.Model ?? new EntryPointModel();

            TryToRestoreSavedLogin();
        }
        #endregion

        #region Functions.

        private void ProcessEnterKeyUse(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                TryToAuthorizeOnUserClick(sender, default);
        }

        #region Password Corresponding Functions.

        private void OnChangeOfTheVisiblePasswordBox(object sender, RoutedEventArgs e) =>
                _model.Password = passwordInput_Hidden.Password;

        private void OnChangeOfTheHiddenPasswordBox(object sender, System.Windows.Controls.TextChangedEventArgs e) =>
                _model.Password = passwordInput_Visible.Text;

        private void SwitchStateOfTheVisibilitySwitcherOnClick(object sender, RoutedEventArgs e)
        {
            _model.ShowPassword = !_model.ShowPassword;
            SwitchButtonSwitcherState(_model.ShowPassword);
        }

        private void SwitchButtonSwitcherState(bool show)
        {
            if (show)
            {
                passwordInput_Hidden.Visibility = Visibility.Hidden;
                passwordInput_Visible.Visibility = Visibility.Visible;

                passwordInput_Visible.Text = _model.Password;
                switchVisibilityModeImage.Source = new BitmapImage(new Uri(Path.Combine(ResourceController.GetProjectDirectory(), "Resources", "Icons", "show-hide", "hide.png")));
            }
            else
            {
                passwordInput_Hidden.Visibility = Visibility.Visible;
                passwordInput_Visible.Visibility = Visibility.Hidden;

                passwordInput_Hidden.Password = _model.Password;
                switchVisibilityModeImage.Source = new BitmapImage(new Uri(Path.Combine(ResourceController.GetProjectDirectory(), "Resources", "Icons", "show-hide", "show.png")));
            }
        }
        #endregion

        #region Authorization Functions.

        private void TryToAuthorizeOnUserClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is EntryPointController controller)
            {
                if (controller.TryToSignIn((controller.Model.Login, controller.Model.Password ?? string.Empty), out User? user))
                {
                    MoveToCorrespondingWindow(user);
                    if (_model.SaveLogin)
                        SaveLoginToTheNextTime();
                }

                else
                {
                    MessageBox.Show("Неверный логин и/или пароль.", "Ошибка Входа", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MoveToCorrespondingWindow(User user)
        {
            HomeWindow next = new HomeWindow(user);
            next.Show();

            MessageBox.Show(string.Format(GetGreetingMessage(), $"{user.LastName} {user.FirstName}"), "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private static string GetGreetingMessage()
        {
            var currentHour = DateTime.Now.Hour;

            if (currentHour < 9)
                return "Рабочий день ещё не начался, {0}. Решили прийти пораньше?\nВот и правильно.";
            else if (currentHour < 12)
                return "Доброе утро, {0}. Удачного рабочего дня.";
            else if (currentHour < 16)
                return "Рабочий день в самом разгаре, {0}. Потрудитесь на славу.";
            else if (currentHour < 18)
                return "Рабочее время скоро подойдет к концу. Постарайтесь закончить все, что осталось, {0}.";
            else
                return "Рабочий день уже закончен, {0}. Решили задержаться подольше?";
        }
        #endregion
        #endregion

        #region Login Restore/Saving Functions.

        private void TryToRestoreSavedLogin()
        {
            if (File.Exists(Path.Combine(ResourceController.GetProjectDirectory(), "login.cache")))
            {
                _model.Login = File.ReadAllText(Path.Combine(ResourceController.GetProjectDirectory(), "login.cache"));
                userLoginInput.Text = _model.Login;
            }
        }

        private void SaveLoginToTheNextTime()
        {
            using StreamWriter sw = new StreamWriter(Path.Combine(ResourceController.GetProjectDirectory(), "login.cache"), false, System.Text.Encoding.Default);
            sw.Write(_model.Login);
        }
        #endregion
    }
}
