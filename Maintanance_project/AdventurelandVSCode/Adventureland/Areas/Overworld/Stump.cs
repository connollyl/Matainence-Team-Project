/*
 * Implements the Stump area
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
   class Stump : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public Stump(Quest quest) : base(quest)
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
         return "Inside Stump";
      }

      public override string GetAreaBio()
      {
         return "You're in a large hollow damp stump in the swamp.";
      }

      public override string GetObviousExits()
      {
         return "Obvious Exits: Up, Down";
      }

      public override string GetAreaText()
      {
         string areaText = "You can also see: sign reads- LEAVE TREASURE HERE -";
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
         if (Score.ScoreInstance.CheckIfTreasure(item))
            Score.ScoreInstance.SubFromScore();
      }

      public override void AddItem(AdventurelandItems item)
      {
         itemsInArea.Add(item);
         if (Score.ScoreInstance.CheckIfTreasure(item))
            Score.ScoreInstance.AddToScore();
      }

      public override AdventurelandAreas GoDown()
      {
         return AdventurelandAreas.Root_Chamber;
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
         return AdventurelandAreas.Dismal_Swamp;
      }

      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Invalid_Area;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Stump;
      }

      public override void InitializeAreaItems()
      {
         itemsInArea.Add(AdventurelandItems.Bottle);
         itemsInArea.Add(AdventurelandItems.Lamp);
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
