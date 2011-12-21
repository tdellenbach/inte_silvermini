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
            Player _currentPlayer = new Player(name, _client);
            _currentGuessGame = GameManager.JoinGame(_currentPlayer);
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void Guess(Int32 value)
        {
            _currentGuessGame.Check(value);
        }

        [OperationContract(IsOneWay = true)]
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void QuitConnect()
        {
            _currentGuessGame.Leave();
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
        void PlayerLeft(string name);

        [OperationContract(IsOneWay = true)]
        void PlayerGuess(Guess guess);
    }
}
