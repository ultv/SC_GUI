using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_GUI;
using AutoFixture;
using Moq;

namespace SelectorTest
{
    [TestClass]
    public class SelectorTest
    {
        [TestMethod]
        public void SelectPlayerByIdTest()
        {
            // Arrange
            int id = (new Random()).Next(2);
            DBProviderStub dbProvider = new DBProviderStub();
            Selector selector = new Selector(dbProvider);

            // Act
            selector.SelectPlayerById(id);

            //Assert 
            Assert.IsNotNull(selector.message);

        }


        [TestMethod]
        public void SelectPlayerByIdTestMock()
        {
            // Arrange
            var mock = new Mock<IDBProvider>();
            Selector selector = new Selector(mock.Object);
                      
            Player player = new Fixture().Create<Player>();

            mock.Setup(x => x.GetPlayerById(It.IsAny<int>())).Returns(player);
            int id = new Fixture().Create<int>();

            // Act
            selector.SelectPlayerById(id);

            //Assert 
            Assert.IsNotNull(selector.message);

        }
    }
}
