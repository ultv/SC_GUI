using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_GUI
{
    public class StubGame : IGame
    {
        public Game GetTestGame()
        {
            Game game = new Game();

            game.GameField = new Matrix();
            game.GameField.Size = 3;

            return game;
        }
    }
}
