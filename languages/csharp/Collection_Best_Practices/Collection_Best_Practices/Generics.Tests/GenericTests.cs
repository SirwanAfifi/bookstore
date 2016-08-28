using Microsoft.VisualStudio.TestTools.UnitTesting;
using Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Tests
{
    [TestClass()]
    public class GenericTests
    {
        [TestMethod()]
        public void RetrieveValueTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = 42;

            //Act
            var actual = repository.RetrieveValue<int>("Select .....", 42);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RetrieveValueStringTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = "test";

            //Act
            var actual = repository.RetrieveValue<string>("Select ....", "test");

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}