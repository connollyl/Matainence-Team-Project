/*
 * Implements the Lake Shore area
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using Adventureland.Text_Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland.AboveGroundAreas
{
   class LakeShore : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public LakeShore(Quest quest) : base(quest)
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
         return "Lakeside";
      }

      public override string GetAreaBio()
      {
         return "You're on the shore of a lake.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: North, South, West.";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see: water -";
         foreach (AdventurelandItems item in itemsInArea)
         {
            areaText += " " + Output.OutputInstance.FormatItemText(item) + " -";
         }
         areaText += " sign reads - NO SWIMMING ALLOWED";
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
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Quicksand;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Edge_Of_Big_Hole;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Sunny_Meadow;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Lake_Shore;
      }

      public override void InitializeAreaItems()
      {
         itemsInArea.Add(AdventurelandItems.Golden_Fish);
         itemsInArea.Add(AdventurelandItems.Axe);
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
