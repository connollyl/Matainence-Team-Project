/*
* Class that handles the control flow of the game
* @Author Eric, Cole, Evan, Logan, Sam
*/
using System;
using System.Collections.Generic;
using Adventureland.Text_Controller;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland.Areas.Underworld
{
   class Darkness : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public Darkness(Quest quest) : base(quest)
      {
         this.quest = quest;
         isDark = false;
         itemsInArea = new List<AdventurelandItems>();
      }

      public override bool GetDark()
      {
         return isDark;
      }

      public override void AddItem(AdventurelandItems item)
      {
         itemsInArea.Add(item);
      }

      public override string GetAreaBio()
      {
         return "It is pitch dark, and you can't see a thing.";
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Darkness;
      }

      public override List<AdventurelandItems> GetAreaItems()
      {
         return itemsInArea;
      }

      public override string GetAreaName()
      {
         return "Darkness";
      }

      public override string GetAreaText()
      {
         string areaText = "If you continue, you will likely fall into a pit.";
         return areaText;
      }

      public override string GetObviousExits()
      {
         return "";
      }

      public override AdventurelandAreas GoDown()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override void InitializeAreaItems() { }

      public override void RemoveItem(AdventurelandItems item)
      {
         itemsInArea.Remove(item);
      }

      public override bool HasItem(AdventurelandItems item)
      {
         List<AdventurelandItems> currItems = itemsInArea;

         for (int i = 0; i < currItems.Count; i++)
         {
            if (currItems[i] == item)
            {
               return true;
            }
         }
         return false;
      }
   }
}