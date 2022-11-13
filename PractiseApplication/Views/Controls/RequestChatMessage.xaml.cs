using PractiseApplication.Models.Entities;
using System.Windows.Controls;

namespace PractiseApplication.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для RequestChatMessage.xaml
    /// </summary>
    public partial class RequestChatMessage : UserControl
    {
        public RequestChatMessage() 
        {
            InitializeComponent();
        }

        public RequestChatMessage(RequestChat chat)
        {
            InitializeComponent();
            DataContext = chat;
        }
    }
}
