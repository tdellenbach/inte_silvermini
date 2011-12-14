using System;
using System.Collections.Generic;

namespace IntTeTestat.Web.Util
{
    public class GuessGame
    {
        private List<Player> _players;

        private Int32 _maxPlayers = 2;

        private Int32 _lowerBound = 1;

        private Int32 _upperBound = 10;

        private Int32 _targetValue;

        public GuessGame(List<Player> players)
        {
            this._players = players;
            _targetValue = new Random().Next(this._lowerBound, this._upperBound);
        }

        public List<Player> Players
        {
            get { return this._players; }
        }

        public GuessTipp GuessTipp(Guess guess)
        {
            return guess.GuessTip(_targetValue);
        }

    }
}