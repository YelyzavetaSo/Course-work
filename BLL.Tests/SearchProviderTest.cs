using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DAL;

namespace BLL.Tests
{
    [TestClass]
    public class SearchProviderTest
    {
        [TestMethod]
        public void SearchTrainByNumber_Should_return_expected_train_after_search()
        {
            string trainnumber = "123A";
            string Path = @"..\DataBase\TrainsTest.bin";
            Train searchedTrain = SearchProvider.SearchOfTrainByNumber(trainnumber, Path);
            Assert.AreEqual(trainnumber, searchedTrain.TrainNumber);
        }
    }
}
