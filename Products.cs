using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    public class Products
    {
        private decimal price = 5.90M;

        public void SetPrice(int price)
        {
            this.price = price;
        }
        public decimal GetPrice()
        {
            return this.price;
        }
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
        public static decimal GetItemWeights(int menuItem)
        {
            decimal[] candyItemWeights = new decimal[10];

            candyItemWeights[0] = 7M;
            candyItemWeights[1] = 6M;
            candyItemWeights[2] = 10M;
            candyItemWeights[3] = 13M;
            candyItemWeights[4] = 4M;
            candyItemWeights[5] = 13M;
            candyItemWeights[6] = 8M;
            candyItemWeights[7] = 7M;
            candyItemWeights[8] = 12M;
            candyItemWeights[9] = 10M;

            decimal itemWeight = candyItemWeights[menuItem];
            return itemWeight;
        }
    }
}
    

