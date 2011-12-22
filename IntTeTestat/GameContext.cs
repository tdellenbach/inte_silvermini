using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace IntTeTestat
{
    public class GameContext
    {
        private ObservableCollection<string> players;
        public string Name { get; set; }
        private ObservableCollection<GuessEntrie> playedValues = new ObservableCollection<GuessEntrie>();

        public string GuessMsg
        {
            get
            {
                return "Willkommen zum Raten " + Name;
            }
            set
            {
                Name = value;
            }
        }

        public ObservableCollection<string> Players
        {
            get
            {
                return players;
            }
            set
            {
                players = value;
            }
        }

        public int Tipp { get; set; }

        public ObservableCollection<GuessEntrie> PlayedValues
        {
            get
            {
                return playedValues;
            }
            set
            {
                playedValues = value;
            }
        }

        public bool Victory { get; set; }

        public string ResultMsg
        {
            get
            {
                if (Victory)
                {
                    return Name + ", sie haben gewonnen!";
                }
                return Name + ", sie haben leider verloren";
            }
        }
    }
}
