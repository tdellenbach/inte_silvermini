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
using System.Collections.ObjectModel;

namespace IntTeTestat
{
    public partial class MainPage : UserControl
    {
        private GameContext context;

        public MainPage()
        {
            InitializeComponent();
            GuessServiceClient serviceClient = WebContext.Current.GuessServiceClient;

            serviceClient.StartGameReceived += OnStartGameReceived;
            serviceClient.GameOverReceived += OnGameOverReceived;
            serviceClient.ConnectCanceledReceived += OnConnectCanceledRecieved;

            ContentFrame.Content = new Info(this);
        }

        public GameContext GameContext
        {
            get
            {
                if (context == null)
                {
                    context = new GameContext();
                }
                return context;
            }
            set
            {
                context = value;
            }
        }
       
        private void OnStartGameReceived(object sender, StartGameReceivedEventArgs e)
        {
            GameContext.Name = e.playerName;
            GameContext.Players = e.players;
            Game game = new Game(this);
            game.DataContext = GameContext;
            ContentFrame.Content = game;
            //ContentFrame.Navigate(new Uri("/GuessGame", UriKind.Relative));
        }

        private void OnGameOverReceived(object sender, GameOverReceivedEventArgs e)
        {
            GameContext.Victory = e.victory;
            ObservableCollection<GuessServiceReference.Guess> played = e.playedValues;
            ObservableCollection<GuessEntrie> endResult = new ObservableCollection<GuessEntrie>();

            foreach (GuessServiceReference.Guess guess in played)
            {
                IntTeTestat.GuessEntrie.EndResultEntrie entrie = new IntTeTestat.GuessEntrie.EndResultEntrie();
                entrie.Name = guess._playerName;
                entrie.Guess = guess._guessValue;
                endResult.Add(entrie);
            }

            GameContext.PlayedValues = endResult;
            
            Finished endpage = new Finished(this);
            endpage.DataContext = GameContext;
            ContentFrame.Content = endpage;
        }

        private void OnConnectCanceledRecieved(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            ContentFrame.Content = new WaitPage();
            //ContentFrame.Navigate(new Uri("/WaitPage", UriKind.Relative));
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
