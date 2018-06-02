using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_GUI;


namespace BrainTest
{
    [TestClass]
    public class BrainTest
    {
        [TestMethod]
        public void GetIndexIOfPosition_5_1returned()
        {
            int accept = 5;
            int expected = 1;

            Game game = new Game();
            Brain  brain = new Brain();

            game.GameField = new Matrix();
            game.GameField.Size = 3;
            int actual = brain.GetIndexIOfPosition(game, accept);
            

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetIndexIJfPosition_5_2returned()
        {
            int accept = 5;
            int expected = 2;

            Game game = new Game();
            Brain brain = new Brain();

            game.GameField = new Matrix();
            game.GameField.Size = 3;
            int actual = brain.GetIndexJOfPosition(game, accept);


            Assert.AreEqual(expected, actual);

        }

       

    }
}
