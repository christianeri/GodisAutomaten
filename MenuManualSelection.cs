using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodisAutomaten
{
    public partial class Menu
    {
        public static void MenuManualSelection()
        {
            //Checkout manualChoiceCart = new Checkout();

            Console.Clear(); // Rensar skärmen.

            int counter0 = 0;
            int counter1 = 0;
            int counter2 = 0;
            int counter3 = 0;
            int counter4 = 0;
            int counter5 = 0;
            int counter6 = 0;
            int counter7 = 0;
            int counter8 = 0;
            int counter9 = 0;

            // Det skulle bli många rader kod för att göra undermenyn på samma sätt som huvudmenyn.
            // Hittade nedanstående meny via Google på: https://www.dreamincode.net/forums/topic/365540-Console-Menu-with-Arrowkeys/.
            // Modifierade med delar från huvudmenyn för att få den att fungera korrekt.

            // A variable to keep track of the current Item, and a simple counter.
            int subMenuChoice = 0, counter;

            // The object to read in a key
            ConsoleKeyInfo keyPress;

            // Data om de olika godissorterna finns i listor som ligger i klassen >ProductData<.
            // Arrayen >menuItems< hämtar information från listorna via metoderna >getItem*<.
            string[] menuItems = new string[13];

            menuItems[0] = " 01 " + ProductData.GetItemNames(0);
            menuItems[1] = " 02 " + ProductData.GetItemNames(1);
            menuItems[2] = " 03 " + ProductData.GetItemNames(2);
            menuItems[3] = " 04 " + ProductData.GetItemNames(3);
            menuItems[4] = " 05 " + ProductData.GetItemNames(4);
            menuItems[5] = " 06 " + ProductData.GetItemNames(5);
            menuItems[6] = " 07 " + ProductData.GetItemNames(6);
            menuItems[7] = " 08 " + ProductData.GetItemNames(7);
            menuItems[8] = " 09 " + ProductData.GetItemNames(8);
            menuItems[9] = " 10 " + ProductData.GetItemNames(9);
            menuItems[10] = "\n [Visa godispåse]";
            menuItems[11] = " [Genomför köp]";
            menuItems[12] = "\n [Tillbaka till föregående meny]";

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;  // Döljer prompten.

                Console.WriteLine("\n GodisAutomaten: Välj godis");
                Console.WriteLine(" **************************");
                //Console.WriteLine(" Pris {0} kr/hg", manualChoiceCart.GeneralPriceProperty);
                ProductData.DisplayGeneralPrice();
                Console.WriteLine("\n Välj godissort med piltangenterna och tryck ENTER en gång för att lägga till en styck av vald godissort i påsen.");
                Console.WriteLine(" Tips: Håll in ENTER för att lägga till mer på en gång!\n");

                // Loopen går igenom posterna i listan "menuItems" så länge countern värde < än listans längd.
                for (counter = 0; counter < menuItems.Length; counter++)
                {
                    // Om "subMenuChoice" som håller reda på var användarens menyval är i förhållande till listan
                    // är lika med countern så ändras färgen på det aktuella menyvalet.
                    if (subMenuChoice == counter)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(menuItems[counter]);
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Om inte visas listan i vitt.
                    else
                    {
                        Console.WriteLine(menuItems[counter]);
                    }
                }
                Console.WriteLine();

                // Om TRUE att användaren trycker på en tangent lagras inmatningen i "keyPress".
                keyPress = Console.ReadKey(true);

                // Om användaren trycker så pass många gånger på Upp- eller nertangenten att övre eller nedre slut på listan nås
                // så minskar respektive ökar countern "subMenuChoice" så att användare inte kan gå utanför listan.
                if (keyPress.Key == ConsoleKey.DownArrow && subMenuChoice <= 11)
                {
                    subMenuChoice++;
                }
                else if (keyPress.Key == ConsoleKey.UpArrow && subMenuChoice >= 1)
                {
                    subMenuChoice--;
                }
                else if (keyPress.Key == ConsoleKey.Enter)
                {
                    switch (subMenuChoice)
                    {                        
                        case 0:
                            // De olika godissorternas countervariabler lagrar antalet bitar av varje godissort som användaren lagt i godispåsen(varukorgen).
                            // Varje gång användaren trycker på ENTER så lagras en bit i countern.
                            counter0++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter0, ProductData.GetItemNames(0));
                            Console.Read();
                            break;
                        case 1:
                            counter1++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter1, ProductData.GetItemNames(1));
                            Console.ReadKey();
                            break;
                        case 2:
                            counter2++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter2, ProductData.GetItemNames(2));
                            Console.ReadKey();
                            break;
                        case 3:
                            counter3++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter3, ProductData.GetItemNames(3));
                            Console.ReadKey();
                            break;
                        case 4:
                            counter4++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter4, ProductData.GetItemNames(4));
                            Console.ReadKey();
                            break;
                        case 5:
                            counter5++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter5, ProductData.GetItemNames(5));
                            Console.ReadKey();
                            break;
                        case 6:
                            counter6++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter6, ProductData.GetItemNames(6));
                            Console.ReadKey();
                            break;
                        case 7:
                            counter7++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter7, ProductData.GetItemNames(7));
                            Console.ReadKey();
                            break;
                        case 8:
                            counter8++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter8, ProductData.GetItemNames(8));
                            Console.ReadKey();
                            break;
                        case 9:
                            counter9++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter9, ProductData.GetItemNames(9));
                            Console.ReadKey();
                            break;
                        case 10:
                            CalculateCurrentCartPrice();
                            Console.ReadKey();                            
                            break;
                        case 11:
                            Menu.MenuCheckout();
                            break;
                        default:
                            Menu.MainMenu();
                            break;
                    }
                                                   
                }
            }
            // Metoden hämtar information om vikt per styck för de olika godissorterna från listan i klassen "ProductData" och multiplicerar med
            // antalet bitar i godispåsen vilket lagras i variabeln "checkoutPrice" i klassen "subMenuPayment" för åtkomst i betalningssteget.
            void CalculateCurrentCartPrice()
            {
                float item0Weight = counter0 * ProductData.GetItemWeights(0);
                float item1Weight = counter1 * ProductData.GetItemWeights(1);
                float item2Weight = counter2 * ProductData.GetItemWeights(2);
                float item3Weight = counter3 * ProductData.GetItemWeights(3);
                float item4Weight = counter4 * ProductData.GetItemWeights(4);
                float item5Weight = counter5 * ProductData.GetItemWeights(5);
                float item6Weight = counter6 * ProductData.GetItemWeights(6);
                float item7Weight = counter7 * ProductData.GetItemWeights(7);
                float item8Weight = counter8 * ProductData.GetItemWeights(8);
                float item9Weight = counter9 * ProductData.GetItemWeights(9);

                float sumSelectionWeight = item0Weight + item1Weight + item2Weight + item3Weight + item4Weight
                    + item5Weight + item6Weight + item7Weight + item8Weight + item9Weight;

                float sumSelectionWeightHG = sumSelectionWeight / 100;

                Console.WriteLine(" Din godispåse innehåller:");
                Console.WriteLine(" *************************");
                Console.WriteLine(" 01 {0}:\t {1} gram ({2} bitar)", ProductData.GetItemNames(0), item0Weight, counter0);
                Console.WriteLine(" 02 {0}:\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(1), item1Weight, counter1);
                Console.WriteLine(" 03 {0}:\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(2), item2Weight, counter2);
                Console.WriteLine(" 04 {0}:\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(3), item3Weight, counter3);
                Console.WriteLine(" 05 {0}:\t {1} gram ({2} bitar)", ProductData.GetItemNames(4), item4Weight, counter4);
                Console.WriteLine(" 06 {0}:\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(5), item5Weight, counter5);
                Console.WriteLine(" 07 {0}:\t\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(6), item6Weight, counter6);
                Console.WriteLine(" 08 {0}:\t\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(7), item7Weight, counter7);
                Console.WriteLine(" 09 {0}:\t\t {1} gram ({2} bitar)", ProductData.GetItemNames(8), item8Weight, counter8);
                Console.WriteLine(" 10 {0}:\t\t\t {1} gram ({2} bitar)\n", ProductData.GetItemNames(9), item9Weight, counter9);

                // Set #private static float checkoutPriceStatic# using #Checkout.CalculateCheckoutPriceStatic(sumSelectionWeightHG)#
                Checkout.SetCheckoutWeightStatic(sumSelectionWeightHG);
                Checkout.CalculateCheckoutPriceStatic(sumSelectionWeightHG);
                
                //Console.Write("GetPurchasePriceStaticFloat:");
                //Console.WriteLine(" Att betala: {0} kr/hg", Math.Round(Checkout.GetPurchasePriceStaticFloat(), 2));          

                Checkout.DisplayCheckoutPriceStaticVoid();

                //manualChoiceCart.SetCheckoutWeight(sumSelectionWeightHG); // Ange som parameters
                // Ange PROPERTY #CheckoutWeightProperty# via {GET;SET;}
                //manualChoiceCart.CheckoutWeightProperty = sumSelectionWeightHG; 

                //Console.WriteLine("DisplayCheckoutPrice using PROPERTIES");
                //manualChoiceCart.DisplayCheckoutPrice();
            }
        }
    }
}
