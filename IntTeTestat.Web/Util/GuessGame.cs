using System;
using System.Collections.Generic;

namespace IntTeTestat.Web.Util
{
    public class GuessGame
    {
        private List<Player> _players;
        public const Int32 _maxPlayers = 3;
        private Int32 _lowerBound = 1;
        private Int32 _upperBound = 10;
        private Int32 _randomInt;

        public GuessGame(List<Player> players)
        {
            this._players = players;
            _randomInt = new Random().Next(this._lowerBound, this._upperBound);
        }

        public List<string> PlayerNames
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Player p in Players)
                {
                    names.Add(p.Name);
                }
                return names;
            }
        }

        public List<Player> Players
        {
            get { return this._players; }
        }

        internal int RandomInt
        {
            get { return _randomInt; }
            set { _randomInt = value; }
        }

        public bool IsGuessCorrect(int value)
        {
            return value == _randomInt;
        }

        public GuessTipp GetGuessTipp(Guess g)
        {
            if (g.GuessValue.CompareTo(_randomInt) == 0)
            {
                return GuessTipp.Correct;
            }
            else if (g.GuessValue.CompareTo(_randomInt) > 0)
            {
                return GuessTipp.TooHigh;
            }
            else
            {
                return GuessTipp.TooLow;
            }
        }
    }
}