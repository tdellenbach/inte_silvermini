using System;
using System.Windows;
using System.Windows.Controls;

namespace IntTeTestat
{
    public partial class WelcomePage : UserControl
    {

        public WelcomePage()
        {
            InitializeComponent();
            WarningTextBlock.Visibility = Visibility.Collapsed;
        }

        private void StartGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                WarningTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                Frame contentFrame = (Frame) Parent;
                contentFrame.Navigate(new Uri("/WaitingPage", UriKind.Relative));
                WebContext.Current.GuessServiceClient.AddNameAsync(UsernameTextBox.Text);
            }
        }

    }
}
