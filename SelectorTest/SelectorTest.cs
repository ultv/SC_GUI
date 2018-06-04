using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CS_GUI;

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
    }
}
