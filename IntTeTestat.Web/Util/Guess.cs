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

        private Int32 _guess;

        private string _playerName;

        private GuessTipp _guessTip;

        public Guess(Int32 guess, string playerName)
        {
            this._guess = guess;
            this._playerName = playerName;
        }

        [DataMember]
        public Int32 Guess
        {
            set { this._guess = value; }
            get { return this._guess; }
        }

        [DataMember]
        public string PlayerName
        {
            set { this._playerName = value; }
            get { return this._playerName; }
        }

        [DataMember]
        public GuessTipp GuessTip(Int32 target)
        {
            if (this._guess < target)
            {
                return GuessTipp.TooLow;
            }
            else if (this._guess > target)
            {
                return GuessTipp.TooHigh;
            }
            else if (this._guess == target)
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