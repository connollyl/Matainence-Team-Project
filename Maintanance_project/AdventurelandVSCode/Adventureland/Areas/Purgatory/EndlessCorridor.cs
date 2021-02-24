/*
 * Implements the Endless Corridor area
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using Adventureland.Text_Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland.StartHereafterAreas
{
   class EndlessCorridor : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public EndlessCorridor(Quest quest) : base(quest)
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
         return "Corridor";
      }

      public override string GetAreaBio()
      {
         return "You're in what appears to be a never ending corridor.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: North, East, South, West";
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

      public override AdventurelandAreas GoDown()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Endless_Corridor;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Endless_Corridor;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Large_Misty_Room;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Endless_Corridor;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Endless_Corridor;
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
