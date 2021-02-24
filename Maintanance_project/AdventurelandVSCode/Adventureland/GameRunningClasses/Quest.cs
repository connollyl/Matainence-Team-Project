/*
* This class instanciates all of the areas in the game.
* Also controls the getting of the areas.
* @Author Eric, Cole, Evan, Logan, Sam
*/
using Adventureland.AboveGroundAreas;
using Adventureland.UndergroundAreas;
using Adventureland.StartHereafterAreas;
using Adventureland.Maze;

//using Adventureland.Areas.Overworld;
using Adventureland.Areas.Underworld;
//using Adventureland.Areas.Purgatory;
//using Adventureland.Areas.Maze;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   class Quest
   {
      private Player player;
      private ArrayList areaList;
      public Quest()
      {
         areaList = new ArrayList();
         player = new Player();
         InitializeAreas();
      }
      // Assign all text to the Events in the list that corrispond with them
      public void InitializeEventText()
      {

      }

      // Create a list of every Area object
      public void InitializeAreas()
      {
         //Overworld Areas
         Area dismalSwamp = new DismalSwamp(this);
         areaList.Add(dismalSwamp);
         Area edgeOfBigHole = new EdgeOfBigHole(this);
         areaList.Add(edgeOfBigHole);
         Area forest = new Forest(this);
         areaList.Add(forest);
         Area hiddenGrove = new HiddenGrove(this);
         areaList.Add(hiddenGrove);
         Area lakeShore = new LakeShore(this);
         areaList.Add(lakeShore);
         Area ledge = new Ledge(this);
         areaList.Add(ledge);
         Area quicksand = new Quicksand(this);
         areaList.Add(quicksand);
         Area stump = new Stump(this);
         areaList.Add(stump);
         Area sunnyMeadow = new SunnyMeadow(this);
         areaList.Add(sunnyMeadow);
         Area topOfCypress = new TopOfCypress(this);
         areaList.Add(topOfCypress);
         Area topOfOak = new TopOfOak(this);
         areaList.Add(topOfOak);
         //Underworld Areas
         Area bottomOfChasm = new BottomOfChasm(this);
         areaList.Add(bottomOfChasm);
         Area largeCavern = new LargeCavern(this);
         areaList.Add(largeCavern);
         Area largeEightSidedRoom = new LargeEightSidedRoom(this);
         areaList.Add(largeEightSidedRoom);
         Area darkness = new Darkness(this);
         areaList.Add(darkness);
         Area longDownslopingHallway = new LongDownslopingHallway(this);
         areaList.Add(longDownslopingHallway);
         Area longTunnel = new LongTunnel(this);
         areaList.Add(longTunnel);
         Area memoryChip = new MemoryChip(this);
         areaList.Add(memoryChip);
         Area narrowLedgeByChasm = new NarrowLedgeByChasm(this);
         areaList.Add(narrowLedgeByChasm);
         Area narrowLedgeByThroneRoom = new NarrowLedgeByThroneRoom(this);
         areaList.Add(narrowLedgeByThroneRoom);
         Area rootChamber = new RootChamber(this);
         areaList.Add(rootChamber);
         Area royalAnteroom = new RoyalAnteroom(this);
         areaList.Add(royalAnteroom);
         Area royalChamber = new RoyalChamber(this);
         areaList.Add(royalChamber);
         Area semiDarkHole = new SemiDarkHole(this);
         areaList.Add(semiDarkHole);
         Area throneRoom = new ThroneRoom(this);
         areaList.Add(throneRoom);
         //Purgatory areas
         Area endlessCorridor = new EndlessCorridor(this);
         areaList.Add(endlessCorridor);
         Area hell = new Hell(this);
         areaList.Add(hell);
         Area largeMistyRoom = new LargeMistyRoom(this);
         areaList.Add(largeMistyRoom);
         //Maze areas
         Area eastOne = new EastOne(this);
         areaList.Add(eastOne);
         Area eastTwo = new EastTwo(this);
         areaList.Add(eastTwo);
         Area entrance = new Entrance(this);
         areaList.Add(entrance);
         Area northEastOne = new NorthEastOne(this);
         areaList.Add(northEastOne);
         Area northEastTwo = new NorthEastTwo(this);
         areaList.Add(northEastTwo);
         Area northOne = new NorthOne(this);
         areaList.Add(northOne);
         Area northTwo = new NorthTwo(this);
         areaList.Add(northTwo);
         Area northWestOne = new NorthWestOne(this);
         areaList.Add(northWestOne);
         Area northWestTwo = new NorthWestTwo(this);
         areaList.Add(northWestTwo);
         Area southEastOne = new SouthEastOne(this);
         areaList.Add(southEastOne);
         Area southEastTwo = new SouthEastTwo(this);
         areaList.Add(southEastTwo);
         Area southOne = new SouthOne(this);
         areaList.Add(southOne);
         Area southTwo = new SouthTwo(this);
         areaList.Add(southTwo);
         Area southWestOne = new SouthWestOne(this);
         areaList.Add(southWestOne);
         Area southWestTwo = new SouthWestTwo(this);
         areaList.Add(southWestTwo);
         Area westOne = new WestOne(this);
         areaList.Add(westOne);
         Area westTwo = new WestTwo(this);
         areaList.Add(westTwo);
      }

      /*
       * Method used to get an area in the game
       */
      public Area GetArea(AdventurelandAreas area)
      {
         foreach (Area areaInList in areaList)
         {
            if (areaInList.GetAreaIdentifier() == area)
               return areaInList;
         }
         return null;
      }

      /*
       * Returns the forest as the starting area in the game
       */
      public AdventurelandAreas GetStartingArea()
      {
         return AdventurelandAreas.Forest;
      }

      /*
       * Used to get the player in Adventureland.
       */
      public Player GetPlayer()
      {
         return player;
      }
   }
}
