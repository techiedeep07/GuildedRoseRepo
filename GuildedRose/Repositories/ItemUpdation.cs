using GuildedRose.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildedRose.Repositories
{
    public class ItemUpdation : IItemUpdation
    {
        public IList<Item> Items;

        public ItemUpdation(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void Updation()
        {
            try 
            {
                // To do logic for item updation
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Item Updation :- " + ex.Message);
            }
        }
    }
}
