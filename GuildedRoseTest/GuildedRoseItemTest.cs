using GuildedRose.Model;
using GuildedRose.Repositories;
using NUnit.Framework;

namespace GuildedRoseTest
{
    [TestFixture]
    public class GuildedRoseItemTest
    {

        private Item ItemAddAndupdate(string itemName, int sellIn, int quality)
        {
            IList<Item> itemLst = new List<Item> { new Item { Name = itemName, SellIn = sellIn, Quality = quality } };
            ItemInventory itemInventory = new ItemInventory(itemLst);
            itemInventory.Updation();
            return itemLst.FirstOrDefault();
        }

        [Test]
        public void Test_ItemSellInAndQualityDecreaseNormal()
        {
            Item item = ItemAddAndupdate("Cheddar",15,10);
            Assert.AreEqual(14, item.SellIn);
            Assert.AreEqual(9, item.Quality);
        }

        [Test]
        public void Test_ItemSellInDatePassQualityDecreaseTwice()
        { 
            Item item = ItemAddAndupdate("Cheddar", 0, 10);
            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        public void Test_ItemQualityNeverNegative()
        {
            Item item = ItemAddAndupdate("Cheddar", 10, 0);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void Test_Item_AgedBrie_QualityIncreaseOnOlder()
        {
            Item item = ItemAddAndupdate("Aged Brie", 10, 15);
            Assert.AreEqual(16, item.Quality);
        }

        [Test]
        public void Test_ItemQualityMax50()
        {
            Item item = ItemAddAndupdate("Aged Brie", 10, 50);
            Assert.AreEqual(50, item.Quality);
        }

        [Test]
        public void Test_Item_Sulfuras_NeverSoldNeverQuanityDecrease()
        {
            Item item = ItemAddAndupdate("Sulfuras", 21,80);
            Assert.AreEqual(21, item.SellIn);
            Assert.AreEqual(80, item.Quality);
        }

        [Test]
        public void Test_Item_Backstagepasses_QualityIncreaseOnOlder()
        {
            Item item = ItemAddAndupdate("Backstage passes", 20, 25);
            Assert.AreEqual(26, item.Quality);
        }

        [Test]
        public void Test_Item_BackstagepassesSellinIs10_QualityIncreaseBy2()
        {
            Item item = ItemAddAndupdate("Backstage passes", 10, 15);
            Assert.AreEqual(17, item.Quality);
        }

        [Test]
        public void Test_Item_BackstagepassesSellinIs5_QualityIncreaseBy3()
        {
            Item item = ItemAddAndupdate("Backstage passes", 5, 15);
            Assert.AreEqual(18, item.Quality);
        }

        [Test]
        public void Test_Item_BackstagepassesSellinPass_QualityDropZero()
        {
            Item item = ItemAddAndupdate("Backstage passes", 0, 15);
            Assert.AreEqual(0, item.Quality);
        }

        [Test]
        public void Test_Item_Conjured_QualityDecreaseTwice()
        {
            Item item = ItemAddAndupdate("Conjured", 8, 15);
            Assert.AreEqual(13, item.Quality);
        }
    }
}