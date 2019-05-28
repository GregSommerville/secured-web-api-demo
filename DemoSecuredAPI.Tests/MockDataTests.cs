using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DemoSecuredAPI.Tests
{
    [TestClass]
    public class MockDataTests
    {
        [TestMethod]
        public void MockDataWasInitialized()
        {
            var repo = new MockItemRepository();
            var data = repo.GetInventory();

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count == 4);
        }
    }
}
