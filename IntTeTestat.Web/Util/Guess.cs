using System;
using System.Runtime.Serialization;

namespace IntTeTestat.Web.Util
{
    public enum GuessTipp
    {
        TooLow,
        TooHigh,
        Correct,
        Others
    }

    [Serializable]
    public class Guess
    {

        private Int32 _guessValue;

        private string _playerName;

        public Guess(Int32 guessValue, string playerName)
        {
            this._guessValue = guessValue;
            this._playerName = playerName;
        }

        [DataMember]
        public Int32 GuessValue
        {
            set { this._guessValue = value; }
            get { return this._guessValue; }
        }

        [DataMember]
        public string PlayerName
        {
            set { this._playerName = value; }
            get { return this._playerName; }
        }

        public GuessTipp GuessTip(Int32 target)
        {
            if (this._guessValue < target)
            {
                return GuessTipp.TooLow;
            }
            else if (this._guessValue > target)
            {
                return GuessTipp.TooHigh;
            }
            else if (this._guessValue == target)
            {
                return GuessTipp.Correct;
            }
            else
            {
                return GuessTipp.Others;
            }
        }

    };

}