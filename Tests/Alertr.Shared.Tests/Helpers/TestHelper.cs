using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alertr.Shared.Tests
{
    public static class TestHelper
    {
        public static void RunStandardStringTests(
            object instance, string memberName, int minLength, int maxLength)
        {
            Assert.IsFalse(instance.TryValidateProperty(null, memberName));

            Assert.IsFalse(instance.TryValidateProperty("", memberName));

            Assert.IsFalse(instance.TryValidateProperty(" ", memberName));

            Assert.IsTrue(instance.TryValidateProperty(
                new string('X', minLength), memberName));

            Assert.IsTrue(instance.TryValidateProperty(
                new string('X', maxLength), memberName));

            Assert.IsFalse(instance.TryValidateProperty(
                new string('X', minLength - 1), memberName));

            Assert.IsFalse(instance.TryValidateProperty(
                new string('X', maxLength + 1), memberName));
        }
    }
}
