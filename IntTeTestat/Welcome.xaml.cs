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
using IntTeTestat.GuessServiceReference;

namespace IntTeTestat
{
    public partial class Welcome : UserControl
    {
        private MainPage mainPage;
        public Welcome()
        {
            InitializeComponent();
            GuessServiceClient serviceClient = WebContext.Current.GuessServiceClient;
        }
        public Welcome(MainPage parent)
        {
            InitializeComponent();
            mainPage = parent;
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            PickName pick = new PickName(mainPage);
            mainPage.ContentFrame.Content = pick;
            //NavigationService.Navigate(new Uri("/PickName", UriKind.Relative));
        }
    }
}
