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

        private Player _currentPlayer;

        private GuessGame _currentGuessGame;

        private List<Player> _players = new List<Player>();

        private static List<GuessGame> _guessGames = new List<GuessGame>();

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
                List<Player> joiningPlayers = this._players.GetRange(0, GuessGame._maxPlayers);
                this._players.RemoveRange(0, joiningPlayers.Count);
                this._currentGuessGame = new GuessGame(joiningPlayers);
                GuessService._guessGames.Add(this._currentGuessGame);
                List<Player> players = this._currentGuessGame.Players;
                List<string> playerNames = new List<string>();
                foreach(Player player in players)
                {
                    playerNames.Add(player.Name);
                }
                foreach (Player player in players)
                {
                    player.GuessService.StartGame(playerNames, player.Name);
                    player.GuessGame = this._currentGuessGame;
                }
            }
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Guess(Int32 value)
        {
            
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
        }
    }

    [ServiceContract]
    public interface IGuessService
    {
        [OperationContract(IsOneWay = true)]
        void StartGame(List<string> players, string playerName);

        [OperationContract(IsOneWay = true)]
        void GameOver(bool victory, List<Guess> playedValues);

        [OperationContract(IsOneWay = true)]
        void ConnectCanceled();

        [OperationContract(IsOneWay = true)]
        void PlayerGuess(Guess guess);
    }

}
