/*
 * Class that handles the commands and event triggers
 * @Author Eric, Cole, Evan, Logan, Sam
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventureland.Text_Controller;

namespace Adventureland
{
   class CmdProcessor
   {
      /*
       * Method used to check directions
       */
      public AdventurelandAreas ProcessDirection(Directions cmd, Area area)
      {
         switch (cmd)
         {
            case Directions.North:
               return area.GoNorth();
            case Directions.East:
               return area.GoEast();
            case Directions.South:
               return area.GoSouth();
            case Directions.West:
               return area.GoWest();
            case Directions.Down:
               return area.GoDown();
            case Directions.Up:
               return area.GoUp();
            default:
               return AdventurelandAreas.Hell; //Should never get here, if you did, you're actualy an idiot
         }
      }

      /*
       * Method used to Proccess all the commands in the game
       */
      public void ProcessVerb(Verbs cmd, Verbs verb2, AdventurelandItems item, ref Area area, Quest quest)
      {
         switch (cmd)
         {
            case Verbs.Get:
               DoGet(item, area, quest);
               break;
            case Verbs.Take:
               DoGet(item, area, quest);
               break;
            case Verbs.Drop:
               DoDrop(item, area, quest);
               break;
            case Verbs.Rub:
               DoRub(ref area, quest);
               break;
            case Verbs.Light:
               DoLight(item, ref area, quest);
               break;
            case Verbs.Switch:
               DoSwitch(quest);
               break;
            case Verbs.Away:
               DoAway(ref area, quest);
               break;
            case Verbs.Jump:
               DoJump(ref area, quest);
               break;
            case Verbs.Say:
               DoSay(area);
               break;
            case Verbs.Unlock:
               DoUnlock(area, quest);
               break;
            case Verbs.Release:
               DoRelease(area, quest);
               break;
            case Verbs.Cut:
               DoCut(area, quest);
               break;
            case Verbs.Bunyon:
               DoBunyon(area, quest);
               break;
            case Verbs.Swim:
               DoSwim(ref area, quest);
               break;
            case Verbs.Inventory:
               DoGetInventory(quest);
               break;
            case Verbs.Suicide:
               DoSuicide(ref area, quest);
               break;
            default:
               break;
         }
      }

      /*
       * Method used to print out all the commands in the game.
       */
      public void DoHelp()
      {
         Output.OutputInstance.Help();
      }

      /*
       * Method used to print out all the commands in the game.
       */
      public void DoScore()
      {
         Output.OutputInstance.ScoreOutput();
      }

      /*
       * Method used to print out all the commands in the game.
       */
      public void DoGetInventory(Quest quest)
      {
         List<AdventurelandItems> currInventory = quest.GetPlayer().GetItems();

         if(currInventory.Count > 0)
         {
            Output.OutputInstance.PrintInventoryHeader();
            for (int i = 0; i < currInventory.Count; i++)
            {
               Output.OutputInstance.PrintInventory(currInventory.ElementAt(i));
            }
            Output.OutputInstance.NewLine();
         }
         else
         {
            Output.OutputInstance.InventoryEmpty();
         }
      }

      /*
       * Method used to commit suicide and spawn in the misty room
       */
      public void DoSuicide(ref Area area, Quest quest)
      {
         Output.OutputInstance.CommitSuicide();
         area = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
      }

      /*
       * Method used to pick up items in the game
       */
      private void DoGet(AdventurelandItems item, Area area, Quest quest)
      {
         if (area.HasItem(item))
         {

            if (item.Equals(AdventurelandItems.Mud))
            {
               DoTakeMud(area);
            }
            else if(item.Equals(AdventurelandItems.Royal_Honey))
            {
               if(!AreaEvent.AreaEventInstance.HoneyTaken)
               {
                  DoGetHoney(ref area, quest);
                  if(AreaEvent.AreaEventInstance.HoneyTaken)
                  {
                     area.RemoveItem(item);
                     quest.GetPlayer().GiveItem(item);
                  }
               }
               else
               {
                  area.RemoveItem(item);
                  quest.GetPlayer().GiveItem(item);
               }
            }
            else if(item.Equals(AdventurelandItems.Golden_Fish))
            {
               if(!AreaEvent.AreaEventInstance.FishTaken)
               {
                  DoGetFish(area, quest);
                  if(AreaEvent.AreaEventInstance.FishTaken)
                  {
                     quest.GetPlayer().GiveItem(item);
                     area.RemoveItem(item);
                  }
               }
            }
            else if (item.Equals(AdventurelandItems.Slime_Oil))
            {
               if (!AreaEvent.AreaEventInstance.OilCollected)
               {
                  DoGetOil(area, quest);
                  if (AreaEvent.AreaEventInstance.OilCollected)
                  {
                     area.RemoveItem(item);
                  }
               }
            }
            else if (item.Equals(AdventurelandItems.Swamp_Gas))
            {
               if (!AreaEvent.AreaEventInstance.BladderFilledWithGas)
               {
                  DoGetGas(area, quest);
                  if (AreaEvent.AreaEventInstance.BladderFilledWithGas)
                  {
                     area.RemoveItem(item);
                  }
               }
            }
            else if(item.Equals(AdventurelandItems.Magic_Mirror))
            {
               if(!AreaEvent.AreaEventInstance.MirrorTaken)
               {
                  DoGetMirror(ref area, quest);
                  if(AreaEvent.AreaEventInstance.BearDead)
                  {
                     quest.GetPlayer().GiveItem(item);
                     area.RemoveItem(item);
                  }
               }
               else
               {
                  area.RemoveItem(item);
                  quest.GetPlayer().GiveItem(item);
               }
            }
            else
            {
               area.RemoveItem(item);
               quest.GetPlayer().GiveItem(item);
               Output.OutputInstance.PickedUp(item);

               if (item.Equals(AdventurelandItems.Skeleton_Keys))
               {
                  AreaEvent.AreaEventInstance.CypressKeysTaken = true;
               }
            }
         }
         else if (item.Equals(AdventurelandItems.Bees))
         {
            if (!AreaEvent.AreaEventInstance.BeesRemoved)
            {
               DoGetBees(ref area, quest);
               if (AreaEvent.AreaEventInstance.BeesRemoved)
               {
                  quest.GetPlayer().RemoveItem(AdventurelandItems.Bottle); //do in the take command
                  quest.GetPlayer().GiveItem(AdventurelandItems.Bottle_Of_Bees); // do in the take command
               }
            }
         }
         else
         {
            Output.OutputInstance.InvalidTakeItem();
         }
      }

      /*
       * Method used to drop the players inventory into the current area item list
       */
      private void DoDrop(AdventurelandItems item, Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(item) && !area.GetAreaIdentifier().Equals(AdventurelandAreas.Darkness))
         {
            if(item.Equals(AdventurelandItems.Mud))
            {
               AreaEvent.AreaEventInstance.MudApplied = false;
               quest.GetPlayer().RemoveItem(AdventurelandItems.Mud);
            }
            else if(item.Equals(AdventurelandItems.Magic_Mirror))
            {
               if(!AreaEvent.AreaEventInstance.MirrorBroken)
               {
                  CheckMirrorCondition(area);
                  if (!AreaEvent.AreaEventInstance.MirrorBroken)
                  {
                     area.AddItem(item);
                     quest.GetPlayer().RemoveItem(item);
                  }
                  else
                  {
                     quest.GetPlayer().RemoveItem(item);
                  }
               }
            }
            else if(item.Equals(AdventurelandItems.Bricks))
            {
               if(!AreaEvent.AreaEventInstance.LavaFlowStopped)
               {
                  CheckBrickCondition(area, quest);
                  if(AreaEvent.AreaEventInstance.LavaFlowStopped)
                  {
                     quest.GetPlayer().RemoveItem(AdventurelandItems.Bricks);
                     DoSpawnFirestone(area);
                  }
                  else
                  {
                     area.AddItem(item);
                     quest.GetPlayer().RemoveItem(item);
                  }
               }
            }
            else
            {
               area.AddItem(item);
               quest.GetPlayer().RemoveItem(item);
               Output.OutputInstance.Dropped(item);
            }
         }
         else
         {
            if(area.GetAreaIdentifier().Equals(AdventurelandAreas.Darkness))
            {
               Output.OutputInstance.DropInDarkness();
            }
            else
            {
               Output.OutputInstance.InvalidDropItem();
            }
         }
      }

      /*
       * Method used to swim out the Quicksand / Bog back to the LakeShore
       */
      private void DoSwim(ref Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Quicksand))
         {
            if (quest.GetPlayer().HasEmptyInventory())
            {
               area = quest.GetArea(AdventurelandAreas.Lake_Shore); //need to check if this works.
               Output.OutputInstance.SwimSuccessful();
            }
            else
            {
               Output.OutputInstance.PlayerOverweight();
            }
         }
         else
         {
            Output.OutputInstance.SwimFailed();
         }
      }

      /*
       * Method used to check if the mirror breaks or not when dropping. Rug prevents breaking.
       */
      private void CheckMirrorCondition(Area area)
      {
         if(area.HasItem(AdventurelandItems.Persian_Rug))
         {
            Output.OutputInstance.MirrorDroppedSafely();
         }
         else
         {
            AreaEvent.AreaEventInstance.MirrorBroken = true;
            Output.OutputInstance.MirrorDroppedAndBroke();
         }
      }

      /*
       * Method used to check if the bricks are dropped in the Bottom of the Chasm
       */
      private void CheckBrickCondition(Area area, Quest quest)
      {
         if(area.GetAreaIdentifier().Equals(AdventurelandAreas.Bottom_Of_Chasm))
         {
            AreaEvent.AreaEventInstance.LavaFlowStopped = true;
            Output.OutputInstance.LavaRiverBlocked();
         }
      }

      /*
       * Method used to check if the mirror breaks or not when dropping. Rug prevents breaking.
       */
       private void DoGetMirror(ref Area area, Quest quest)
      {
         if(AreaEvent.AreaEventInstance.BearDead)
         {
            AreaEvent.AreaEventInstance.MirrorTaken = true;
            Output.OutputInstance.MirrorTakenSuccessfully();
         }
         else
         {
            Output.OutputInstance.MirrorBearDeath();
            area = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
         }
      }

      /*
       * Method used to teleport the player's inventiry to the Hidden Grove
       * if they own the axe and they have not used the ability yet.
       */
      private void DoBunyon(Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Axe))
         {
            if (!AreaEvent.AreaEventInstance.UsedBunyon)
            {
               AreaEvent.AreaEventInstance.UsedBunyon = true;

               List<AdventurelandItems> items = new List<AdventurelandItems>();
               Area hiddenGrove = quest.GetArea(AdventurelandAreas.Hidden_Grove); //test to see if items are teleported correctly
               items = quest.GetPlayer().GetItems();

               for (int i = items.Count; i > 0; i--)
               {
                  hiddenGrove.AddItem(items[i - 1]);
                  quest.GetPlayer().RemoveItem(items[i - 1]);
               }
               Output.OutputInstance.BunyonSuccessful();
            }
            else
            {
               Output.OutputInstance.BunyonFailed();
            }
         }
         else
         {
            Output.OutputInstance.AxeRequired();
         }
      }

      /*
       * Method used to interact the the lamp.
       */
      private void DoRub(ref Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Lamp))
         {
            if (AreaEvent.AreaEventInstance.OilCollected)
            {
               if (AreaEvent.AreaEventInstance.TimesLampRubbed == 0)
               {
                  quest.GetPlayer().GiveItem(AdventurelandItems.Diamond_Ring);
                  Output.OutputInstance.FirstRub();
                  AreaEvent.AreaEventInstance.TimesLampRubbed = 1;
               }
               else if (AreaEvent.AreaEventInstance.TimesLampRubbed == 1)
               {
                  quest.GetPlayer().GiveItem(AdventurelandItems.Diamond_Bracelet);
                  Output.OutputInstance.SecondRub();
                  AreaEvent.AreaEventInstance.TimesLampRubbed = 2;
               }
               else if (AreaEvent.AreaEventInstance.TimesLampRubbed == 2)
               {
                  if (!AreaEvent.AreaEventInstance.DiamondRingRemoved) //Figure out how to remove from game and not player inv
                  {
                     quest.GetPlayer().RemoveItem(AdventurelandItems.Diamond_Ring);
                     AreaEvent.AreaEventInstance.DiamondRingRemoved = true;
                  }
                  Output.OutputInstance.ThirdAndFourthRub();
                  AreaEvent.AreaEventInstance.TimesLampRubbed = 3;
               }
               else if (AreaEvent.AreaEventInstance.TimesLampRubbed == 3) //Figure out how to remove from game and not player inv
               {
                  if (!AreaEvent.AreaEventInstance.DiamondBraceletRemoved)
                  {
                     quest.GetPlayer().RemoveItem(AdventurelandItems.Diamond_Bracelet);
                     AreaEvent.AreaEventInstance.DiamondBraceletRemoved = true;
                  }
                  Output.OutputInstance.ThirdAndFourthRub();
                  AreaEvent.AreaEventInstance.TimesLampRubbed = 4;
               }
               else
               {
                  Output.OutputInstance.FifthRub();
                  area = quest.GetArea(AdventurelandAreas.Hell);
               }
            }
            else
            {
               Output.OutputInstance.RubWithoutOil();
            }
         }
         else
         {
            Output.OutputInstance.RubFailed();
         }
      }

      /*
       * Method used to light the Bladder or light the lamp 
       */
      private void DoLight(AdventurelandItems item, ref Area area, Quest quest)
      {
         if (item.Equals(AdventurelandItems.Lamp))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Lamp))
            {
               if (AreaEvent.AreaEventInstance.OilCollected)
               {
                  if (quest.GetPlayer().HasItem(AdventurelandItems.Flint_And_Stone))
                  {
                     AreaEvent.AreaEventInstance.LampOn = true;
                     Output.OutputInstance.LightLamp();
                  }
                  else
                  {
                     Output.OutputInstance.NoFlint();
                  }
               }
               else
               {
                  Output.OutputInstance.LampNeedsOil();
               }
            }
            else
            {
               Output.OutputInstance.NoLamp();
            }
         }
         else if (item.Equals(AdventurelandItems.Bladder))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Bladder))
            {
               if (quest.GetPlayer().HasItem(AdventurelandItems.Flint_And_Stone))
               {
                  if (AreaEvent.AreaEventInstance.BladderFilledWithGas)
                  {
                     Output.OutputInstance.BlowBladderInv();
                     quest.GetPlayer().RemoveItem(AdventurelandItems.Bladder);
                     area = quest.GetArea(AdventurelandAreas.Hell);
                  }
                  else
                  {
                     Output.OutputInstance.BladderEmpty();
                  }
               }
               Output.OutputInstance.NoFlint();
            }
            else
            {
               if (area.HasItem(item))
               {
                  if (quest.GetPlayer().HasItem(AdventurelandItems.Flint_And_Stone))
                  {
                     if (AreaEvent.AreaEventInstance.BladderFilledWithGas)
                     {
                        if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Royal_Chamber))
                        {
                           Output.OutputInstance.BlowWall();
                           AreaEvent.AreaEventInstance.WallBlownUp = true;
                           area.RemoveItem(AdventurelandItems.Bladder);
                           DoSpawnBricks(quest);
                        }
                        else
                        {
                           Output.OutputInstance.BlowNothing();
                        }
                     }
                     else
                     {
                        Output.OutputInstance.BladderEmpty();
                     }
                  }
                  else
                  {
                     Output.OutputInstance.NoFlint();
                  }
               }
               else
               {
                  Output.OutputInstance.NoBladder();
               }
            }
         }
      }

      /*
       * Gets the gas from the dismal swamp if the player has the Bladder
       */
      private void DoGetGas(Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Dismal_Swamp))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Bladder))
            {
               Output.OutputInstance.FillBladder();
               AreaEvent.AreaEventInstance.BladderFilledWithGas = true;
            }
            else
            {
               Output.OutputInstance.NoBladder();
            }
         }
      }

      /*
       * Method used to collect oil in the desert while possessing a lamp
       */
      private void DoGetOil(Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Dismal_Swamp))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Lamp))
            {
               if (!AreaEvent.AreaEventInstance.OilCollected)
               {
                  AreaEvent.AreaEventInstance.OilCollected = true;
                  Output.OutputInstance.OilSuccessfullyCollected();
               }
               else
               {
                  Output.OutputInstance.OilAlreadyCollected();
               }
            }
            else
            {
               Output.OutputInstance.NoLampAvailable();
            }
         }
         else
         {
            Output.OutputInstance.NoOilFound();
         }
      }

      /*
       * Method used to capture the fish
       */
      private void DoGetFish(Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Lake_Shore))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Golden_Net))
            {
               if (!AreaEvent.AreaEventInstance.FishTaken)
               {
                  AreaEvent.AreaEventInstance.FishTaken = true;
                  Output.OutputInstance.FishCaptured();
               }
               else
               {
                  Output.OutputInstance.FishNotFound();
               }
            }
            else
            {
               Output.OutputInstance.FishingNetRequired();
            }
         }
         else
         {
            Output.OutputInstance.FishNotFound();
         }
      }

      /*
       * Used to cover yourself in the mud in the dismal swamp - mud is an infinite source.
       */
      private void DoTakeMud(Area area)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Dismal_Swamp))
         {
            if (!AreaEvent.AreaEventInstance.MudApplied)
            {
               AreaEvent.AreaEventInstance.MudApplied = true;
               Output.OutputInstance.MudApplied();
            }
            else
            {
               Output.OutputInstance.MudAlreadyApplied();
            }
         }
         else
         {
            Output.OutputInstance.MudNotFound();
         }
      }

      /*
       * Method used to collect the bees in the large eight sided room.
       */
      private void DoGetBees(ref Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Large_Eight_Sided_Room))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Bottle))
            {
               if (AreaEvent.AreaEventInstance.MudApplied)
               {
                  if (!AreaEvent.AreaEventInstance.BeesRemoved)
                  {
                     AreaEvent.AreaEventInstance.BeesRemoved = true;
                     Output.OutputInstance.BeesCaptured();
                  }
                  else
                  {
                     Output.OutputInstance.BeesNotFound();
                  }
               }
               else
               {
                  Output.OutputInstance.BeesSmellYou();
                  area = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
               }
            }
            else
            {
               Output.OutputInstance.BeesCaptureFailed();
               area = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
            }
         }
         else
         {
            Output.OutputInstance.BeesNotFound();
         }
      }

      /*
       * Method used to take the honey from the EightSidedRoom
       */
      private void DoGetHoney(ref Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Large_Eight_Sided_Room))
         {
            if (AreaEvent.AreaEventInstance.BeesRemoved)
            {
               AreaEvent.AreaEventInstance.HoneyTaken = true;
               Output.OutputInstance.HoneyCollected();
            }
            else
            {
               if (AreaEvent.AreaEventInstance.MudApplied)
               {
                  AreaEvent.AreaEventInstance.HoneyTaken = true;
                  Output.OutputInstance.HoneyCollected();
               }
               else
               {
                  Output.OutputInstance.BeesSmellYou();
                  area = quest.GetArea(AdventurelandAreas.Large_Misty_Room);
               }
            }
         }
         else
         {
            Output.OutputInstance.HoneyNotFound();
         }
      }

      /*
       * Method used to turn the lamp off
       */
      private void DoSwitch(Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Lamp))
         {
            if (AreaEvent.AreaEventInstance.OilCollected)
            {
               if (AreaEvent.AreaEventInstance.LampOn)
               {
                  AreaEvent.AreaEventInstance.LampOn = false;
                  Output.OutputInstance.ExtinquishLamp();
               }
               else
               {
                  Output.OutputInstance.LampAlreadyOff();
               }
            }
            else
            {
               Output.OutputInstance.LampNeedsOil();
            }
         }
         else
         {
            Output.OutputInstance.RubFailed();
         }
      }

      /*
       * Method used to fly out of the West Maze Two to the Sunny Meadows.
       */
      private void DoAway(ref Area area, Quest quest)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.WestTwo))
         {
            if (quest.GetPlayer().HasItem(AdventurelandItems.Persian_Rug))
            {
               Output.OutputInstance.RugUsed();
               area = quest.GetArea(AdventurelandAreas.Sunny_Meadow);
            }
            else
            {
               Output.OutputInstance.RugRequired();
            }
         }
         else
         {
            Output.OutputInstance.RugAttemptFailed();
         }
      }

      /*
       * Allows the player to jump the edges if the wall has been blown up.
       */
      private void DoJump(ref Area area, Quest quest)
      {
         if (AreaEvent.AreaEventInstance.WallBlownUp)
         {
            if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Narrow_Ledge_By_Chasm))
            {
               Output.OutputInstance.JumpSuccessful();
               area = quest.GetArea(AdventurelandAreas.Narrow_Ledge_By_Throne_Room);
            }
            else if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Narrow_Ledge_By_Throne_Room))
            {
               Output.OutputInstance.JumpSuccessful();
               area = quest.GetArea(AdventurelandAreas.Narrow_Ledge_By_Chasm);
            }
            else
            {
               Output.OutputInstance.JumpInPlace();
            }
         }
         else
         {
            Output.OutputInstance.JumpInPlace();
         }
      }

      /*
       * Method used to startle the bear and make it commit suicide, or talk to yourself.
       */
      private void DoSay(Area area)
      {
         if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Narrow_Ledge_By_Throne_Room))
         {
            if (!AreaEvent.AreaEventInstance.BearDead)
            {
               AreaEvent.AreaEventInstance.BearDead = true;
               Output.OutputInstance.SayToBear();
            }
            else
            {
               Output.OutputInstance.InvalidSayToBear();
            }
         }
         else
         {
            Output.OutputInstance.SayToYourself();
         }
      }

      /*
       * Unlocks the door in the SemiDarkHole is you have the skeleton Key on you
       */
      private void DoUnlock(Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Skeleton_Keys))
         {
            if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Semi_Dark_Hole))
            {
               if (!AreaEvent.AreaEventInstance.SemiDarkHoleDoorUnlocked)
               {
                  AreaEvent.AreaEventInstance.SemiDarkHoleDoorUnlocked = true;
                  Output.OutputInstance.UnlockDoor();
               }
               else
               {
                  Output.OutputInstance.KeyRequired();
               }
            }
            else
            {
               Output.OutputInstance.InvalidKeyAction();
            }
         }
         else
         {
            Output.OutputInstance.InvalidKeyRequired();
         }
      }

      /*
       * Releases the bees. If in the meadows it scares the dragon away.
       * Otherwise, the bees fly away and game is unwinnable.
       */
      private void DoRelease(Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Bottle_Of_Bees))
         {
            if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Sunny_Meadow))
            {
               quest.GetPlayer().RemoveItem(AdventurelandItems.Bottle_Of_Bees);
               AreaEvent.AreaEventInstance.DragonFlewAway = true;
               Output.OutputInstance.BeesReleaseUseful();
               DoSpawnDragonEgg(quest); //spawns the dragon egg into the sunny meadow
            }
            else
            {
               quest.GetPlayer().RemoveItem(AdventurelandItems.Bottle_Of_Bees);
               Output.OutputInstance.BeesReleaseWasted();
            }
         }
         else
         {
            Output.OutputInstance.InvalidRelease();
         }
      }

      /*
       * Method used to cut down the Cypress tree in the Dismal Swamp.
       * The Skeleton Keys will be removed from the game if not grabbed before hand.
       */
      private void DoCut(Area area, Quest quest)
      {
         if (quest.GetPlayer().HasItem(AdventurelandItems.Axe))
         {
            if (area.GetAreaIdentifier().Equals(AdventurelandAreas.Dismal_Swamp))
            {
               if (!AreaEvent.AreaEventInstance.CypressCutDown)
               {
                  AreaEvent.AreaEventInstance.CypressCutDown = true;
                  if (!AreaEvent.AreaEventInstance.CypressKeysTaken)
                  {
                     Output.OutputInstance.CypressKeyMissed();
                  }
                  else
                  {
                     Output.OutputInstance.TreeCutDown();
                  }
               }
               else
               {
                  Output.OutputInstance.TreeAlreadyCut();
               }
            }
            else
            {
               Output.OutputInstance.InvalidAreaAction();
            }
         }
         else
         {
            Output.OutputInstance.AxeRequired();
         }
      }

      /*
       * Method used to spawn the dragon egg into the sunny meadows once the dragon flies away
       */
      private void DoSpawnDragonEgg(Quest quest)
      {
         AreaEvent.AreaEventInstance.DragonEggSpawned = true;
         Area tempArea = quest.GetArea(AdventurelandAreas.Sunny_Meadow);
         tempArea.AddItem(AdventurelandItems.Dragon_Eggs);
         Output.OutputInstance.EggSpawned();
      }

      /*
       * Method used to spawn the bricks once the wall is blown up.
       */
      private void DoSpawnBricks(Quest quest)
      {
         AreaEvent.AreaEventInstance.BricksSpawned = true;
         Area tempArea = quest.GetArea(AdventurelandAreas.Royal_Chamber);
         tempArea.AddItem(AdventurelandItems.Bricks);
         Output.OutputInstance.BricksSpawned();
      }

      /*
       * Method used to spawn the firestone once bricks are dorpped to stop the lava flow
       */
      private void DoSpawnFirestone(Area area)
      {
         area.AddItem(AdventurelandItems.Firestone);
         Output.OutputInstance.FirestoneSpawned();
      }

   }
}
