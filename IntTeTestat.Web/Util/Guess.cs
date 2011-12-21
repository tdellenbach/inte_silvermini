using System;
using System.Runtime.Serialization;

namespace IntTeTestat.Web.Util
{
    public enum GuessTipp
    {
        ToLow,
        ToHigh,
        Correct,
        Others
    }

    //[DataContract]
    [Serializable]
    public class Guess
    {
        private string _guessValue;
        private string _playerName;

        public Guess(string guessValue, string playerName)
        {
            this._guessValue = guessValue;
            this._playerName = playerName;
        }

        public GuessTipp Tipp { set; get; }

        //public String GuessValue
        //{
        //    set { this._guessValue = value; }
        //    get { return this._guessValue; }
        //}

        //[DataMember]
        //public string PlayerName
        //{
        //    set { this._playerName = value; }
        //    get { return this._playerName; }
        //}

        //public GuessTipp GetGuessTip(Int32 target)
        //{
        //    if (this._guessValue < target)
        //    {
        //        return GuessTipp.TooLow;
        //    }
        //    else if (this._guessValue > target)
        //    {
        //        return GuessTipp.TooHigh;
        //    }
        //    else if (this._guessValue == target)
        //    {
        //        return GuessTipp.Correct;
        //    }
        //    else
        //    {
        //        return GuessTipp.Others;
        //    }
        //}

        //[DataMember]
        //public string PlayerAndGuess
        //{
        //    get { return PlayerName + ": " + Convert.ToString(_guessValue); }
        //    set { throw new NotImplementedException(); }
        //}

        //[DataMember]
        //public GuessTipp Answer { get; set; }
    }
}