using PractiseApplication.Models.Entities;
using System;
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
            var redValue = Model.RequestStatus?.ColorRgbStringValue.Split(", ")[0] ?? "0";
            var greenValue = Model.RequestStatus?.ColorRgbStringValue.Split(", ")[1] ?? "0";
            var blueValue = Model.RequestStatus?.ColorRgbStringValue.Split(", ")[2] ?? "0";

            headerBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(redValue), 
                                                                         Convert.ToByte(greenValue), 
                                                                         Convert.ToByte(blueValue)));
            bodyBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(Convert.ToByte(redValue),
                                                                       Convert.ToByte(greenValue),
                                                                       Convert.ToByte(blueValue)));
        }
    }
}
