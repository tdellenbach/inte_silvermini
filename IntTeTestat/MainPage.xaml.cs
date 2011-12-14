using System.Windows.Controls;
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

            WebContext.Current.GuessServiceClient.StartGameReceived += OnStartGameReceived;
            WebContext.Current.GuessServiceClient.GameOverReceived += OnGameOverReceived;
            WebContext.Current.GuessServiceClient.PlayerGuessReceived += OnPlayerGuessReceived;

            this._gameModel = new GameModel();
            ContentFrame.DataContext = this._gameModel;
            ContentFrame.Content = new WelcomePage();
        }
       
        private void OnStartGameReceived(object sender, StartGameReceivedEventArgs eventArgs)
        {
            _gameModel.GameName = eventArgs.playerName;
            _gameModel.Players = eventArgs.players;

            ContentFrame.Content = new GamePage();
        }

        private void OnGameOverReceived(object sender, GameOverReceivedEventArgs eventArgs)
        {
            ContentFrame.Content = new GameOverPage();
        }

        private void OnPlayerGuessReceived(object sender, PlayerGuessReceivedEventArgs eventArgs)
        {
            _gameModel.Guesses.Add(eventArgs.guess);
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
