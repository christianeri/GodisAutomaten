using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slutprojekt
{
    class SubMenuManualSelection
    {
        public static void SubMenu1()
        {
            Console.Clear();                // Rensar skärmen.

            Products products = new Products();
            SubMenuPayment checkout = new SubMenuPayment();

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

            // Data om de olika godissorterna finns i listor som ligger i klassen >Products<.
            // Arrayen >menuItems< hämtar information från listorna via metoderna >getItem*<.
            string[] menuItems = new string[13];

            menuItems[0] = " 01 " + Products.GetItemNames(0);
            menuItems[1] = " 02 " + Products.GetItemNames(1);
            menuItems[2] = " 03 " + Products.GetItemNames(2);
            menuItems[3] = " 04 " + Products.GetItemNames(3);
            menuItems[4] = " 05 " + Products.GetItemNames(4);
            menuItems[5] = " 06 " + Products.GetItemNames(5);
            menuItems[6] = " 07 " + Products.GetItemNames(6);
            menuItems[7] = " 08 " + Products.GetItemNames(7);
            menuItems[8] = " 09 " + Products.GetItemNames(8);
            menuItems[9] = " 10 " + Products.GetItemNames(9);
            menuItems[10] = "\n [Visa godispåse]";
            menuItems[11] = " [Genomför köp]";
            menuItems[12] = "\n [Tillbaka till föregående meny]";

            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;  // Döljer prompten.

                Console.WriteLine("\n GodisAutomaten: Välj godis");
                Console.WriteLine(" **************************");
                Console.WriteLine(" Pris {0} kr/hg", products.GetPrice());
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

                // Om användare trycker så pass många gånger på Upp- eller nertangenten att övre eller nedre slut på listan nås
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
                        // Testade att koppla switch case till >counter< för att spara plats i koden som ovan men fick beskedet att "a constant value is expected".
                        case 0:
                            // De olika godissorternas countervariabler lagrar antalet bitar av varje godissort som användaren lagt i godispåsen(varukorgen).
                            // Varje gång användaren trycker på ENTER så lagras en bit i countern.
                            counter0++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter0, Products.GetItemNames(0));
                            Console.ReadKey();
                            break;
                        case 1:
                            counter1++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter1, Products.GetItemNames(1));
                            Console.ReadKey();
                            break;
                        case 2:
                            counter2++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter2, Products.GetItemNames(2));
                            Console.ReadKey();
                            break;
                        case 3:
                            counter3++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter3, Products.GetItemNames(3));
                            Console.ReadKey();
                            break;
                        case 4:
                            counter4++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter4, Products.GetItemNames(4));
                            Console.ReadKey();
                            break;
                        case 5:
                            counter5++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter5, Products.GetItemNames(5));
                            Console.ReadKey();
                            break;
                        case 6:
                            counter6++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter6, Products.GetItemNames(6));
                            Console.ReadKey();
                            break;
                        case 7:
                            counter7++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter7, Products.GetItemNames(7));
                            Console.ReadKey();
                            break;
                        case 8:
                            counter8++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter8, Products.GetItemNames(8));
                            Console.ReadKey();
                            break;
                        case 9:
                            counter9++;
                            Console.WriteLine(" Du har {0} {1} i påsen.", counter9, Products.GetItemNames(9));
                            Console.ReadKey();
                            break;
                        case 10:
                            // Visar användaren hur många bitar av de olika godissorterna och dess vikt som lagts i godispåsen.
                            Console.CursorVisible = false;
                            Console.WriteLine(" Din godispåse innehåller:");
                            Console.WriteLine(" *************************");
                            Console.WriteLine(" 01 {0}.\t {1} st á {2} gram/st.", Products.GetItemNames(0), counter0, Products.GetItemWeights(0));
                            Console.WriteLine(" 02 {0}.\t\t {1} st á {2} gram/st.", Products.GetItemNames(1), counter1, Products.GetItemWeights(1));
                            Console.WriteLine(" 03 {0}.\t\t {1} st á {2} gram/st.", Products.GetItemNames(2), counter2, Products.GetItemWeights(2));
                            Console.WriteLine(" 04 {0}.\t\t {1} st á {2} gram/st.", Products.GetItemNames(3), counter3, Products.GetItemWeights(3));
                            Console.WriteLine(" 05 {0}.\t {1} st á {2} gram/st.", Products.GetItemNames(4), counter4, Products.GetItemWeights(4));
                            Console.WriteLine(" 06 {0}.\t\t {1} st á {2} gram/st.", Products.GetItemNames(5), counter5, Products.GetItemWeights(5));
                            Console.WriteLine(" 07 {0}.\t\t\t {1} st á {2} gram/st.", Products.GetItemNames(6), counter6, Products.GetItemWeights(6));
                            Console.WriteLine(" 08 {0}.\t\t\t {1} st á {2} gram/st.", Products.GetItemNames(7), counter7, Products.GetItemWeights(7));
                            Console.WriteLine(" 09 {0}.\t\t {1} st á {2} gram/st.", Products.GetItemNames(8), counter8, Products.GetItemWeights(8));
                            Console.WriteLine(" 10 {0}.\t\t\t {1} st á {2} gram/st.", Products.GetItemNames(9), counter9, Products.GetItemWeights(9));

                            // Kör metod som beräknar priset för innehållet i godispåsen/varukorgen.
                            CalculateCheckoutPrice();

                            // Visar vikt och pris. Math.Round rundar av decimalvärdet "checkoutWeight" för att slippa onödiga decimaler.
                            Console.WriteLine();
                            Console.WriteLine(" Vikt: {0} hg.", Math.Round(SubMenuPayment.checkoutWeight, 2));
                            Console.WriteLine(" Pris: {0} kr/hg.", products.GetPrice());

                            // Math.Round rundar av decimalvärdet "checkoutPrice" för att slippa onödiga decimaler.
                            Console.WriteLine("\n Att betala: {0} kr.", Math.Round(SubMenuPayment.checkoutPrice, 2));
                            Console.ReadKey();                            
                            break;
                        case 11:
                            // Kör metod i klassen "Purchase" som tar användaren till en separat meny som innehåller betalningsalternativ.
                            SubMenuPayment.PaymentMenu();
                            break;
                        default:
                            Menu.MainMenu();
                            break;
                    }
                    // Metoden hämtar information om vikt per styck för de olika godissorterna från listan i klassen "Products" och multiplicerar med
                    // antalet bitar i godispåsen vilket lagras i variabeln "checkoutPrice" i klassen "subMenuPayment" för åtkomst i betalningssteget.
                    void CalculateCheckoutPrice()
                    {
                        decimal item0Weight = counter0 * Products.GetItemWeights(0);
                        decimal item1Weight = counter1 * Products.GetItemWeights(1);
                        decimal item2Weight = counter2 * Products.GetItemWeights(2);
                        decimal item3Weight = counter3 * Products.GetItemWeights(3);
                        decimal item4Weight = counter4 * Products.GetItemWeights(4);
                        decimal item5Weight = counter5 * Products.GetItemWeights(5);
                        decimal item6Weight = counter6 * Products.GetItemWeights(6);
                        decimal item7Weight = counter7 * Products.GetItemWeights(7);
                        decimal item8Weight = counter8 * Products.GetItemWeights(8);
                        decimal item9Weight = counter9 * Products.GetItemWeights(9);

                        decimal sumCheckoutWeight = item0Weight + item1Weight + item2Weight + item3Weight + item4Weight + item5Weight + item6Weight + item7Weight + item8Weight + item9Weight;
                        
                        decimal checkoutWeightHg = sumCheckoutWeight / 100; 
                        decimal localPrice = products.GetPrice();

                        SubMenuPayment.checkoutWeight = checkoutWeightHg;
                        SubMenuPayment.checkoutPrice = localPrice * checkoutWeightHg;
                    }                                  
                }
            }
        }
    }
}
