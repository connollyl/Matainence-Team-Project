/*
 * Class that handles the outputed messages in Adventureland
 * @Author Eric, Cole, Evan, Logan, Sam
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland.Text_Controller
{
   /// <summary>
   /// This class manages the outputted messages
   /// </summary>
   public sealed class Output
   {
      string bar = "--------------------------------------------------";
      Output() { }
      private static Output instance = null;

      public static Output OutputInstance
      {
         get
         {
            if (instance == null)
            {
               instance = new Output();
            }
            return instance;
         }
      }

      /*
       * Prints the Area's name
       */
      public void PrintAreaName(String area)
      {
         Console.Write(area + "\n");
      }

      /*
       * Prints the Area's bio
       */
      public void PrintAreaBio(String bio)
      {
         Console.Write(bio + "\n");
      }

      /*
       * Prints the available exits for an area
       */
      public void PrintAreaExits(String exits)
      {
         Console.Write(exits + "\n");
      }

      /*
       * Prints the Area's bio text
       */
      public void PrintAreaText(String areaText)
      {
         Console.Write(areaText + "\n");
      }

      /*
       * Prints the quit message
       */
      public void PrintQuit()
      {
         Console.Write("Are you sure you want to exit?" + "\n");
      }

      /*
       * Prints the restart message
       */
      public void PrintRestart()
      {
         Console.Write("Are you sure you want to restart?" + "\n");
      }

      /*
       * Prints the required confirmation to quit or restart a game
       */
      public void PrintConfirmationError()
      {
         Console.Write("Please answer yes or no." + "\n");
      }

      /*
       * Prints the required confirmation to quit or restart a game
       */
      public void InvalidVerb()
      {
         Console.Write("That's not a verb I recognise." + '\n');
      }

      /*
       * Prints out the input was invalid
       */
      public void InvalidInput()
      {
         Console.Write("That's an invalid input. Please use: [Direction] or [Noun] [Action]" + '\n');
      }

      /*
       * Prints out the exact input originally typed
       */
      public void PrintInputText(String input)
      {
         Console.Write(input + '\n');
      }

      /*
       * Prints out if the area is invalid
       */
      public void InvalidArea()
      {
         Console.Write("You can't go that way." + '\n');
      }

      /*
       * Prints out if the command is invalid
       */
      public void InvalidCommand()
      {
         Console.Write("Invalid Command." + '\n');
      }

      /*
      * Prints out if the area is invalid
      */
      public void NewLine()
      {
         Console.Write('\n');
      }

      /*
      * Prints out when the game has been won
      */
      public void printWin()
      {
         Console.Write("Congratulations you have slain the Dragon!!!" + "\n");
      }

      /*
      * Prints out the item that has picked up
      */
      public void PickedUp(AdventurelandItems item)
      {
         Console.Write("You picked up: " + item.ToString() + "\n");
      }

      /*
      * Prints out what item has been dropped
      */
      public void Dropped(AdventurelandItems item)
      {
         Console.Write("You dropped: " + item.ToString() + "\n");
      }

      /*
      * Prints out when the tree has been cut down
      */
      public void TreeCutDown()
      {
         Console.Write("TIMBER..." + '\n');
      }

      /*
      * Prints out that an item has disappeared if not picked up before cutting down the tree
      */
      public void CypressKeyMissed()
      {
         Console.Write("TIMBER... Something fell from the treetop and vanished!" + '\n');
      }

      /*
      * Prints out when the tree has been cut down
      */
      public void TreeAlreadyCut()
      {
         Console.Write("The tree has already been cut down." + '\n');
      }

      /*
      * Prints out that an axe is needed
      */
      public void AxeRequired()
      {
         Console.Write("You do not have an axe." + '\n');
      }

      /*
      * Prints out that the action cannot be done in this area
      */
      public void InvalidAreaAction()
      {
         Console.Write("You cannot do that here." + '\n');
      }

      /*
      * Prints out that the item does no exist here
      */
      public void InvalidTakeItem()
      {
         Console.Write("That item does not seem to be here." + '\n');
      }

      /*
      * Prints out that the player does not have the item being dropped
      */
      public void InvalidDropItem()
      {
         Console.Write("You do not have possesion of that item." + '\n');
      }

      /*
      * Prints out that the player has unlocked the door
      */
      public void UnlockDoor()
      {
         Console.Write("You open the open door with a hallway beyond." + '\n');
      }

      /*
      * Prints out that the player has unlocked the door
      */
      public void KeyRequired()
      {
         Console.Write("You need a key to unlock this door." + '\n');
      }

      /*
      * Prints out that the player has unlocked the door
      */
      public void InvalidKeyAction()
      {
         Console.Write("There appears to be nothing to use the key on here." + '\n');
      }

      /*
      * Prints out that the player does not have a key
      */
      public void InvalidKeyRequired()
      {
         Console.Write("You do not possess a key." + '\n');
      }


      /*
      * Prints out that the axe has lost its ability to bunyon
      */
      public void BunyonFailed()
      {
         Console.Write("Nothing appears to have happened." + '\n');
      }

      /*
      * Prints out that the axe has used its special ability
      */
      public void BunyonSuccessful()
      {
         Console.Write("The axe lets out a might roar, BUNYON!!!" + '\n');
      }

      /*
      * Prints out that the player is holding onto to many items
      * The player needs an empty inventory to swim
      */
      public void PlayerOverweight()
      {
         Console.Write("You try to swim but the objects weigh you down." + '\n');
      }

      /*
      * Prints out that swimming is invalid at the current area.
      */
      public void SwimFailed()
      {
         Console.Write("This is not the time nor place to take a swim!" + '\n');
      }

      /*
      * Prints out that swimming is invalid at the current area.
      */
      public void SwimSuccessful()
      {
         Console.Write("With caution, you slowly maneuver yourself out of the quicksand." + '\n');
      }

      /*
      * Prints out that the player does not possess a lamp
      */
      public void RubFailed()
      {
         Console.Write("What lamp? You do not appear to be carrying one." + '\n');
      }

      /*
      * Prints out that the player rubbed the lamp without the slime_oil collected
      */
      public void RubWithoutOil()
      {
         Console.Write("The lamp looks slightly cleaner than before! " + '\n');
      }

      /*
      * The first time the player rubs the lamp
      */
      public void FirstRub()
      {
         Console.Write("A glowing geanie appears and gives you a diamond ring - then vanishes" + '\n');
      }

      /*
      * The second time the player rubs the lamp
      */
      public void SecondRub()
      {
         Console.Write("A glowing geanie appears and gives you a diamond bracelet - then vanishes" + '\n');
      }

      /*
      * The third and fourth time the player rubs the lamp
      */
      public void ThirdAndFourthRub()
      {
         Console.Write("A glowing geanie appears and snaps his fingers - then vanishes - You feel as though is something is missing" + '\n');
      }

      /*
      * The fifth time the player rubs the lamp
      */
      public void FifthRub()
      {
         Console.Write("A glowing geanie appears and snaps his fingers - You feel as though your soul has dissapeared." + '\n');
      }

      /*
      * Outputs that there is no oil in the area
      */
      public void NoOilFound()
      {
         Console.Write("There does not appear to be any oil laying around." + '\n');
      }

      /*
      * Outputs that there is no oil in the area
      */
      public void NoLampAvailable()
      {
         Console.Write("You do not have anything useful to collect the oil with." + '\n');
      }

      /*
      * Outputs that the oil has been collected
      */
      public void OilSuccessfullyCollected()
      {
         Console.Write("You crouch down and collect the oil in the lamp." + '\n'
                        + "Just like the United States did in operation Desert Storm in Kuwait." + '\n');
      }

      /*
      * Outputs that the oil has already been collected
      */
      public void OilAlreadyCollected()
      {
         Console.Write("The lamp is already full of oil." + '\n');
      }

      /*
      * Outputs that you do not ahve a bottle of bees
      */
      public void InvalidRelease()
      {
         Console.Write("You do not have any bees to release." + '\n');
      }

      /*
      * Outputs the bees have been released - bas choice if not in sunny meadows
      */
      public void BeesReleaseWasted()
      {
         Console.Write("You open the bottle and the bees fly free - They swarm off into the distance." + '\n');
      }

      /*
      * Outputs the bees have been released - bas choice if not in sunny meadows
      */
      public void BeesReleaseUseful()
      {
         Console.Write("You open the bottle and the bees fly free - They swarm off into the distance and sting the sleeping dragon." + '\n'
                        + "With a fierce roar, the drgaon dissapears into the sky." + '\n');
      }

      /*
      * Outputs the words you say into the area - nothing happens
      */
      public void SayToYourself()
      {
         Console.Write("(To yourself)" + '\n' + "There is no reply." + '\n');
      }

      /*
      * Outputs the words you say startle the bear and kill it
      */
      public void SayToBear()
      {
         Console.Write("(to the thin black bear)" + '\n' + "The bear got startled and fell off the ledge!" + '\n');
      }

      /*
      * Outputs that you ahve already startled the bear
      */
      public void InvalidSayToBear()
      {
         Console.Write("(to where the bear once wondered)" + '\n');
      }

      /*
      * Switches the lamp off if it is on
      */
      public void ExtinquishLamp()
      {
         Console.Write("You switch the old fashioned lamp off." + '\n');
      }

      /*
      * Switches the lamp off if it is on
      */
      public void LampNeedsOil()
      {
         Console.Write("The lamp is empty, there is nothing to ignite." + '\n');
      }

      /*
      * Switches the lamp off if it is on
      */
      public void LampAlreadyOff()
      {
         Console.Write("The old fashioned lamp has already been extinquished." + '\n');
      }

      /*
      * Cover yourself in mud to prevent the bees from stinking and dragon smelling you
      */
      public void MudApplied()
      {
         Console.Write("You lay down roll around in the mud, it reminds you of your childhood." + '\n');
      }

      /*
      * The mud has already been applied.
      */
      public void MudAlreadyApplied()
      {
         Console.Write("You are already masking your scent with mud." + '\n');
      }

      /*
      * There is no mud to be found
      */
      public void MudNotFound()
      {
         Console.Write("There does not appear to be any mud around here." + '\n');
      }

      /*
      * The fish has already been captured on not in the area
      */
      public void FishNotFound()
      {
         Console.Write("There does not appear to be any fish around here." + '\n');
      }

      /*
      * Player needs a fishing net to capture the fish
      */
      public void FishingNetRequired()
      {
         Console.Write("You lunge out and try to scoop up the golden fish, it was a fruitless attempt." + '\n'
                        + "Maybe you should try finding a net" + '\n');
      }

      /*
      * The fish has already been captured on not in the area
      */
      public void FishCaptured()
      {
         Console.Write("With one fell swoop of the golden net, you manage to capture the golden fish." + '\n');
      }

      /*
      * If the rug was used in West Two
      */
      public void RugUsed()
      {
         Console.Write("The Rug encases you and daylight appears!" + '\n');
      }

      /*
      * Says the the ug is required to use the command
      */
      public void RugRequired()
      {
         Console.Write("Alladin's rug appears to be missing." + '\n');
      }

      /*
      * The player needs a rug to use the command, and be in the West Two in the maze
      */
      public void RugAttemptFailed()
      {
         Console.Write("Nothing seems to have happened." + '\n');
      }

      /*
      * Successfully made the jump
      */
      public void JumpSuccessful()
      {
         Console.Write("You take a leap of faith across chasm! You landed successfully" + '\n');
      }

      /*
      * The bear kills you if you go for the mirror while the bear is alive
      */
      public void MirrorBearDeath()
      {
         Console.Write("As you reach for the mirror, the bears unleashes a mighty roar and mauls you!" + '\n');
      }

      /*
      * Takes the mirror if the bear is dead
      */
      public void MirrorTakenSuccessfully()
      {
         Console.Write("You grab the mirror, rip the guardian bear. "+ '\n');
      }

      /*
      * If the rug was used in West Two
      */
      public void JumpInPlace()
      {
         Console.Write("You jump in place fruitlessly." + '\n');
      }

      /*
      * There are no bees around here
      */
      public void BeesNotFound()
      {
         Console.Write("There do not appear to be any bees around here." + '\n');
      }

      /*
      * Successfully capturing the bees
      */
      public void BeesCaptured()
      {
         Console.Write("With patience, you wait for the bees to go inside the bottle and seal it off." + '\n');
      }

      /*
      * Trying to catch the bees without a bottle
      */
      public void BeesCaptureFailed()
      {
         Console.Write("You agitate the bees the bees you try and grab them with your hands." + '\n' 
                        + "It was a fruitless attempt as the bees swarm and kill you." + '\n');
      }
      
      /*
      * The bees smell you and attack.
      */
      public void BeesSmellYou()
      {
         Console.Write("As you go about your activity, the bees smell your scent and attack you." + '\n');
      }

      /*
      * Successfully collecting the honey in the large eight sided room
      */
      public void HoneyCollected()
      {
         Console.Write("You reach out take the honey, it wasn't so diffficult after all." + '\n');
      }

      /*
      * No honey in the area
      */
      public void HoneyNotFound()
      {
         Console.Write("There do not appear to be any honey around here." + '\n');
      }

      /*
      * Mirror safely dropped
      */
      public void MirrorDroppedSafely()
      {
         Console.Write("You place the magic mirror upon the persian rug, it looks beautiful." + '\n');
      }

      /*
      * Mirror broken
      */
      public void MirrorDroppedAndBroke()
      {
         Console.Write("The magic mirror shatters upon placing it on the cold, hard ground." + '\n');
      }

      /*
      * Dragon Egg spawned
      */
      public void EggSpawned()
      {
         Console.Write("As the dragon flies away, you notice the egg left unnurtured" + '\n');
      }

      /*
      * Bricks Spawned
      */
      public void BricksSpawned()
      {
         Console.Write("Maybe I should take a brick with me?" + '\n');
      }

      /*
      * Fire Stone Spawned
      */
      public void FirestoneSpawned()
      {
         Console.Write("A red glowing firestone appears where the lava once rested." + '\n');
      }

      /*
      * Dropping the bricks in a cool fashion
      */
      public void LavaRiverBlocked()
      {
         Console.Write("After some thought, you dump your bricks in such a fashion that it blocks off the flow of the lava?" + '\n');
      }

      /*
      * Dropping the bricks in a cool fashion
      */
      public void PrintInventory(AdventurelandItems item)
      {
         Console.Write(item.ToString() + '\n');
      }

      /*
      * Dropping the bricks in a cool fashion
      */
      public void PrintInventoryHeader()
      {
         Console.Write("Your inventory consists of:" + '\n');
      }

      /*
      * Dropping the bricks in a cool fashion
      */
      public void CommitSuicide()
      {
         Console.Write("You grab the base of your chin and the back of your neck and twist viciously." + '\n');
      }      
      
      /*
      * No Inventory
      */
      public void InventoryEmpty()
      {
         Console.Write("You appear to be holding onto nothing." + '\n');
      }

      /*
      * Death by Chiggers
      */
      public void ChiggerKilledPlayer()
      {
         Console.Write("The bite from the chigger has grown infected and resulted in the loss of your life." + '\n');
      }

      /*
      * Prevent player from dropping items in the darkness room
      */
      public void DropInDarkness()
      {
         Console.Write("Why would you want to drop an item in a pitch black room?" + '\n');
      }

      /*
      * The lamp has run out of power. There is no more oil left in the game -virtually game over.
      */
      public void LampOutOfEnergy()
      {
         Console.Write("The lamp has ran out of oil." + '\n');
      }

      /*
      * The lamp has run out of power in the darkness.
      */
      public void LampOutOfEnergyInDarkness()
      {
         Console.Write("The darkness consumes you as the last of the oil burns out." + '\n');
      }

      public void NoLamp()
      {
         Console.Write("You do not have a lamp. \n");
      }
      public void LightLamp()
      {
         Console.Write("You lit the lamp. \n");
      }

      public void NoFlint()
      {
         Console.Write("You have nothing to light it with. \n");
      }

      public void BlowBladderInv()
      {
         Console.Write("You blew up the bladder and killed yourself. \n");
      }

      public void BlowWall()
      {
         Console.Write("Gas Bladder blew up! \n" + 
            "The bricked window has been blown to bits. \n");
      }

      public void BlowNothing()
      {
         Console.Write("Gas bladder blew up! \n" + 
            "But nothing happened. \n");
      }

      public void NoBladder()
      {
         Console.Write("You do not own a bladder. \n");
      }

      public void BladderEmpty()
      {
         Console.Write("The bladder is empty, you need to fill it up. \n");
      }

      public void FillBladder()
      {
         Console.Write("You filled the bladder with gas. \n");
      }

      public void ScoreOutput()
      {
         Console.Write("Current score is " + Score.ScoreInstance.GetScore() + " out of 100" + '\n');
      }

      public void Help()
      {
         // Prints all directions
         Console.Write(bar + "\nDirections: \n");
         string[] directions = Enum.GetNames(typeof(Directions));

         for (int i = 0; i < directions.Length - 1; i++)
         {
            Console.Write(directions[i] + " ");
         }

         // Prints all verbs
         Console.Write("\n \nVerbs: \n");
         string[] verbs = Enum.GetNames(typeof(Verbs));

         for (int i = 0; i < verbs.Length - 2; i++)
         {
            Console.WriteLine(verbs[i]);
         }
         Console.Write("\nGeneral Game Advice: \n" 
            + "-Have you tried getting better at the game?\n" +
            "-Ask Evan about the maze. He's the only one who understands what's going on. \n");

         Console.Write(bar + "\n\n");
      }

      public void UWU()
      {
         string file = Properties.Resource1.UWU;
         Console.Write(file + "\n\n");
      }

      public string FormatItemText(AdventurelandItems input)
      {
         string output;
         output = input.ToString();
         output = output.ToLower();
         output = output.Replace('_', ' ');
         if (Score.ScoreInstance.CheckIfTreasure(input))
         {
            output = output.ToUpper();
            output = '*' + output + '*';
         }
         return output;
      }
   }
}
