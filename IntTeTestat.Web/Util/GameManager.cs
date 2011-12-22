using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntTeTestat.Web.Util
{
    public class GameManager
    {
        private static GuessGame gameInstance;
        public static GuessGame JoinGame(Player player)
        {
            if (gameInstance == null)
            {
                gameInstance = new GuessGame();
            }
            if (gameInstance.isFull())
            {
                gameInstance = new GuessGame();
            }
            gameInstance.Add(player);
            return gameInstance;
        }
    }
}