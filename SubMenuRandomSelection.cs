using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class SubMenuRandomSelection
    {
        public static void SubMenu2()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Products products = new Products();

            string[] menuOptions = new string[] { " [Generera slumpmässigt blandad godispåse]\t", " [Genomför betalning]\t", "\n [Tillbaka till huvudmenyn]\t" };
            int MenuChoice = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" GodisAutomaten: Generera slumpmässig godisblandning");
                Console.WriteLine(" ***************************************************");
                Console.WriteLine(" Pris {0} kr/hg\n", products.GetPrice());

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
                                Console.CursorVisible = false;

                                // Användarens val av antal godissorter att inkludera i slumpurvalet lagras i variabeln "maxTotalSorts".
                                Console.CursorVisible = true;
                                Console.Write(" Ange hur många olika godissorter blandningen skall innehålla: ");
                                int maxTotalSorts = Convert.ToInt32(Console.ReadLine());
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
                                SubMenu2();
                            }
                            break;
                        case 1:
                            SubMenuPayment.PaymentMenu();
                            break;
                        default:
                            Menu.MainMenu();
                            break;
                    }
                }
                // Metod som slumpar fram valt antal godissorter med antal bitar per sorts begränsat till vald total maxvikt.
                // Data om namn och vikt hämtas ur den lokala listor som i sin tur hämtar information från listorna i klassen "Products".
                // Innehållet i variabeln "maxAmountItems" bestämmer hur många sorter som ska inkluderas i slumpurvalet. 
                // Innehållet i variabeln "maxAmountItems" bestämmer maxvikt för blandningen. 
                void RandomSelection(int maxTotalSorts, int maxTotalWeight)
                {
                    string[] selectedItemNames = new string[10];

                    selectedItemNames[0] = Products.GetItemNames(0);
                    selectedItemNames[1] = Products.GetItemNames(1);
                    selectedItemNames[2] = Products.GetItemNames(2);
                    selectedItemNames[3] = Products.GetItemNames(3);
                    selectedItemNames[4] = Products.GetItemNames(4);
                    selectedItemNames[5] = Products.GetItemNames(5);
                    selectedItemNames[6] = Products.GetItemNames(6);
                    selectedItemNames[7] = Products.GetItemNames(7);
                    selectedItemNames[8] = Products.GetItemNames(8);
                    selectedItemNames[9] = Products.GetItemNames(9);

                    decimal[] selectedItemWeights = new decimal[10];

                    selectedItemWeights[0] = Products.GetItemWeights(0);
                    selectedItemWeights[1] = Products.GetItemWeights(1);
                    selectedItemWeights[2] = Products.GetItemWeights(2);
                    selectedItemWeights[3] = Products.GetItemWeights(3);
                    selectedItemWeights[4] = Products.GetItemWeights(4);
                    selectedItemWeights[5] = Products.GetItemWeights(5);
                    selectedItemWeights[6] = Products.GetItemWeights(6);
                    selectedItemWeights[7] = Products.GetItemWeights(7);
                    selectedItemWeights[8] = Products.GetItemWeights(8);
                    selectedItemWeights[9] = Products.GetItemWeights(9);

                    Random rnd = new Random();

                    // Loopen genererar en slumpmässig godisblandning givet användarens begränsningar avseende antal sorter och maxvikt.
                    // Vald maxvikt multipliceras med priset per hekto som hämtas via metoden "products.GetPrice()" i klassen "Products".
                    // Aktuellt pris lagras i variabeln "checkoutPrice" i klassen "subMenuPayment" för åtkomst i betalningssteget.
                    for (int i = 0; i < maxTotalSorts; ++i)
                    {
                        int index = rnd.Next(selectedItemNames.Length);
                        string selectedRandomSorts = selectedItemNames[index];

                        decimal maxWeightPerSort = maxTotalWeight / maxTotalSorts;
                        decimal maxAmountPerSort = maxWeightPerSort / selectedItemWeights[index];

                        decimal checkoutWeightHg = maxTotalWeight / 100;
                        decimal localPrice = products.GetPrice();

                        SubMenuPayment.checkoutPrice = localPrice * checkoutWeightHg;

                        Console.WriteLine();
                        Console.Write(" {0}, {1} st", selectedRandomSorts, Math.Round(maxAmountPerSort, 0));
                    }
                }
            }
        }
    }  
}
