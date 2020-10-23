using System;

namespace SodaMachine
{
    static class UserInterface
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
        public static string SelectBeverage()
        {
            Console.WriteLine("\nPlease input selection number");
            Console.WriteLine("1) ORANGE SODA\n2) COLA\n3) ROOT BEER\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "orange";
                case "2":
                    return "cola";
                case "3":
                    return "rootBeer";
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input valid selection number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return SelectBeverage();
            }
        }
        public static bool MethodOfPayment()
        {
            Console.WriteLine("How would you like to pay?\n");
            Console.WriteLine("Please input selection number");
            Console.WriteLine("1) COIN\n2) CARD\n");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input valid selection number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return MethodOfPayment();
            }
        }
        public static string SelectCoin()
        {
            Console.WriteLine("What coin would you like to insert?\n");
            Console.WriteLine("Please input selection number");
            Console.WriteLine("1) QUARTERS\n2) DIMES\n3) NICKELS\n4) PENNIES\n");
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input valid selection number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return SelectCoin();
            }
        }
        public static double QuantityCoins()
        {
            Console.WriteLine("How many?\n");
            string userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out int quantity))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nINVALID input, please enter a number\n");
                Console.ForegroundColor = ConsoleColor.White;
                return QuantityCoins();
            }
            return Convert.ToDouble(quantity);
        }
        public static bool AddMoreCoins()
        {
            Console.WriteLine("Would you like to add more coins?\n1) YES\n2) NO\n");
            string moreCoins = Console.ReadLine();
            switch (moreCoins)
            {
                case "1":
                    return true;
                case "2":
                    return false;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nPlease input valid selection number\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    return AddMoreCoins();
            }
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
            Console.WriteLine($"You have in your wallet: {quarters} quarters, {dimes} dimes, {nickels} nickels, {pennies} pennies\n");
        }
    }
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
    //public static string SelectBeverage()
    //{
    //    List<Can> beverages = new List<Can>() { new Cola(), new Orange(), new RootBeer() };
    //    Console.WriteLine("Please input selection number");
    //    for (int i = 0; i < beverages.Count; i++)
    //    {
    //        Console.WriteLine($"{i}) {beverages[i].name}");
    //    }
    //    string userInput = Console.ReadLine();
    //    if (!int.TryParse(userInput, out int choice))
    //    {
    //        Console.Clear();
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("INVALID input, please enter a number");
    //        Console.ForegroundColor = ConsoleColor.White;
    //        return SelectBeverage();
    //    }
    //    else if (choice > 2 || choice < 0)
    //    {
    //        Console.Clear();
    //        Console.ForegroundColor = ConsoleColor.Red;
    //        Console.WriteLine("INVALID option, please select again");
    //        Console.ForegroundColor = ConsoleColor.White;
    //        return SelectBeverage();
    //    }
    //    var beverage = beverages[choice].name;
    //    return beverage;
    //}
}
