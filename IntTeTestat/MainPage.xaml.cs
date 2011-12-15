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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using IntTeTestat.GuessServiceReference;
using IntTeTestat.ViewModel;

namespace IntTeTestat
{
    public partial class MainPage : UserControl
    {
        GameModel gameModel;
        public MainPage()
        {
            InitializeComponent();
            gameModel = new GameModel();
            ContentFrame.DataContext = gameModel;

            WebContext.Current.GuessServiceClient.StartGameReceived += OnStartGameReceived;
            WebContext.Current.GuessServiceClient.PlayerGuessReceived += OnPlayerGuessReceived;
            WebContext.Current.GuessServiceClient.GameOverReceived += OnGameOverReceived;
            WebContext.Current.GuessServiceClient.HintReceived += OnHintReceived;
            WebContext.Current.GuessServiceClient.QuitConnectCompleted += OnQuitConnectCompleted;
            WebContext.Current.GuessServiceClient.PlayerLeftReceived += OnPlayerLeftReceived;

            ContentFrame.Navigate(new Uri("/Welcome", UriKind.Relative));
        }

        private void OnPlayerLeftReceived(object sender, PlayerLeftReceivedEventArgs e)
        {
            gameModel.Players.Remove(e.name);
        }

        private void OnQuitConnectCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
            ContentFrame.Navigate(new Uri("/Welcome", UriKind.Relative));
        }

        private void OnPlayerGuessReceived(object sender, PlayerGuessReceivedEventArgs e)
        {
            gameModel.Guesses.Add(e.guess);
        }

        private void OnHintReceived(object sender, HintReceivedEventArgs e)
        {
            gameModel.Hint = e.guessHint;
        }
       
        private void OnStartGameReceived(object sender, StartGameReceivedEventArgs e)
        {
            gameModel.Players = e.players;
            gameModel.Guesses.Clear();
            gameModel.Hint = GuessTipp.Others;
            gameModel.FinishedMessage = "";

            ContentFrame.Navigate(new Uri("/Game", UriKind.Relative));
        }

        private void OnGameOverReceived(object sender, GameOverReceivedEventArgs e)
        {
            if (e.victory)
            {
                gameModel.FinishedMessage = "Sie haben gewonnen!";
            }
            else
            {
                gameModel.FinishedMessage = "Sie haben verloren!";
            }
            ContentFrame.Navigate(new Uri("/Finished", UriKind.Relative));
        }


        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
        }
    }



    /// <summary>
    /// Add GuessServiceClient to WebContext
    /// </summary>
    public sealed partial class WebContext
    {
        private GuessServiceClient _proxy;
        public GuessServiceClient GuessServiceClient
        {
            get
            {
                
                if (_proxy == null)
                {
                    EndpointAddress address = new EndpointAddress("http://localhost:1701/GuessService.svc");
                    PollingDuplexHttpBinding binding = new PollingDuplexHttpBinding();
                    _proxy = new GuessServiceClient(binding, address);
                    _proxy.ConntectAsync();
                }
                return _proxy;
            }
        }
    }
}
