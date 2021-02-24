/*
 * Implements the Dismal Swamp area
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
   class DismalSwamp : Area
   {
      private Quest quest;
      private bool isDark;
      private List<AdventurelandItems> itemsInArea;

      public DismalSwamp(Quest quest) : base(quest)
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
         return "Dismal Swamp";
      }
      public override string GetAreaBio()
      {
         return "You're in a dismal swamp.";
      }

      public override string GetObviousExits()
      {
         if(AreaEvent.AreaEventInstance.CypressCutDown)
         {
            return "Obvious Exits: North, East, South, West, Down";
            
         }
         else
         {
            return "Obvious Exits: North, East, South, West, Up";
         }
      }

      public override string GetAreaText()
      {
         string areaText;
         if (AreaEvent.AreaEventInstance.CypressCutDown)
         {
            areaText = "You can also see: ";
         }
         else
         {
            areaText = "You can also see: cypress tree -";
         }
         foreach (AdventurelandItems item in itemsInArea)
         {
            areaText += " " + Output.OutputInstance.FormatItemText(item) + " -";
         }
         areaText += " chiggers";

         Random Random = new Random();
         int ChiggerCheck = Random.Next(1, 6);
         if (ChiggerCheck == 1 && AreaEvent.AreaEventInstance.MudApplied == false)
         {
            AreaEvent.AreaEventInstance.ChiggerBite = true;
            areaText += "\nYou were bitten by chiggers!!";
         }
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
         if (AreaEvent.AreaEventInstance.CypressCutDown)
         {
            return AdventurelandAreas.Stump;
         }
         else
         {
            return AdventurelandAreas.Invalid_Area;
         }
      }

      public override AdventurelandAreas GoEast()
      {
         return AdventurelandAreas.Edge_Of_Big_Hole;
      }

      public override AdventurelandAreas GoNorth()
      {
         return AdventurelandAreas.Sunny_Meadow;
      }

      public override AdventurelandAreas GoSouth()
      {
         return AdventurelandAreas.Dismal_Swamp;
      }

      public override AdventurelandAreas GoUp()
      {
         if (AreaEvent.AreaEventInstance.CypressCutDown)
         {
            return AdventurelandAreas.Invalid_Area;
         }
         else
         {
            return AdventurelandAreas.Top_Of_Cypress;
         }
      }
         
      public override AdventurelandAreas GoWest()
      {
         return AdventurelandAreas.Hidden_Grove;
      }

      public override AdventurelandAreas GetAreaIdentifier()
      {
         return AdventurelandAreas.Dismal_Swamp;
      }

      public override void InitializeAreaItems()
      {
         itemsInArea.Add(AdventurelandItems.Mud);
         itemsInArea.Add(AdventurelandItems.Swamp_Gas);
         itemsInArea.Add(AdventurelandItems.Slime_Oil);
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
