using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachine
{
    static class UserInterface
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static string GetUserInputString(string prompt)
        {
            Console.WriteLine(prompt);
            string userInput = Console.ReadLine();
            return userInput;
        }

        public static string SelectBeverage()
        {
            int choice;
            List<Can> beverages = new List<Can>() { new Cola(), new Orange(), new RootBeer() };
            Console.WriteLine("Please input selection number");
            for (int i = 0; i < beverages.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {beverages[i].name}");
            }
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID input, please enter a number");
                return SelectBeverage();
            }
            else if (choice > 3 || choice < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID option, please select again");
                return SelectBeverage();
            }
            var beverage = beverages[choice].name;
            return beverage;
        }
        public static int MethodOfPayment()
        {
            int choice;
            Console.WriteLine("How would you like to pay?");
            Console.WriteLine("Please input selection number");
            Console.WriteLine("1) Coin");
            Console.WriteLine("2) Card");
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID input, please enter a number");
                return MethodOfPayment();
            }
            else if (choice > 2 || choice < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("INVALID option, please select again");
                return MethodOfPayment();
            }
            return choice;
        }
        //public static string CoinOption()
        //{

        //}
        public static string SelectCoin()
        {
            Console.WriteLine("What coin would you like to insert?");
            Console.WriteLine("Please input selection number");
            Console.WriteLine("1) Quarters\n2) Dimes\n3) Nickels\n4) Pennies");
            string coin = Console.ReadLine();
            switch (coin)
            {
                case "1":
                    return "quarter";
                case "2":
                    return "dime";
                case "3":
                    return "nickel";
                case "4":
                    return "penny";
                default:
                    Console.WriteLine("Please input valid selection number");
                    return SelectCoin();

            }
        }
        //public static int QuantityCoins()
        //{
        //    Console.WriteLine("Please choose what coins to insert");
        //    Console.WriteLine("1) Quarters\n2) Dimes\n3) Nickels\n4) Pennies");
        //    string coin = Console.ReadLine();
        //    switch (coin)
        //    {
        //        case "1":
        //            return "quarter";
        //        case "2":
        //            return "dime";
        //        case "3":
        //            return "nickel";
        //        case "4":
        //            return "penny";
        //        default:
        //            Console.WriteLine("Please input valid selection number");
        //            return CoinOption();

        //    }
        //}
        //public static void CoinOption()
        //{
        //    List<string> coinOptions = new List<string>() { "Quarters", "Dimes", "Nickels", "Pennies" };
        //    Console.WriteLine("Please choose what coins to insert");
        //    for (int i = 0; i < beverages.Count; i++)
        //    {
        //        Console.WriteLine($"{i + 1}) {beverages[i].name}");
        //    }
        //    string userInput = Console.ReadLine();
        //    if (!int.TryParse(userInput, out choice))
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("INVALID input, please enter a number");
        //        return SelectBeverage();
        //    }
        //    else if (choice > 3 || choice < 0)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine("INVALID option, please select again");
        //        return SelectBeverage();
        //    }
        //    var beverage = beverages[choice].name;
        //    return beverage;
        //}
        public static void CardOption()
        {

        }
        public static void DisplayWallet(Wallet wallet)
        {
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
            foreach (Coin coin in wallet.coins)
            {
                if (coin.name == "quarter")
                {
                    quarters++;
                }
                else if (coin.name == "dime")
                {
                    dimes++;
                }
                else if (coin.name == "nickel")
                {
                    nickels++;
                }
                else if (coin.name == "penny")
                {
                    pennies++;
                }
            }
            Console.WriteLine($"You have {quarters} quarters, {dimes} dimes, {nickels} nickels, {pennies} pennies\nIn your wallet");
        }
    }
}
