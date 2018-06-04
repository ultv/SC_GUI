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
            // Arrange
            int accept = 3;            
            int expected = 9;
            Game game = new Game();

            // Act
            int actual = game.TotalSteps(accept);
          
            //Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
