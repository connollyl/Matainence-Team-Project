/*
* Class that handles the control flow of the game
* @Author Eric, Cole, Evan, Logan, Sam
*/
using Adventureland.Text_Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Adventureland
{
   class QuestManager
   {
      private Area previousArea;
      private Area currentArea;
      private Quest quest;
      private Input input;
      private CmdProcessor processor;
      private List<string> cmd = new List<string>();
      private string noun;
      private bool gameInProgress = true;
      private bool quit = false;
      private bool restart = false;
      bool singleVerb = false;
      private Area checkIfAreaChanged = null;
      private const int CHIGGER_COUNT = 20;
      private const int WINNING_NUMBER = 13;

      public QuestManager()
      {
         quest = new Quest();
         input = new Input();
         processor = new CmdProcessor();
         currentArea = quest.GetArea(quest.GetStartingArea());
         previousArea =  quest.GetArea(AdventurelandAreas.Large_Misty_Room);
      }

      /*
      * Game Controller that handles the execution of game logic
      */
      public void NewQuest()
      {
         while (gameInProgress)
         {
            while (!quit && !restart && gameInProgress)
            {
               DisplayAreaText();
               Output.OutputInstance.NewLine();
               cmd = input.GetUserInput();

               Directions direct = input.ValidDirection(cmd[0]);

               if (!direct.Equals(Directions.Invalid))
               {
                  //Special check for when entering the long D hallway into darkness and returnign safely from the darkness. Otherwsie, darkness sends to misty room.
                  if (!AreaEvent.AreaEventInstance.LampOn && previousArea.GetAreaIdentifier().Equals(AdventurelandAreas.Long_Downsloping_Hallway) && direct.Equals(Directions.Up))
                  {
                     previousArea = currentArea;
                     currentArea = quest.GetArea(AdventurelandAreas.Semi_Dark_Hole);
                  }
                  else
                  {
                     previousArea = currentArea;
                     currentArea = quest.GetArea(processor.ProcessDirection(direct, currentArea));
                  }
                  
                  if (currentArea == null)
                  {
                     Output.OutputInstance.InvalidArea();
                     currentArea = previousArea;
                  }
                  else if (AreaEvent.AreaEventInstance.LampOn)
                  {
                     AreaEvent.AreaEventInstance.LampCount = AreaEvent.AreaEventInstance.LampCount - 1;
                     if (LampDarknessCheck(currentArea))
                     {
                        currentArea = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
                     }
                     else if(AreaEvent.AreaEventInstance.LampCount == 0)
                     {
                        Output.OutputInstance.LampOutOfEnergy();
                        AreaEvent.AreaEventInstance.LampOn = false;
                     }
                  }
               }
               else
               {
                  Verbs verb = input.ValidVerb(cmd[0]);
                  if (verb.Equals(Verbs.Restart))
                  {
                     restart = true;
                     Output.OutputInstance.PrintRestart();
                     Output.OutputInstance.NewLine();
                  }
                  else if (verb.Equals(Verbs.Quit))
                  {
                     quit = true;
                     Output.OutputInstance.PrintQuit();
                     Output.OutputInstance.NewLine();
                  }
                  else if (!verb.Equals(Verbs.Invalid))
                  {
                     singleVerb = IsSingleVerbCommand(verb);

                     noun = "";

                     if (!singleVerb)
                     {
                        for (int i = 1; i < cmd.Count; i++)
                        {
                           noun += cmd[i] + "_";
                        }
                     }

                     if (noun.Length > 0 || singleVerb)
                     {
                        AdventurelandItems item;
                        Verbs verb2;

                        if (noun.Length > 0)
                        {
                           item = input.ValidItem(noun); //removes the last appendeed _
                           if (item.Equals(AdventurelandItems.Invalid) || (item.Equals(AdventurelandItems.Bees) && AreaEvent.AreaEventInstance.BeesRemoved))
                           {
                              item = input.CheckShortCut(noun);
                           }
                           verb2 = input.ValidVerb(noun);
                        }
                        else
                        {
                           item = AdventurelandItems.Invalid;
                           verb2 = Verbs.Invalid;
                        }

                        if (!item.Equals(AdventurelandItems.Invalid) || !verb2.Equals(Verbs.Invalid) || singleVerb)
                        {
                           checkIfAreaChanged = currentArea;

                           processor.ProcessVerb(verb, verb2, item, ref currentArea, quest);

                           if(checkIfAreaChanged != currentArea)
                           {
                              previousArea = checkIfAreaChanged;
                           }
                        }
                        else
                        {
                           Output.OutputInstance.InvalidCommand();
                        }
                     }
                     else if(verb.Equals(Verbs.Help))
                     {
                        processor.DoHelp();
                     }
                     else if (verb.Equals(Verbs.Score))
                     {
                        processor.DoScore();
                     }
                     else if(verb.Equals(Verbs.UWU))
                     {
                        Output.OutputInstance.UWU();
                     }
                     else 
                     {
                        Output.OutputInstance.InvalidCommand();
                     
                     }
                  }
                  else
                  {
                     Output.OutputInstance.InvalidCommand();
                  }
               }
               if (!AreaEvent.AreaEventInstance.LampOn && currentArea.GetDark())
               {
                  previousArea = currentArea;
                  currentArea = quest.GetArea(AdventurelandAreas.Darkness);
               }
               else if (AreaEvent.AreaEventInstance.LampOn && currentArea.Equals(quest.GetArea(AdventurelandAreas.Darkness)))
               {
                  currentArea = previousArea;
               }
               if (AreaEvent.AreaEventInstance.ChiggerBite && !AreaEvent.AreaEventInstance.MudApplied)
               {
                  if (AreaEvent.AreaEventInstance.ChiggerCount == 0)
                  {
                     Output.OutputInstance.ChiggerKilledPlayer();
                     currentArea = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
                     AreaEvent.AreaEventInstance.ChiggerBite = false;
                     AreaEvent.AreaEventInstance.ChiggerCount = CHIGGER_COUNT;
                  }
                  else
                     AreaEvent.AreaEventInstance.ChiggerCount--;
               }
               else if (AreaEvent.AreaEventInstance.MudApplied)
               {
                  AreaEvent.AreaEventInstance.ChiggerBite = false;
                  AreaEvent.AreaEventInstance.ChiggerCount = CHIGGER_COUNT;
               }
               if (Score.ScoreInstance.ScoreValue >= WINNING_NUMBER)
               {
                  gameInProgress = false;
                  Output.OutputInstance.ScoreOutput();
               }
            }
            gameInProgress = input.ProcessConfirmation();

            if (gameInProgress == true)
            {
               ResumeGame();
            }
         }
      }

      /*
       * Checks if the lamp runs out of power and the player is in the darkness.
       */
      private bool LampDarknessCheck(Area currentArea)
      {
         if (AreaEvent.AreaEventInstance.LampCount < 1 && currentArea.GetDark())
         {
            Output.OutputInstance.LampOutOfEnergyInDarkness();
            AreaEvent.AreaEventInstance.LampOn = false;
            return true;
         }
         return false;
      }

      /*
      * Method that displays the text when entering an area
      */
      private void DisplayAreaText()
      {
         Output.OutputInstance.PrintAreaName(currentArea.GetAreaName());
         Output.OutputInstance.PrintAreaBio(currentArea.GetAreaBio());
         if (previousArea != currentArea)
         {
            Output.OutputInstance.PrintAreaExits(currentArea.GetObviousExits());
         }
         Output.OutputInstance.PrintAreaText(currentArea.GetAreaText());
      }

      /*
      * Method to reset the quit and restart.
      */
      private void ResumeGame()
      {
         quit = false;
         restart = false;
         Output.OutputInstance.NewLine();
      }

      /*
      * Method to reset the quit and restart.
      */
      private bool IsSingleVerbCommand(Verbs verb)
      {
         if(verb.Equals(Verbs.Swim) || verb.Equals(Verbs.Bunyon) || verb.Equals(Verbs.Jump) || verb.Equals(Verbs.Release)
            || verb.Equals(Verbs.Away) || verb.Equals(Verbs.Suicide) || verb.Equals(Verbs.Inventory))
         {
            return true;
         }
         else
         {
            return false;
         }
      }
   }
}
