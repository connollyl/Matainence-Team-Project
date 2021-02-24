/*
 * Implements the Large Cavern area
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
   class LargeCavern : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public LargeCavern(Quest quest) : base(quest)
      {
         this.quest = quest;
         isDark = true;
         itemsInArea = new List<AdventurelandItems>();
      }

      public override bool GetDark()
      {
         return isDark;
      }

      public override string GetAreaName()
      {
         return "Cavern";
      }

      public override string GetAreaBio()
      {
         return "You're in a large cavern.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: North, South, West, Up, Down";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see:";
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

      public override void InitializeAreaItems()
      {
      }

      public override AdventurelandAreas GoDown()
      {
         //TO MAZE //needs to be implmented.
         return AdventurelandAreas.Entrance;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Long_Tunnel;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Royal_Anteroom;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Long_Downsloping_Hallway;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Memory_Chip;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Large_Cavern;
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
