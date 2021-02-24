/*
* Welcome to Adventureland!
* This is the main where the program starts
* @Author Eric, Cole, Evan, Logan, Sam
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   class Adventureland
   {
      static void Main(string[] args)
      {
         QuestManager questManager = new QuestManager();
         questManager.NewQuest();
      }
   }
}
