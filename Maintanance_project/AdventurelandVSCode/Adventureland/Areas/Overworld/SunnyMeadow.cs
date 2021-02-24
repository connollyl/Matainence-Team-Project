/*
 * Implements the Sunny Meadow area
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using Adventureland.Text_Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   class SunnyMeadow : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public SunnyMeadow(Quest quest) : base(quest)
      {
         this.quest = quest;
         isDark = false;
         itemsInArea = new List<AdventurelandItems>();
      }

      public override bool GetDark()
      {
         return isDark;
      }

      public override string GetAreaName()
      {
         return "Meadow";
      }

      public override string GetAreaBio()
      {
         return "You're in a sunny meadow.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: South, East, West";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see: sleeping Dragon -";
         foreach (AdventurelandItems item in itemsInArea)
         {
            areaText += " " + Output.OutputInstance.FormatItemText(item) + " -";
         }
         areaText += " sign reads - IN SOME CASES MUD IS GOOD, IN OTHERS...";
         return areaText;
      }

      public override List<AdventurelandItems> GetAreaItems()
      {
         return itemsInArea;
      }

      public override void RemoveItem(AdventurelandItems item)
      {
         itemsInArea.Remove(item);
      }

      public override void AddItem(AdventurelandItems item)
      {
         itemsInArea.Add(item);
      }

      public override AdventurelandAreas GoDown()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Lake_Shore;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Dismal_Swamp;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Forest;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Sunny_Meadow;
      }

      public override void InitializeAreaItems() { }

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
