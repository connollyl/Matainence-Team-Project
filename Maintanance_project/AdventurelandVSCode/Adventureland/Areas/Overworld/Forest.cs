/*
 * Implements the Forest area
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
   class Forest : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public Forest(Quest quest) : base(quest)
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
         return "Forest";
      }

      public override string GetAreaBio()
      {
         return "You're in a forest.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: North, East, South, West, Up";
      }

      public override string GetAreaText()
      {
         string areaText =  "You can also see: trees -";
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
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Sunny_Meadow;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Forest;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Forest;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Top_Of_Oak;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Forest;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Forest;
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
