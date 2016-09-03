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

        [TestMethod]
        public void RetrieveValueObjectTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var vendor = new Vendor();
            var expected = vendor;

            //Act
            var actual = repository.RetrieveValue<Vendor>("Select ....", vendor);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void RetrieveTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>();
            expected.Add(new Vendor() { VendorId = 1, CompanyName = "ABC", Email = "ABC@gmail.com" });
            expected.Add(new Vendor() { VendorId = 2, CompanyName = "XYZ", Email = "XYZ@gmail.com" });

            //Act
            var actual = repository.Retrieve();

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void RetrieveWithIteratorTest()
        {
            //Arrange
            var repository = new VendorRepository();
            var expected = new List<Vendor>
            {
                new Vendor() {VendorId = 1, CompanyName = "ABC", Email = "ABC@gmail.com"},
                new Vendor() {VendorId = 2, CompanyName = "XYZ", Email = "XYZ@gmail.com"}
            };

            //Act
            var vendorIterator = repository.RetrieveWithIterator();
            foreach (var item in vendorIterator)
            {
                Console.WriteLine(item);
            }
            var actual = vendorIterator.ToList();

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTest()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendors = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC", 
                "Message sent: Important message for: XYZ"
            };
            //Act
            var actual = Vendor.SendEmail(vendors.ToList(), "Test Message");

            //Assert
            CollectionAssert.AreEqual(expected, actual.ToList());
        }

        [TestMethod()]
        public void SendEmailTestArray()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC",
                "Message sent: Important message for: XYZ"
            };
            var array = vendorsCollection.ToArray();
            var list = vendorsCollection.ToList();
            var dictionary = vendorsCollection.ToDictionary(p => p.CompanyName);
            //Act
            //var actual = Vendor.SendEmail(vendorsCollection, "Test Message");

            //Assert
            //CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendEmailTestDictionary()
        {
            //Arrange
            var vendorRepository = new VendorRepository();
            var vendorsCollection = vendorRepository.Retrieve();
            var expected = new List<string>()
            {
                "Message sent: Important message for: ABC",
                "Message sent: Important message for: XYZ"
            };
            var vendors = vendorsCollection.ToDictionary(p => p.CompanyName);
            //Act
            var actual = Vendor.SendEmail(vendors.Values, "Test Message");

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}