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

        [TestMethod]
        public void WorksWithEmptyInventory()
        {
            var repo = new MockItemRepository();
            repo.Clear();
            var data = repo.GetInventory();

            Assert.IsNotNull(data);
            Assert.IsTrue(data.Count == 0);
        }

        [TestMethod]
        public void GetItems_ReturnsExpectedProducts()
        {
            var repo = new MockItemRepository();
            var items = repo.GetInventory();

            Assert.IsNotNull(items);
            Assert.IsTrue(items.Exists(i => i.Name == "ChickenSoup"));
            Assert.IsTrue(items.Exists(i => i.Name == "Caeser"));
            Assert.IsTrue(items.Exists(i => i.Name == "TunaMelt"));
            Assert.IsTrue(items.Exists(i => i.Name == "SweetFries"));
        }
    }
}
