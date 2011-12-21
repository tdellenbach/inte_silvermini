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
using IntTeTestat.ViewModel;
using System.Windows.Data;
using IntTeTestat.GuessServiceReference;

namespace IntTeTestat
{
    public partial class Game : UserControl
    {
        private MainPage mainpage;
        public Game()
        {
            InitializeComponent();
            WebContext.Current.GuessServiceClient.PlayerGuessReceived += OnPlayerGuessRecieved;
        }

        public Game(MainPage mp)
        {
            InitializeComponent();
            WebContext.Current.GuessServiceClient.PlayerGuessReceived += OnPlayerGuessRecieved;
            mainpage = mp;
        }

        //private void guessTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    // check if entered value is a number
        //    if (!System.Text.RegularExpressions.Regex.IsMatch(e.Key.ToString(), "\\d+") && e.Key != Key.Tab)
        //    {
        //        e.Handled = true;
        //    }
        //}

        //private void guessTextBox_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (guessTextBox.Text.Length > 0)
        //    {
        //        checkGuessButton.IsEnabled = true;
        //    }
        //    else
        //    {
        //        checkGuessButton.IsEnabled = false;
        //    }
        //}

        private void checkGuessButton_Click(object sender, RoutedEventArgs e)
        {
            GameContext context = (GameContext)DataContext;
            WebContext.Current.GuessServiceClient.GuessAsync(context.Tipp);

            //WebContext.Current.GuessServiceClient.GuessAsync(int.Parse(guessTextBox.Text), (DataContext as GameModel).GameName);
            //guessTextBox.Text = "";
            //checkGuessButton.IsEnabled = false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            WebContext.Current.GuessServiceClient.QuitConnectAsync();
            mainpage.ContentFrame.Content = new Info(mainpage);
        }

        private void OnPlayerGuessRecieved(object sender, PlayerGuessReceivedEventArgs e)
        {
            GameContext context = (GameContext)DataContext;
            GuessEntrie entrie = new GuessEntrie();
            if (e.guess._guessValue.Equals("Has Quit"))
            {
                entrie = new IntTeTestat.GuessEntrie.EndResultEntrie();
            }
            entrie.Guess = e.guess._guessValue;
            entrie.Tipp = e.guess.Tippk__BackingField;
            entrie.Name = e.guess._playerName;
            context.PlayedValues.Add(entrie);
        }
    }
}
