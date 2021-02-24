/*
 * Class that handles the scoring system in the game by dropping items into the stump.
 * @Author Eric, Cole, Evan, Logan, Sam
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   public sealed class Score
   {
      private const int HIGHEST_SCORE = 13;
      private const int DECIMAL_CONVERTER = 100;
      private static Score instance = null;

      Score()
      {
         ScoreValue = 0;
         Treasures = new List<AdventurelandItems>();
         InstantiateTreasureList();
      }
      
      /*
       * Used to make sure the class is a singleton
       */
      public static Score ScoreInstance
      {
         get
         {
            if (instance == null)
            {
               instance = new Score();
            }
            return instance;
         }
      }

      public int ScoreValue { get; set; }

      public List<AdventurelandItems> Treasures { get; }

      /*
       * The treasures [items] that add towards the score when dropped in the stump
       */
      private void InstantiateTreasureList()
      {
         Treasures.Add(AdventurelandItems.Blue_Ox_Statue);
         Treasures.Add(AdventurelandItems.Diamond_Bracelet);
         Treasures.Add(AdventurelandItems.Diamond_Ring);
         Treasures.Add(AdventurelandItems.Dragon_Eggs);
         Treasures.Add(AdventurelandItems.Firestone);
         Treasures.Add(AdventurelandItems.Golden_Crown);
         Treasures.Add(AdventurelandItems.Golden_Fish);
         Treasures.Add(AdventurelandItems.Golden_Net);
         Treasures.Add(AdventurelandItems.Jeweled_Fruit);
         Treasures.Add(AdventurelandItems.Magic_Mirror);
         Treasures.Add(AdventurelandItems.Persian_Rug);
         Treasures.Add(AdventurelandItems.Pot_Of_Rubies);
         Treasures.Add(AdventurelandItems.Royal_Honey);
      }

      /*
       * Checks if the item is a treasure
       */
      public bool CheckIfTreasure(AdventurelandItems item)
      {
         if (Treasures.Contains(item))
            return true;
         return false;
      }

      /*
       * Resets the score to zero
       */
      public void ResetScore()
      {
         ScoreValue = 0;
      }

      /*
       * Increases the score when a treasure is added to the stump
       */
      public void AddToScore()
      {
         ScoreValue++;
      }

      /*
       * decreases the score when a treasure is taken to the stump
       */
      public void SubFromScore()
      {
         ScoreValue--;
      }

      /*
       * Returns the score out of a 100.
       */
      public int GetScore()
      {
         int num = (ScoreValue * DECIMAL_CONVERTER) / HIGHEST_SCORE;
         return num;
      }
   }
}
