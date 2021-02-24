/*
 * Class that handles the inputted commands in the game
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Adventureland.Text_Controller
{

   //Used to get the user inputs and check for validty of the input
   class Input
   {
      private static string[] North = new string[] { "n", "north" };
      private static string[] East = new string[] { "e", "east" };
      private static string[] South = new string[] { "s", "south" };
      private static string[] West = new string[] { "w", "west" };
      private static string[] Up = new string[] { "u", "up" };
      private static string[] Down = new string[] { "d", "down" };
      private string input;

      /*
      * Method used to check if the inputted command is valid
      * @returns the command as a string when a valid one is entered
      */
      public List<string> GetUserInput()
      {
         String newWord = "";
         String[] words = { };
         List<string> final = new List<string>();

         try
         {
            while (final.Count == 0)
            {
               //Console.Write("Testing...Enter a string");
               input = Console.ReadLine().ToLower();

               //output.PrintInputText(input);

               words = input.Split(' ');

               for (int i = 0; i < words.Length; i++)
               {
                  if (words[i] != "")
                  {
                     final.Add(words[i]);
                  }
               }
               if (final.Count == 0)
               {
                  Output.OutputInstance.InvalidInput();
               }
            }

            if (final.Count > 2)
            {
               Output.OutputInstance.InvalidInput();
            }
            else
            {
               newWord = final[0].ToLower();

               if (newWord == "go")
               {
                  final.RemoveAt(0);
                  return final;
               }
            }
         }
         catch (Exception e)
         {
            Console.Write("Error: " + e);
         }
         return final; //returns the array of words
      }

      /*
      * Method used to see if the user wants to quit or restart the game 
      * @returns false if the game is over, or true if the game continues
      */
      public bool ProcessConfirmation()
      {
         string input;
         bool validInput = false;
         bool finished = false;
         while (finished == false)
         {
            try
            {
               input = Console.ReadLine().ToLower();
               validInput = CheckConfirmation(input);

               //if the command is not a yes or a no
               if (validInput != true)
               {
                  Output.OutputInstance.PrintConfirmationError();
               }
               else
               {
                  finished = true;
                  if (input == "y" || input == "yes")
                  {
                     return false;
                  }
                  else
                  {
                     return true;
                  }
               }
            }
            catch (Exception e)
            {
               Output.OutputInstance.PrintConfirmationError();
            }
            //return true;
         }
         return true;
      }

      //Method to check if the input is a valid answer to stay, quit, or restart
      private bool CheckConfirmation(string command)
      {
         switch (command)
         {
            case "y":
               return true;
            case "yes":
               return true;
            case "n":
               return true;
            case "no":
               return true;
            default:
               return false;
         }
      }

      //Checks to see if the command is a direction and it returns the direction string if true
      public Directions ValidDirection(string command)
      {
         char direction = command[0];
         //string test = Enum.GetName(typeof(Directions), North);
         switch (direction)
         {
            case 'n':
               foreach (string dir in North)
               {
                  if (command.Equals(dir))
                     return Directions.North;
               }
               return Directions.Invalid;
            case 'e':
               foreach (string dir in East)
               {
                  if (command.Equals(dir))
                     return Directions.East;
               }
               return Directions.Invalid;
            case 's':
               foreach (string dir in South)
               {
                  if (command.Equals(dir))
                     return Directions.South;
               }
               return Directions.Invalid;
            case 'w':
               foreach (string dir in West)
               {
                  if (command.Equals(dir))
                     return Directions.West;
               }
               return Directions.Invalid;
            case 'u':
               foreach (string dir in Up)
               {
                  if (command.Equals(dir))
                     return Directions.Up;
               }
               return Directions.Invalid;
            case 'd':
               foreach (string dir in Down)
               {
                  if (command.Equals(dir))
                     return Directions.Down;
               }
               return Directions.Invalid;
            default:
               return Directions.Invalid;
         }
      }

      //Checks if the command is a valid verb and returns a string if true
      //need to check if this foreach notation works with enums --found online (Would improve switch code in Directions)
      public Verbs ValidVerb(string command)
      {
         if (command.EndsWith("_"))
         {
            command = command.Remove(command.Length - 1, 1); //removes the appended _
         }

         foreach (Verbs verb in Enum.GetValues(typeof(Verbs)))
         {
            if (verb.ToString().ToLower() == command)
            {
               return verb;
            }
         }
         return Verbs.Invalid;
      }

      //Checks if the command is a valid item
      public AdventurelandItems ValidItem(string command)
      {
         command = command.Remove(command.Length - 1, 1); //removes the appended _

         foreach (AdventurelandItems item in Enum.GetValues(typeof(AdventurelandItems)))
         {
            if (item.ToString().ToLower() == command)
            {
               return item;
            }
         }
         return AdventurelandItems.Invalid;
      }

      //Checks to see if the input was a shortcut after the full item name failed.
      public AdventurelandItems CheckShortCut(String noun)
      {
         noun = noun.Remove(noun.Length - 1, 1); //removes the appended _

         foreach (ShortCuts shorts in Enum.GetValues(typeof(ShortCuts)))
         {
            if(shorts.ToString().ToLower() == noun)
            {
               switch (shorts)
               {
                  case ShortCuts.Bees:
                     return AdventurelandItems.Bottle_Of_Bees;
                  case ShortCuts.Fish:
                     return AdventurelandItems.Golden_Fish;
                  case ShortCuts.Net:
                     return AdventurelandItems.Golden_Net;
                  case ShortCuts.Crown:
                     return AdventurelandItems.Golden_Crown;
                  case ShortCuts.Honey:
                     return AdventurelandItems.Royal_Honey;
                  case ShortCuts.Mirror:
                     return AdventurelandItems.Magic_Mirror;
                  case ShortCuts.Keys:
                     return AdventurelandItems.Skeleton_Keys;
                  case ShortCuts.Ring:
                     return AdventurelandItems.Diamond_Ring;
                  case ShortCuts.Bracelet:
                     return AdventurelandItems.Diamond_Bracelet;
                  case ShortCuts.Rug:
                     return AdventurelandItems.Persian_Rug;
                  case ShortCuts.Gas:
                     return AdventurelandItems.Swamp_Gas;
                  case ShortCuts.Flint:
                     return AdventurelandItems.Flint_And_Stone;
                  case ShortCuts.Oil:
                     return AdventurelandItems.Slime_Oil;
                  case ShortCuts.Fruit:
                     return AdventurelandItems.Jeweled_Fruit;
                  case ShortCuts.Ox:
                     return AdventurelandItems.Blue_Ox_Statue;
                  case ShortCuts.Rubies:
                     return AdventurelandItems.Pot_Of_Rubies;
                  case ShortCuts.Egg:
                     return AdventurelandItems.Dragon_Eggs;
                  default:
                     return AdventurelandItems.Invalid;
               }
            }
         }
         return AdventurelandItems.Invalid;
      }
   }
}
