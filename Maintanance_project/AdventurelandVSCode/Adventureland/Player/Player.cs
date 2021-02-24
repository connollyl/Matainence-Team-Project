/*
* Class that controls and holds onto the player's inventory
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
   class Player
   {
      private Inventory inventory;

      /*
       * Constructor of the player that creates them an inventory
       */
      public Player()
      {
         inventory = new Inventory();
      }


      /*
       * Checks to see if the player has the item in their inventory
       */
      public bool HasItem(AdventurelandItems item)
      {
         List<AdventurelandItems> currInventory = inventory.GetItems();

         for (int i = 0; i < currInventory.Count; i++)
         {
            if (currInventory[i] == item)
            {
               return true;
            }
         }
         return false;
      }

      /*
       * Method used to check if the player's inventory is empty.
       */
      public bool HasEmptyInventory()
      {
         List<AdventurelandItems> currInventory = inventory.GetItems();
         if (currInventory.Count > 0)
         {
            return false;
         }
         else
         {
            return true;
         }
      }

      /*
       * Gets the item from the player's inventory
       */
      public List<AdventurelandItems> GetItems()
      {
         List<AdventurelandItems> currInventory = inventory.GetItems();
         return currInventory;
      }

      /*
       * Add's the item passed in to the player's inventory
       */
      public void GiveItem(AdventurelandItems item)
      {
         inventory.AddItem(item);
      }

      /*
       * Removes the item passed in from the player's inventory
       */
      public void RemoveItem(AdventurelandItems item)
      {
         inventory.RemoveItem(item);
      }
   }
}
