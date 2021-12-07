using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodisAutomaten
{
    public partial class Menu
    {
        public static void MenuRandomSelection()
        {
            //Checkout randomChoiceCart = new Checkout();

            Console.ForegroundColor = ConsoleColor.White;

            string[] menuOptions = new string[] { " [Generera slumpmässigt blandad godispåse]\t", " [Genomför betalning]\t", "\n [Tillbaka till huvudmenyn]\t" };
            int MenuChoice = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" GodisAutomaten: Generera slumpmässig godisblandning");
                Console.WriteLine(" ***************************************************");
                //Console.WriteLine(" Pris {0} kr/hg\n", randomChoiceCart.GeneralPriceProperty);
                ProductData.DisplayGeneralPrice();

                Console.CursorVisible = false;

                if (MenuChoice == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[0] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                }
                else if (MenuChoice == 1)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[1] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuOptions[2]);
                }
                else if (MenuChoice == 2)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[2] + "");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                var keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.DownArrow && MenuChoice <= 1)
                {
                    MenuChoice++;
                }
                else if (keyPress.Key == ConsoleKey.UpArrow && MenuChoice >= 1)
                {
                    MenuChoice--;
                }
                else if (keyPress.Key == ConsoleKey.Enter)
                {
                    switch (MenuChoice)
                    {
                        case 0:                            
                            Console.WriteLine();
                            try
                            {
                                // Användarens val av vikt för den slumpmässiga godisblandningen lagras i variabeln "maxTotalWeight".
                                Console.CursorVisible = true;
                                Console.Write(" Ange önskad vikt i gram för den slumpmässigt utvalda godisblandningen: ");
                                int maxTotalWeight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                Console.CursorVisible = false;

                                // Användarens val av antal godissorter att inkludera i slumpurvalet lagras i variabeln "maxTotalSorts".
                                Console.CursorVisible = true;
                                Console.Write(" Ange hur många olika godissorter blandningen skall innehålla: ");
                                int maxTotalSorts = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                Console.CursorVisible = false;

                                RandomSelection(maxTotalSorts, maxTotalWeight);
                                Console.WriteLine();
                                Console.ReadKey();
                            }
                            catch (FormatException)
                            {
                                Console.CursorVisible = false;
                                Console.WriteLine();
                                Console.WriteLine(" Var god ange heltal\n");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine(" Tryck valfri tangent för att försöka igen.");
                                MenuRandomSelection();
                            }
                            break;
                        case 1:
                            MenuCheckout();
                            break;
                        default:
                            MainMenu();
                            break;
                    }
                }
                // Metod som slumpar fram valt antal godissorter med antal bitar per sorts begränsat till vald total maxvikt.
                // Data om namn och vikt hämtas ur den lokala listor som i sin tur hämtar information från listorna i klassen "ProductData".
                // Innehållet i variabeln "maxAmountItems" bestämmer hur många sorter som ska inkluderas i slumpurvalet. 
                // Innehållet i variabeln "maxAmountItems" bestämmer maxvikt för blandningen. 
                void RandomSelection(int maxTotalSorts, int maxTotalWeight)
                {
                    string[] selectedItemNames = new string[10];

                    selectedItemNames[0] = ProductData.GetItemNames(0);
                    selectedItemNames[1] = ProductData.GetItemNames(1);
                    selectedItemNames[2] = ProductData.GetItemNames(2);
                    selectedItemNames[3] = ProductData.GetItemNames(3);
                    selectedItemNames[4] = ProductData.GetItemNames(4);
                    selectedItemNames[5] = ProductData.GetItemNames(5);
                    selectedItemNames[6] = ProductData.GetItemNames(6);
                    selectedItemNames[7] = ProductData.GetItemNames(7);
                    selectedItemNames[8] = ProductData.GetItemNames(8);
                    selectedItemNames[9] = ProductData.GetItemNames(9);

                    float[] selectedItemWeights = new float[10];

                    selectedItemWeights[0] = ProductData.GetItemWeights(0);
                    selectedItemWeights[1] = ProductData.GetItemWeights(1);
                    selectedItemWeights[2] = ProductData.GetItemWeights(2);
                    selectedItemWeights[3] = ProductData.GetItemWeights(3);
                    selectedItemWeights[4] = ProductData.GetItemWeights(4);
                    selectedItemWeights[5] = ProductData.GetItemWeights(5);
                    selectedItemWeights[6] = ProductData.GetItemWeights(6);
                    selectedItemWeights[7] = ProductData.GetItemWeights(7);
                    selectedItemWeights[8] = ProductData.GetItemWeights(8);
                    selectedItemWeights[9] = ProductData.GetItemWeights(9);

                    Random rnd = new Random();

                    // Loopen genererar en slumpmässig godisblandning givet användarens begränsningar avseende antal sorter och maxvikt.
                    // Vald maxvikt multipliceras med priset per hekto som hämtas via metoden "products.GetPrice()" i klassen "ProductData".
                    // Aktuellt pris lagras i variabeln "checkoutPrice" i klassen "subMenuPayment" för åtkomst i betalningssteget.
                                        
                    for (int i = 0; i < maxTotalSorts; ++i)
                    {
                        int index = rnd.Next(selectedItemNames.Length);
                        string selectedRandomSorts = selectedItemNames[index];

                        float maxWeightPerSort = maxTotalWeight / maxTotalSorts;
                        float maxAmountPerSort = maxWeightPerSort / selectedItemWeights[index];

                        float sumSelectionWeightHG = maxTotalWeight / 100;

                        Checkout.SetCheckoutWeightStatic(sumSelectionWeightHG);
                        Checkout.CalculateCheckoutPriceStatic(sumSelectionWeightHG);

                        Console.WriteLine(" {0}, {1} st", selectedRandomSorts, Math.Round(maxAmountPerSort, 0));
                    }
                    Checkout.DisplayCheckoutPriceStaticVoid();
                }
            }
        }
    }  
}
