/*
* Class that controls the player's inventory
* @Author Eric, Cole, Evan, Logan, Sam
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   class Inventory
   {

      private List<AdventurelandItems> items;

      /*
       * The Constructor of the player's inventory
       */
      public Inventory()
      {
         items = new List<AdventurelandItems>();
      }

      /*
       * Gets the item from the player's inventory
       */
      public List<AdventurelandItems> GetItems()
      {
         return items;
      }

      /*
       * Add's the item passed in to the player's inventory
       */
      public void AddItem(AdventurelandItems item)
      {
         items.Add(item);
      }

      /*
       * Removes the item passed in from the player's inventory
       */
      public void RemoveItem(AdventurelandItems item)
      {
         items.Remove(item);
      }

   }
}
