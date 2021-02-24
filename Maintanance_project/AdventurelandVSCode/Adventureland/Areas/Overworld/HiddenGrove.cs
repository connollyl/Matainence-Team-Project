/*
 * Implements the Hidden Grove area
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
   class HiddenGrove : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public HiddenGrove(Quest quest) : base(quest)
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
         return "Grove";
      }

      public override string GetAreaBio()
      {
         return "You're in a hidden grove.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: North, East";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see: ";
         foreach (AdventurelandItems item in itemsInArea)
         {
            areaText += " " + Output.OutputInstance.FormatItemText(item) + " -";
         }
         areaText += " sign reads - PAUL'S PLACE";
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
         return AdventurelandAreas.Dismal_Swamp;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Forest;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoUp()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Hidden_Grove;
      }

      public override void InitializeAreaItems()
      {
         itemsInArea.Add(AdventurelandItems.Jeweled_Fruit);
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
