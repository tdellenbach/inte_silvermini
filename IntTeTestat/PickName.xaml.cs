using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IntTeTestat.GuessServiceReference;

namespace IntTeTestat
{
    public partial class PickName : UserControl
    {
        private MainPage mainPage;
        public PickName()
        {
            InitializeComponent();
            GuessServiceClient serviceClient = WebContext.Current.GuessServiceClient;
        }
        public PickName(MainPage parent)
        {
            InitializeComponent();
            mainPage = parent;
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            WebContext.Current.GuessServiceClient.AddNameAsync(nameTextBox.Text);
            
            WaitPage wait = new WaitPage(mainPage);
            mainPage.ContentFrame.Content = wait;
            //NavigationService.Navigate(new Uri("/WaitPage", UriKind.Relative));
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/Welcome", UriKind.Relative));
            Welcome welcome = new Welcome();
            mainPage.ContentFrame.Content = welcome;
        }

        private void nameTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (nameTextBox.Text.Length > 0)
            {
                btnPlay.IsEnabled = true;
            }
            else
            {
                btnPlay.IsEnabled = false;
            }
        }
    }
}
