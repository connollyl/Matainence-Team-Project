/*
 * Implements the Root Chamber area
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using Adventureland.Text_Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland.UndergroundAreas
{
   class RootChamber : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public RootChamber(Quest quest) : base(quest)
      {
         this.quest = quest;
         isDark = false;
         itemsInArea = new List<AdventurelandItems>();
         InitializeAreaItems();
      }

      public override bool GetDark()
      {
         return isDark;
      }

      public override string GetAreaName()
      {
         return "Root Chamber";
      }

      public override string GetAreaBio()
      {
         return "You're in a root chamber under the stump.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: Up, Down";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see: dark hole -";
         foreach (AdventurelandItems item in itemsInArea)
         {
            areaText += " " + Output.OutputInstance.FormatItemText(item) + " -";
         }
         areaText = areaText.TrimEnd('-');
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
         return AdventurelandAreas.Semi_Dark_Hole;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Stump;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Root_Chamber;
      }

      public override void InitializeAreaItems()
      {
         itemsInArea.Add(AdventurelandItems.Pot_Of_Rubies);
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
