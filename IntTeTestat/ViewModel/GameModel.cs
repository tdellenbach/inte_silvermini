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
            this._players.CollectionChanged += HandlePlayersChange;
            this._guesses.CollectionChanged += HandleGuessesChange;
        }

        public string GameName
        {
            set { this._gameName = value; }
            get { return this._gameName; }
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

        public Guess CurrentGuess
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

        public GuessTipp GuessTip
        {
            set { this._guessTip = value; SendPropertyChanged("GuessTip"); }
            get { return this._guessTip; }
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
