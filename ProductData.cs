using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodisAutomaten
{
    public class ProductData
    {
        protected static float generalPriceStatic = 5.90f;               

        public static void DisplayGeneralPrice()
        {
            Console.WriteLine(" Pris {0} kr/hg\n", generalPriceStatic);
        }

        /*
        public float GeneralPriceProperty
        {
            get 
            {
                return generalPriceStatic;
            }
        }
        */

        // Information om godissorterna och aktuellt pris per hekto ligger i en separat fil
        // för att administratören enklare ska kunna uppdatera informationen.

        public static string GetItemNames(int menuItem)
        {
            string[] candyItemNames = new string[10];

            candyItemNames[0] = "Gott & Blandat GIANTS";
            candyItemNames[1] = "Sura Bläckfiskar";
            candyItemNames[2] = "Sura Colanappar";
            candyItemNames[3] = "Sur Colabit MEGA";
            candyItemNames[4] = "Sockerbitar Original";
            candyItemNames[5] = "Vaniljfudge";
            candyItemNames[6] = "Rollokola";
            candyItemNames[7] = "Daim MINI";
            candyItemNames[8] = "Snickers MINI";
            candyItemNames[9] = "Twix MINI";

            string itemName = candyItemNames[menuItem];
            return itemName;
        }
        public static float GetItemWeights(int menuItem)
        {
            float[] candyItemWeights = new float[10];

            candyItemWeights[0] = 7f;
            candyItemWeights[1] = 6f;
            candyItemWeights[2] = 10f;
            candyItemWeights[3] = 13f;
            candyItemWeights[4] = 4f;
            candyItemWeights[5] = 13f;
            candyItemWeights[6] = 8f;
            candyItemWeights[7] = 7f;
            candyItemWeights[8] = 12f;
            candyItemWeights[9] = 10f;

            float itemWeight = candyItemWeights[menuItem];
            return itemWeight;
        }
    }
}
    

