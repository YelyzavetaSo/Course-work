using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BLL.Tests
{
    [TestClass]
    public class VerifyInputServiceTest
    {
        [TestMethod()]
        public void IsInputCorrect_should_return_true_after_cheking_value_with_pattern()
        {
            string pattern = "^(IC|RE|NE|NF)$";
            string value = "IC";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsTrue(result);
        }
        [TestMethod()]
        public void IsInputCorrect_should_return_false_after_cheking_value_with_pattern()
        {
            string pattern = "^(IC|RE|NE|NF)$";
            string value = "Way";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsFalse(result);
        }
    }
}
