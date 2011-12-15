using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Activation;
using IntTeTestat.Web.Util;

namespace IntTeTestat.Web
{
    
    [ServiceContract(Namespace = "", CallbackContract = typeof(IGuessService))]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GuessService
    {
        private IGuessService _client;
        private List<Player> _players = new List<Player>();
        private static List<GuessGame> _guessGames = new List<GuessGame>();
        private Player _currentPlayer;
        private GuessGame _currentGuessGame;

        [OperationContract(IsOneWay = true)]
        public void Conntect()
        {
            _client = OperationContext.Current.GetCallbackChannel<IGuessService>();
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddName(string name)
        {
            this._currentPlayer = new Player(name, _client);
            this._players.Add(this._currentPlayer);

            if (this._players.Count >= GuessGame._maxPlayers)
            {
                this.StartGame();
            }
        }

        public void StartGame()
        {
            CreateGame();
            foreach (Player p in this._currentGuessGame.Players)
            {
                p.GuessService.StartGame(this._currentGuessGame.PlayerNames, p.Name);
                p.GuessGame = this._currentGuessGame;
            }
        }

        private void CreateGame()
        {
            List<Player> currentPlayers = _players.GetRange(0, GuessGame._maxPlayers);
            _currentGuessGame = new GuessGame(currentPlayers);
            _players.RemoveRange(0, GuessGame._maxPlayers);
            GuessService._guessGames.Add(this._currentGuessGame);
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Guess(Int32 value, string name)
        {
            Guess guess = new Guess(value, name);
            SendGuess(guess);

            if (_currentPlayer.GuessGame.IsGuessCorrect(value))
            {
                SendGameOver();
            }
            else
            {
                SendHint(guess);
            }
        }

        private void SendGuess(Guess g)
        {
            foreach (Player p in _currentPlayer.GuessGame.Players)
            {
                p.GuessService.PlayerGuess(g);
            }
        }

        private void SendHint(Guess g)
        {
            _currentPlayer.GuessService.Hint(_currentPlayer.GuessGame.GetGuessTipp(g));
        }

        private void SendGameOver()
        {
            _currentPlayer.GuessService.GameOver(true);
            foreach (Player p in _currentPlayer.GuessGame.Players)
            {
                if (!p.Equals(_currentPlayer))
                {
                    p.GuessService.GameOver(false);
                }
            }
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void QuitConnect()
        {
            if (this._currentPlayer.GuessGame != null)
            {
                this._currentPlayer.GuessGame.Players.Remove(this._currentPlayer);
            }
            this._players.Remove(this._currentPlayer);
            _client.ConnectCanceled();
            SendPlayerLeft();
        }

        private void SendPlayerLeft()
        {
            _currentPlayer.GuessService.ConnectCanceled();
            if (_currentPlayer.GuessGame != null)
            {
                foreach (Player p in _currentPlayer.GuessGame.Players)
                {
                    if (!p.Equals(_currentPlayer))
                    {
                        p.GuessService.PlayerLeft(_currentPlayer.Name);
                    }
                }
            }
        }
    }

    [ServiceContract]
    public interface IGuessService
    {
        [OperationContract(IsOneWay = true)]
        void StartGame(List<string> players, string playerName);

        [OperationContract(IsOneWay = true)]
        void GameOver(bool victory);

        [OperationContract(IsOneWay = true)]
        void ConnectCanceled();

        [OperationContract(IsOneWay = true)]
        void PlayerLeft(string name);

        [OperationContract(IsOneWay = true)]
        void PlayerGuess(Guess guess);

        [OperationContract(IsOneWay = true)]
        void Hint(GuessTipp guessHint);
    }
}
