using Prism.Events;
using ReactorControlSystem.Core.Events;
using System.Windows.Controls;

namespace ReactorControlSystem.Modules.Login.Views
{
    /// <summary>
    /// Interaction logic for LoginView
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            eventAggregator.GetEvent<PopupMessageEvent>().Subscribe(PopupMessage);
        }

        private void PopupMessage(string message)
        {
            snackbar.MessageQueue.Enqueue(message);
        }
    }
}
