using PractiseApplication.Models.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PractiseApplication.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для RequestElement.xaml.
    /// </summary>
    public partial class RequestElement : UserControl
    {
        public Request Model { get; set; }

        public RequestElement(Request request)
        {
            Model = request;

            InitializeComponent();
            DataContext = Model;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ColorizeBordersByRequestStatus();
        }

        private void ColorizeBordersByRequestStatus()
        {
            switch (Model.RequestStatusId)
            {
                // 'Новый' — 'Sky Blue' color.
                case 1:
                    headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(136, 196, 245));
                    bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(136, 196, 245));

                    break;
                // 'Важный' — 'Orange' color.
                case 2:
                    headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(232, 105, 18));
                    bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(232, 105, 18));

                    break;
                // 'Критический' — 'Dark Red' color.
                case 3:
                    headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(149, 47, 47));
                    bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(149, 47, 47));

                    break;
                // 'Отложенный' — 'Gray' color.
                case 4:
                    headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(153, 153, 153));
                    bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(153, 153, 153));

                    break;
                // 'Решенный' — 'Dark Green' color.
                case 5:
                    headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 100, 0));
                    bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 100, 0));

                    break;
            }
        }
    }
}
