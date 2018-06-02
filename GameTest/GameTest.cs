using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_GUI;

namespace GameTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void TotalSteps_3and3_9returned()
        {

            int accept = 3;            
            int expected = 9;

            Game game = new Game();
            int actual = game.TotalSteps(accept);

            Assert.AreEqual(expected, actual);

        }
    }
}
