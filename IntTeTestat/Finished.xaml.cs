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
    public partial class Finished : UserControl
    {
        private MainPage mainPage;
        public Finished()
        {
            InitializeComponent();
        }

        public Finished(MainPage mp)
        {
            InitializeComponent();
            mainPage = mp;
        }

        private void playAgainButton_Click(object sender, RoutedEventArgs e)
        {
            mainPage.GameContext = null;
            Info startPage = new Info(mainPage);
            mainPage.ContentFrame.Content = startPage;
        }

    }
}
