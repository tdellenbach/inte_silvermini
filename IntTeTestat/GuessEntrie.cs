using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntTeTestat
{
    public class GuessEntrie
    {
        public string Name { get; set; }
        public string Guess { get; set; }
        public GuessServiceReference.GuessTipp Tipp { get; set; }

        public override string ToString()
        {
            string listItem = "";
            if (Tipp == GuessServiceReference.GuessTipp.ToLow)
            {
                listItem = Name + ":" + Guess + "\n" + "Dieser Tipp war zu klein";
            }
            else
            {
                listItem = Name + ":" + Guess + "\n" + "Dieser Tipp war zu gross";
            }
            return listItem;
        }

        public class EndResultEntrie : GuessEntrie
        {
            public override string ToString()
            {
                return Name + ":" + Guess;
            }
        }
    }
}
