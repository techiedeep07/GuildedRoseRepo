using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Repositories
{
    public class ItemInventory : IItemInventory
    {
        #region Constants Declaration
        private const string AGEDBRIE = "Aged Brie";
        private const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        private const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        private const string CONJURED = "Conjured Mana Cake";
        #endregion

        #region variables
        public IList<Item> Items;
        #endregion

        public ItemInventory(IList<Item> Items)
        {
            this.Items = Items;
        }

        #region Item Updation 
        public void Updation()
        {
            try 
            {
                foreach (Item item in Items)
                {
                    PrintOutputBeforeUpdation(item.Name, item.SellIn, item.Quality);
                    switch (item.Name)
                    {
                        case AGEDBRIE:
                            item.SellIn--;
                            item.Quality++;

                            if (item.SellIn <= 0)
                            {
                                item.Quality++;
                            }
                            if (item.Quality > 50)
                            {
                                item.Quality = 50;
                            }
                            break;
                        case BACKSTAGE:
                            // to do
                            break;
                        case CONJURED:
                            // to do
                            break;
                        case SULFURAS:
                            // nothing to do as this is premium brand
                            break;
                        default:
                            item.SellIn--;
                            item.Quality--;

                            if (item.SellIn <= 0)
                            {
                                item.Quality--;
                            }

                            if (item.Quality < 0)
                            {
                                item.Quality = 0;
                            }
                            break;
                    }
                    PrintOutputAfterUpdation(item.Name, item.SellIn, item.Quality);
                }            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Item Updation :- " + ex.Message);
            }
        }
        #endregion

        private void PrintOutputBeforeUpdation(string itemName, int sellIn, int quality)
        {
            System.Console.WriteLine("Item details before updation : - Name :- {0}, Sellin :- {1}, Quantity :- {2}. ", itemName, sellIn, quality);
        }
        private void PrintOutputAfterUpdation(string itemName, int sellIn, int quality)
        {
            System.Console.WriteLine("Item details after updation : - Name :- {0}, Sellin :- {1}, Quantity :- {2}. ",itemName ,sellIn ,quality);
        }
    }
}
