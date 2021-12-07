using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodisAutomaten
{
    public partial class Menu
    {
        public static void MenuCheckout()
        {
            Console.ForegroundColor = ConsoleColor.White;

            string[] paymentMenuOptions = new string[] { " [Betala med Swish]\t", " [Betala med kort]\t", "\n [Tillbaka till huvudmenyn]\t" };
            int paymentMenuChoice = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine(" GodisAutomaten: Betalning");
                Console.WriteLine(" *************************");
                Console.CursorVisible = false;

                if (paymentMenuChoice == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(paymentMenuOptions[0] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(paymentMenuOptions[1]);
                    Console.WriteLine(paymentMenuOptions[2]);
                }
                else if (paymentMenuChoice == 1)
                {
                    Console.WriteLine(paymentMenuOptions[0]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(paymentMenuOptions[1] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(paymentMenuOptions[2]);
                }
                else if (paymentMenuChoice == 2)
                {
                    Console.WriteLine(paymentMenuOptions[0]);
                    Console.WriteLine(paymentMenuOptions[1]);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(paymentMenuOptions[2] + "");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                var keyPress = Console.ReadKey();

                if (keyPress.Key == ConsoleKey.DownArrow && paymentMenuChoice <= 2)
                {
                    paymentMenuChoice++;
                }
                else if (keyPress.Key == ConsoleKey.UpArrow && paymentMenuChoice >= 1)
                {
                    paymentMenuChoice--;
                }
                else if (keyPress.Key == ConsoleKey.Enter)
                {
                    switch (paymentMenuChoice)
                    {
                        case 0:
                            Menu.PaymentOptionSwish();
                            break;
                        case 1:
                            Menu.PaymentOptionCard();
                            break;
                        default:
                            Menu.MainMenu();
                            break;
                    }
                }

            }
        }
        public static void PaymentOptionSwish()
        {           
            Console.Clear();

            Checkout.DisplayCheckoutPriceStaticVoid();

            Console.WriteLine(" Swisha din betalning till nummer 123987456 och tryck ENTER");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine(" Tack för att du har använt GodisAutomaten. Välkommen åter!");
            Console.ReadKey();
            Environment.Exit(1);
        }
        public static void PaymentOptionCard()
        {
            Console.Clear();
            Console.WriteLine();
            
            Checkout.DisplayCheckoutPriceStaticVoid();
            
            Console.WriteLine(" Sätt in ditt kort");
            Console.WriteLine("  ______________________");
            Console.WriteLine(" |______________________|\n");
            Console.CursorVisible = true;
            Console.Write(" Ange din kod och avsluta med ENTER: ");
            try
            {
                int pinCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.CursorVisible = false;
                Console.WriteLine();
                Console.WriteLine(" Var god ange pinkod bestående av fyra siffror.\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Tryck valfri tangent för att försöka igen.");
                Console.ReadKey();
                PaymentOptionCard();
            }
            Console.CursorVisible = false;
            Console.WriteLine();
            Console.WriteLine(" Tack för att du har använt GodisAutomaten. Välkommen åter!");
            Console.ReadKey();
            Environment.Exit(1);
        }
    }    
}
