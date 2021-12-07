using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    partial class Menu
    {
        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string[] menuOptions = new string[] { " [Välj godis från lista]\t", " [Slumpvist blandad godispåse]\t", "\n [Avsluta]\t" };
            int menuChoice = 0;

            while (true)            
            {
                Console.Clear();                // Rensar skärmen.
                Console.CursorVisible = false;  // Döljer prompten.

                // Skapar en instans "products" av objektet "ProductData" för att kunna anropa Get-metoden "GetPrice" i klassen "ProductData".
                ProductData products = new ProductData();

                Console.WriteLine();
                Console.WriteLine(" GodisAutomaten: Huvudmeny");
                Console.WriteLine(" *************************");
                // Kör metod som hämtar aktuellt pris från klassen "ProductData". 
                Console.WriteLine(" Pris {0} kr/hg\n", products.GetPrice());


                // Piltangentsmeny enligt videoföreläsning i Novo.
                if (menuChoice == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[0] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuOptions[1]);
                    Console.WriteLine(menuOptions[2]);
                }
                else if (menuChoice == 1)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[1] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuOptions[2]);
                }
                else if (menuChoice == 2)
                {
                    Console.WriteLine(menuOptions[0]);
                    Console.WriteLine(menuOptions[1]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(menuOptions[2] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var keyPress = Console.ReadKey(); // Variablen >var< innehåller tangentbordsinmatning.

                if (keyPress.Key == ConsoleKey.DownArrow && menuChoice <= 2)
                {
                    menuChoice++;
                }
                else if (keyPress.Key == ConsoleKey.UpArrow && menuChoice >= 1)
                {
                    menuChoice--;
                }
                else if (keyPress.Key == ConsoleKey.Enter)
                {
                    switch (menuChoice)
                    {
                        case 0:
                            Menu.MenuManualSelection();
                            break;
                        case 1:
                            Menu.MenuRandomSelection();
                            break;
                        default:
                            ExitProgram();
                            break;
                    }
                }
                void ExitProgram()
                {
                    Console.Clear();
                    Console.WriteLine(" Tack för att du har använt GodisAutomaten. Välkommen åter!");
                    Console.ReadKey();
                    Environment.Exit(1);
                }
            }
        }
    }
}
