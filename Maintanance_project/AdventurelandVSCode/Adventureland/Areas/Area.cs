/*
* Abstract class that templates the usage of other areas
* @Author Eric, Cole, Evan, Logan, Sam
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventureland
{
   abstract class Area
   {
      //*******************************************************
      // Functions within abstract class
      //*******************************************************
      public Area(Quest quest) { }
      public abstract bool GetDark();
      public abstract AdventurelandAreas GoNorth();
      public abstract AdventurelandAreas GoEast();
      public abstract AdventurelandAreas GoSouth();
      public abstract AdventurelandAreas GoWest();
      public abstract AdventurelandAreas GoUp();
      public abstract AdventurelandAreas GoDown();
      public abstract AdventurelandAreas GetAreaIdentifier();
      public abstract String GetAreaName();
      public abstract String GetAreaBio();
      public abstract String GetObviousExits();
      public abstract String GetAreaText();
      public abstract List<AdventurelandItems> GetAreaItems();
      public abstract void RemoveItem(AdventurelandItems item);
      public abstract void AddItem(AdventurelandItems item);
      public abstract void InitializeAreaItems();
      public abstract bool HasItem(AdventurelandItems item);

   }
}
