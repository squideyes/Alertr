using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alertr.Shared.Tests
{
    [TestClass]
    public class EmailAlertTests
    {
        [TestMethod]
        public void TestFromValidationWithNullValue()
        {
            var alert = new EmailAlert() { };

            Assert.IsFalse(alert.ValidateProperty("From", alert.From));
        }

        [TestMethod]
        public void TestFromValidationWithBadEmail()
        {
            var alert = new EmailAlert() { From = "aaa" };

            Assert.IsFalse(alert.ValidateProperty("From", alert.From));
        }

        [TestMethod]
        public void TestFromValidationWithEmptyValue()
        {
            var alert = new EmailAlert() { From = string.Empty};

            Assert.IsFalse(alert.ValidateProperty("From", alert.From));
        }

        [TestMethod]
        public void TestFromValidationWithGoodEmail()
        {
            var alert = new EmailAlert() { From = "somedude@somehost.com" };

            Assert.IsTrue(alert.ValidateProperty("From", alert.From));
        }
    }
}
