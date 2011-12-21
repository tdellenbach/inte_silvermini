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
    public partial class WaitPage : UserControl
    {
        private MainPage mainPage;
        public WaitPage()
        {
            InitializeComponent();
            sbStar.Begin();
        }
        public WaitPage(MainPage mp)
        {
            InitializeComponent();
            mainPage = mp;
            sbStar.Begin();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            WebContext.Current.GuessServiceClient.QuitConnectAsync();
            mainPage.ContentFrame.Content = new Info(mainPage);
            //NavigationService.Navigate(new Uri("/Welcome", UriKind.Relative));
        }
    }
}
