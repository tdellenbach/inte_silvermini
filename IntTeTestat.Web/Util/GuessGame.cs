using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Diagnostics;

namespace IntTeTestat.Web.Util
{
    public class GuessGame
    {
        private Dictionary<IGuessService, Player> _players = new Dictionary<IGuessService,Player>();
        private List<Guess> played = new List<Guess>();

        public const Int32 _maxPlayers = 3;
        private Int32 _randomInt;
        
        private Int32 _lowerBound = 1;
        private Int32 _upperBound = 10;

        //public GuessGame(List<Player> players)
        //{
        //    this._players = players;
        //    _randomInt = new Random().Next(this._lowerBound, this._upperBound);
        //}

        public GuessGame()
        {
            _randomInt = new Random().Next(this._lowerBound, this._upperBound);
        }

        internal void Add(Player player)
        {
            _players.Add(player.GuessService, player);
            if (isFull())
            {
                Start();
            }
            //throw new NotImplementedException();
        }

        internal bool isFull()
        {
            return _players.Count == _maxPlayers;
            //throw new NotImplementedException();
        }

        private void Start()
        {
            List<String> playerList = new List<string>();
            foreach (KeyValuePair<IGuessService, Player> play in _players)
            {
                playerList.Add(play.Value.Name);
            }
            foreach (KeyValuePair<IGuessService, Player> play in _players)
            {
                play.Key.StartGame(playerList, play.Value.Name);
            }
        }

        public void Check(Int32 externGuess)
        {
            IGuessService clientCB = OperationContext.Current.GetCallbackChannel<IGuessService>();
            Player currentPlayer = _players[clientCB];
            Guess guess = new Guess(externGuess.ToString(), currentPlayer.Name);
            played.Add(guess);

            if (_randomInt == externGuess)
            {
                clientCB.GameOver(true, played);
                foreach (KeyValuePair<IGuessService, Player> copyied in _players)
                {
                    if (copyied.Key != clientCB)
                    {
                        copyied.Key.GameOver(false, played);
                    }
                }
            }
            else
            {
                if (externGuess < _randomInt){guess.Tipp = GuessTipp.ToLow;}
                else { guess.Tipp = GuessTipp.ToHigh; }

                foreach (KeyValuePair<IGuessService, Player> player in _players)
                {
                    player.Key.PlayerGuess(guess);
                }
            }
        }

        public void Leave()
        {
            IGuessService clientCB = OperationContext.Current.GetCallbackChannel<IGuessService>();
            Player quit = _players[clientCB];
            Guess msg = new Guess("Has quit the game!", quit.Name);
            played.Add(msg);
            foreach (KeyValuePair<IGuessService, Player> play in _players)
            {
                play.Key.PlayerGuess(msg);
                if (play.Key != clientCB)
                {
                    play.Key.ConnectCanceled();
                }
            }
            _players.Remove(clientCB);
        }



        //public List<string> PlayerNames
        //{
        //    get
        //    {
        //        List<string> names = new List<string>();
        //        foreach (Player p in Players)
        //        {
        //            names.Add(p.Name);
        //        }
        //        return names;
        //    }
        //}

        //public List<Player> Players
        //{
        //    get { return this._players; }
        //}

        //internal int RandomInt
        //{
        //    get { return _randomInt; }
        //    set { _randomInt = value; }
        //}

        //public bool IsGuessCorrect(int value)
        //{
        //    return value == _randomInt;
        //}

        //public GuessTipp GetGuessTipp(Guess g)
        //{
        //    if (g.GuessValue.CompareTo(_randomInt) == 0)
        //    {
        //        return GuessTipp.Correct;
        //    }
        //    else if (g.GuessValue.CompareTo(_randomInt) > 0)
        //    {
        //        return GuessTipp.TooHigh;
        //    }
        //    else
        //    {
        //        return GuessTipp.TooLow;
        //    }
        //}
    }
}