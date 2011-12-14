using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

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
               /// TODO check if enough players, load the waitingPage or the gamePage, how can we invite the other players to the game?
                Frame contentFrame = (Frame) this.Parent;
                contentFrame.Content = new WaitingPage();
            }
        }

    }
}
