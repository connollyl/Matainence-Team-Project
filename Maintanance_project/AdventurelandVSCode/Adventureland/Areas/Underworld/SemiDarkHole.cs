/*
 * Implements the Semi Dark Hole area
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
   class SemiDarkHole : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public SemiDarkHole(Quest quest) : base(quest)
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
         return "Hole";
      }

      public override string GetAreaBio()
      {
         return "You're in a semi-dark hole by the root chamber.";
      }

      public override string GetObviousExits()
      {
         if (AreaEvent.AreaEventInstance.SemiDarkHoleDoorUnlocked)
         {
            return "Obvious Exits: Up, Down";
         }
         else
         {
            return "Obvious Exits: Up";
         }
      }

      public override string GetAreaText()
      {
         string areaText;

         if (AreaEvent.AreaEventInstance.SemiDarkHoleDoorUnlocked)
         {
            areaText = "You can also see: open door with a hallway beyond";
         }
         else
         {
            areaText = "You can also see: locked door -";
         }
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
         if (AreaEvent.AreaEventInstance.SemiDarkHoleDoorUnlocked)
         {
            return AdventurelandAreas.Long_Downsloping_Hallway;
         }
         else 
         {
            return AdventurelandAreas.Invalid_Area;
         }
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
         return AdventurelandAreas.Root_Chamber;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Semi_Dark_Hole;
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
