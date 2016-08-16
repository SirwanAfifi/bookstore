using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonRepository.Fake;
using PersonRepository.Interface;

namespace PeopleViewer.Test
{
    [TestClass]
    public class RepositoryFactoryTest
    {
        [TestMethod]
        public void GetRepository_OnCreation_ReturnFakeRepository()
        {
            // Arrange / Act
            var repositoryFactory = RepositoryFactory.GetRepository();

            // Assert
            Assert.AreEqual(repositoryFactory.GetType(), typeof(FakeRepository));
        }
    }
}
