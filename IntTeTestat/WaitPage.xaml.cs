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
using System.Windows.Navigation;

namespace IntTeTestat
{
    public partial class WaitPage : Page
    {
        public WaitPage()
        {
            InitializeComponent();
            sbStar.Begin();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            WebContext.Current.GuessServiceClient.QuitConnectAsync();
            NavigationService.Navigate(new Uri("/Welcome", UriKind.Relative));
        }
    }
}
