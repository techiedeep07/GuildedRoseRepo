using GuildedRose.Model;
using GuildedRose.Repositories;
using NUnit.Framework;

namespace GuildedRoseTest
{
    [TestFixture]
    public class GuildedRoseItemTest
    {
        [Test]
        public void Test_NormalItem()
        {
            IList<Item> itemLst = new List<Item> { new Item { Name = "Cheddar", SellIn = 15, Quality = 10} };
            
            ItemInventory itemInventory = new ItemInventory(itemLst);

            itemInventory.Updation();

            Assert.AreEqual(14, itemLst[0].SellIn);
            Assert.AreEqual(9, itemLst[0].Quality);
        }
    }
}