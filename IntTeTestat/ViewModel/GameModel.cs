using System;
using System.Collections.ObjectModel;
using IntTeTestat.GuessServiceReference;
using System.Collections.Specialized;
using System.ComponentModel;

namespace IntTeTestat.ViewModel
{
    public class GameModel : INotifyPropertyChanged
    {

        private String _gameName;

        private GuessTipp _guessTip;

        private ObservableCollection<string> _players = new ObservableCollection<string>();

        private ObservableCollection<Guess> _guesses = new ObservableCollection<Guess>();
        
        public GameModel()
        {
            _players = new ObservableCollection<string>();
            _guesses = new ObservableCollection<Guess>();
            _guessTip = GuessTipp.Others;
            this._players.CollectionChanged += HandlePlayersChange;
            this._guesses.CollectionChanged += HandleGuessesChange;
        }

        public ObservableCollection<string> Players
        {
            set { this._players = value; }
            get { return this._players; }
        }

        public ObservableCollection<Guess> Guesses
        {
            set { this._guesses = value; SendPropertyChanged("LastGuess"); }
            get { return this._guesses; }
        }

        public string GameName
        {
            set { this._gameName = value; }
            get { return this._gameName; }
        }

        public Guess LastGuess
        {
            get
            {
                int numberOfGuesses = this._guesses.Count;
                if (numberOfGuesses > 0)
                {
                    return Guesses[numberOfGuesses - 1];
                }
                else
                {
                    return null;
                }
            }
        }

        public string FinishedMessage { get; set; }

        public GuessTipp Hint
        {
            get
            {
                return _guessTip;
            }
            set
            {
                _guessTip = value;
                SendPropertyChanged("Answer");
            }
        }

        public string Answer
        {
            get
            {
                switch (Hint)
                {
                    case GuessTipp.ToHigh:
                        return "Zu hoch!";

                    case GuessTipp.ToLow:
                        return "Zu tief!";

                    default: return "";
                }
            }
        }

        private void HandlePlayersChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            SendPropertyChanged("Players");
        }

        private void HandleGuessesChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            SendPropertyChanged("Guesses");
            SendPropertyChanged("CurrentGuess");
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sends the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected void SendPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
