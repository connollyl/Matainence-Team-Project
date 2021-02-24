/*
 * Class that handles all the events that have the ability to affect the world.
 * @Author Eric, Cole, Evan, Logan, Sam
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   public sealed class AreaEvent
   {
      /*
       * All of the event triggers that are used in the game
       */
      AreaEvent() 
      {
         CypressCutDown = false;
         CypressKeysTaken = false;
         SemiDarkHoleDoorUnlocked = false;
         UsedBunyon = false;
         OilCollected = false;
         TimesLampRubbed = 0;
         DiamondBraceletRemoved = false;
         DiamondRingRemoved = false;
         DragonFlewAway = false;
         BladderFilledWithGas = false;
         BearDead = false;
         LampOn = false;
         LampCount = 150;
         MudApplied = false;
         FishTaken = false;
         WallBlownUp = false;
         BeesRemoved = false;
         HoneyTaken = false;
         MirrorBroken = false;
         MirrorTaken = false;
         DragonEggSpawned = false;
         BricksSpawned = false;
         ChiggerBite = false;
         LavaFlowStopped = false;
         ChiggerCount = 20;
      }
      private static AreaEvent instance = null;

      /*
       * Makes this file a singleton.
       */
      public static AreaEvent AreaEventInstance
      {
         get
         {
            if (instance == null)
            {
               instance = new AreaEvent();
            }
            return instance;
         }
      }

      public bool CypressCutDown { get; set; }

      public bool CypressKeysTaken { get; set; }

      public bool SemiDarkHoleDoorUnlocked { get; set; }

      public bool UsedBunyon { get; set; }

      public int TimesLampRubbed { get; set; }

      public bool OilCollected { get; set; }

      public bool DiamondRingRemoved { get; set; }

      public bool DiamondBraceletRemoved { get; set; }

      public bool DragonFlewAway { get; set; }

      public bool BladderFilledWithGas { get; set; }

      public bool WallBlownUp { get; set; }

      public bool BearDead { get; set; }

      public bool LampOn { get; set; }

      public int LampCount { get; set; }

      public bool MudApplied { get; set; }

      public bool FishTaken { get; set; }

      public bool BeesRemoved { get; set; }

      public bool HoneyTaken { get; set; }

      public bool MirrorBroken { get; set; }

      public bool MirrorTaken { get; set; }

      public bool DragonEggSpawned { get; set; }

      public bool BricksSpawned { get; set; }

      public bool ChiggerBite { get; set; }

      public bool LavaFlowStopped { get; set; }

      public int ChiggerCount { get; set; }
   }
}
