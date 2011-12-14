
namespace IntTeTestat.Web.Util
{

    public class Player
    {

        private string _name;

        private IGuessService _guessService;

        private GuessGame _guessGame;

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
            set { this._guessService = value; }
            get { return this._guessService; }
        }

        public GuessGame GuessGame
        {
            set { this._guessGame = value; }
            get { return this._guessGame; }
        }

    }

}