using System.Windows;
using System.Windows.Controls;

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
