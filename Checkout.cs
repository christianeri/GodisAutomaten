using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodisAutomaten
{
    public class Checkout : ProductData
    {
        private static float checkoutPriceStatic;
        public static void CalculateCheckoutPriceStatic(float sumSelectionWeightHG)
        {
            checkoutPriceStatic = sumSelectionWeightHG * generalPriceStatic;
        }
        public static float GetPurchasePriceStaticFloat()
        {
            return checkoutPriceStatic;
        }

        private static float checkoutWeightStatic;
        public static void SetCheckoutWeightStatic(float sumSelectionWeightHG)
        {
            checkoutWeightStatic = sumSelectionWeightHG;
        }
        public static float GetCheckoutWeightStaticFloat()
        {
            return checkoutWeightStatic;
        }

        public static void DisplayCheckoutPriceStaticVoid()
        {
            Console.WriteLine(" Pris: {0} kr/hg", generalPriceStatic);
            Console.WriteLine(" Vikt: {0} hg", Math.Round(checkoutWeightStatic, 2));
            Console.WriteLine("\n Att betala: {0} kr\n", Math.Round(checkoutPriceStatic, 2));
        }

        /*
        // Kan ersättas med 1x #public float CheckoutWeightProperty { get; set; }#
        private float checkoutWeight;
        public float CheckoutWeightProperty         
        {
            get
            {
                return this.checkoutWeight;
            }
            set
            {
                this.checkoutWeight = value;
            }
        }
        //.
        // Kan ersättas med 1x #public float CheckoutPriceProperty { get; set; }#  
        private float checkoutPrice;
        public float CheckoutPriceProperty       
        {
            get
            {
                return this.CheckoutWeightProperty*generalPriceStatic;
            }
        }
        //.
        public void SetCheckoutWeight(float sumSelectionWeightHG)
        {
            this.checkoutWeight = sumSelectionWeightHG;
        }
        public void DisplayCheckoutPrice()
        {
            Console.WriteLine(" Vikt: {0} hg", Math.Round(this.CheckoutWeightProperty, 2));
            Console.WriteLine(" Pris: {0} kr/hg", generalPriceStatic);
            Console.WriteLine(" Att betala: {0} kr/hg", Math.Round(this.CheckoutPriceProperty, 2));
        }
        */
    }
}
