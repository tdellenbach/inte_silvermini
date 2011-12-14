using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.ServiceModel;
using IntTeTestat.GuessServiceReference;
using IntTeTestat.ViewModel;

namespace IntTeTestat
{
    public partial class MainPage : UserControl
    {

        private GameModel _gameModel;

        public MainPage()
        {
            InitializeComponent();

            ContentFrame.DataContext = GameModelInstance;

            GuessServiceClient guessServiceClient = WebContext.Current.GuessServiceClient;
            guessServiceClient.StartGameReceived += OnStartGameReceived;
            guessServiceClient.GameOverReceived += OnGameOverReceived;
            guessServiceClient.PlayerGuessReceived += OnPlayerGuessReceived;

            ContentFrame.Navigate(new Uri("/WelcomePage", UriKind.Relative));
        }

        private GameModel GameModelInstance
        {
            set { this._gameModel = value; }
            get
            {
                if (this._gameModel == null)
                {
                    this._gameModel = new GameModel();
                }
                return this._gameModel;
            }
        }

        private void OnStartGameReceived(object sender, StartGameReceivedEventArgs eventArgs)
        {
            _gameModel.GameName = eventArgs.playerName;
            _gameModel.Players = eventArgs.players;
        }

        private void OnGameOverReceived(object sender, GameOverReceivedEventArgs eventArgs)
        {

        }

        private void OnPlayerGuessReceived(object sender, PlayerGuessReceivedEventArgs eventArgs)
        {
            _gameModel.Guesses.Add(eventArgs.guess);
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
