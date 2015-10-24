using System;
using InSeasonAPI.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InSeasonAPI.Tests
{
    [TestClass]
    public class DateConverterTests
    {
        [TestMethod]
        public void DateConverterTestConvert()
        {
            var test = DateConverter.ConvertToDateTime("2014-12-01").ToString();
            var result = new DateTime(2014, 12, 1, 23, 59, 59).ToString();

            Assert.AreEqual(test, result);
        }
    }
}
