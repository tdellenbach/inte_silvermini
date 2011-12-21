
namespace IntTeTestat.Web.Util
{

    public class Player
    {

        private string _name;
        private IGuessService _guessService;

        public Player(string playerName, IGuessService guessService)
        {
            this._name = playerName;
            this._guessService = guessService;
        }

        public string Name
        {
            set { this._name = value; }
            get { return this._name; }
        }

        public IGuessService GuessService
        {
            get { return this._guessService; }
        }
    }

}