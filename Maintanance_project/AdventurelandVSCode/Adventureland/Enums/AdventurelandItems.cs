/*
* Class thatholds onto all the items and interactable monsters
* @Author Eric, Cole, Evan, Logan, Sam
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   public enum AdventurelandItems
   {
      Bunyons_Axe, // used to teleport items out of quicksand without dropping them, at lakeshore
      Axe, // after teleporting the items, this will show up at Hidden Grove. You will then use this axe to chop down the tree in the swamp
      Flint_And_Stone, // used to light the lamp. Found in the ledge
      Slime_Oil, //the lamp only lasts a certain number of turns, but it can be re-lit with this oil found in the swamp screen.
      Bottle, //found in the treasure screen in the stump, this is used to catch the fish.
      Bladder, // grab this from the royal anteroom and fill it with gas from the swamp.
      Bricks, // these fall after you blow up the brick wall in the royal chamber by igniting the gas-filled bladder.
      Skeleton_Keys, // before chopping down the tree in the swamp, climb up the tree and take the keys.
      Mud, // used to cure chiggers and repel bees.
      Swamp_Gas, // used to fill the bladder so you can blow it up in the royal chamber.
      Bottle_Of_Bees, //put bees in the jar
      Lamp, // rub it twice to drop two diamond key items. Afterward, it can be used as a lamp for light.

      //13 Treasures Needed
      Pot_Of_Rubies, // (found below treasure storage/stump screen)
      Golden_Fish, // bring the net and the bottle to the lake screen and type "catch fish" to actually catch it. (found at the lake shore; you need the golden net and bottle of water to catch it)
      Golden_Net, // used to catch the fish. (found in maze)
      Royal_Honey, // catch the bees with the bottle first, before you take the honey. (found in 8 sides room; you need to catch the bees first)
      Golden_Crown, //found in the throne room. (found in throne room; you need to blow up the brick window in the royal chamber first)
      Magic_Mirror, // this drops off the bear after you scream at it. (dropped by bear after going through blown up brick window)
      Jeweled_Fruit, //(found in hidden grove)
      Blue_Ox_Statue, // found in quicksand (found in quicksand and later teleported to hidden grove after you "Say Bunyon" with the axe)
      Diamond_Ring, //(dropped when you rub the lamp)
      Diamond_Bracelet, //(dropped when you rub the lamp for a second time)
      Firestone, // bring the bricks and the bottle of water to the bottom of the cave maze. Dam the lava with the bricks, then pour water on the Firestone so you can grab it. (found at bottom of maze; brick the lava to reveal it, then pour the water to cool it)
      Persian_Rug, // type "Say Away" twice while it is in your inventory to be warped back to the first screen of the game. Also, if you put the mirror on it, it will reveal a clue. (found at bottom of maze; type "Say Away" twice to fly back to the start)
      Dragon_Eggs, // release the bees and grab the egg (found at dragon screen; release bees to get the eggs)
      Invalid,

      //Interactable Events
      Bear,
      Bees,
      Dragon,
      Door,
      Tree

      //**************************************************************************************************************
      // 1. Let sleeping dragons lie, until much later. (Never go near him with any mud.)
      // 2. In quicksand take only the ax.  Get ox.  Say Bunyon.  Swim south.  Go to Paul's place.  En route, get flint and steel.
      // 3. Climb tree.  Get key.  Read web.  Chop tree.  May need mud for chigger bites.  Go stump.  Start dumping treasures.  Rub lamp (Twice only) for two more.  With the rubies directly below, there should now be five.  Take bottle.
      // 4. Unlock door.  Drop keys.  Go hallway.  Light lamp with flint and steel.  If lamp dies, fill with oily slime.
      // 5. In maze, get rug and net.  With rug, get out by say away (twice) to transport back to the meadow.
      // 6. At lake with filled bottle and net, catch fish. (Fish die without bottle.)
      // 7. Get wine bladder.  Fill bladder (with swamp gas).  In royal chamber, drop bladder.  Burn bladder.
      // 8. Scream (at bear).  Jump ledge.  Get crown, mirror and bricks.  Don't throw ax at bear or waste honey on him.  Drop mirror on rug only (get clues).
      // 9. Dam lava with bricks.  Pour water.  Get firestone.
      // 10. In beehive, with rug, mud, and empty bottle, catch bees.  Take honey.  Drop mud.  Go meadow.  Release bees.  Get dragon eggs.  (Can make it 50% of the time before Bees die, but using rug and say away is easier.)  After dropping all thirteen treasures, say score.The treasure summary:
      // Blue Ox           Golden Fish       Golden Net
      // Jeweled Fruit     Diamond Ring      Bracelet
      // Rubies            Rug Magic Mirror
      // Golden Crown      Royal Honey       Firestone Dragon Eggs
      //***************************************************************************************************************
   }
}
