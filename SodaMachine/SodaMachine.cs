using System;
using System.Collections.Generic;
using System.Linq;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        public List<Coin> changeBin;
        public List<Can> drinkBin;
        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();
            changeBin = new List<Coin>();
            drinkBin = new List<Can>();
            PopulateSodaMachine();
        }
        public void CreateCoinsInRegister(double quantity, string nameOfCoin)
        {
            Coin coin;
            for (int i = 0; i < quantity; i++)
            {
                if (nameOfCoin == "penny")
                {
                    coin = new Penny();
                    register.Add(coin);
                }
                else if (nameOfCoin == "nickel")
                {
                    coin = new Nickel();
                    register.Add(coin);
                }
                else if (nameOfCoin == "dime")
                {
                    coin = new Dime();
                    register.Add(coin);
                }
                else
                {
                    coin = new Quarter();
                    register.Add(coin);
                }
            }
        }
        public void CreateCansInMachine(double quantity, string nameOfCan)
        {
            Can can;
            for (int i = 0; i < quantity; i++)
            {
                if (nameOfCan == "orange")
                {
                    can = new Orange();
                    inventory.Add(can);
                }
                else if (nameOfCan == "cola")
                {
                    can = new Cola();
                    inventory.Add(can);
                }
                else
                {
                    can = new RootBeer();
                    inventory.Add(can);
                }
            }
        }
        public void PopulateSodaMachine()
        {
            CreateCoinsInRegister(20, "quarter");//20
            CreateCoinsInRegister(10, "dime");//10
            CreateCoinsInRegister(20, "nickel");//20
            CreateCoinsInRegister(50, "penny");//50
            CreateCansInMachine(10, "orange");
            CreateCansInMachine(10, "cola");
            CreateCansInMachine(10, "rootbeer");
        }
        public void PurchaseASoda(List<Coin> coins, string beverage)
        {
            double moneyInserted = CountCoins(coins);
            double costOfBeverage = CostOfBeverage(beverage);
            bool checkCanInventory = CheckCanInventory(beverage);
            double moneyInRegister = MoneyInRegister();
            if (checkCanInventory == true)
            {
                // not enough money passed in, no trans, return money
                if (moneyInserted < costOfBeverage)
                {
                    CoinReturn(coins);
                }

                // exact change passes in, accept payment,
                //dispense soda instance to be saved in backpack
                else if (moneyInserted == costOfBeverage)
                {
                    AddCoinsInsertedToRegister(coins);
                    DispenseCan(1, beverage);
                }

                // too much money, accept payment, return change as list of coins from
                // internal, limited register, dispense soda instance to be saved in backpack
                // too much money, not enough change, return coins
                else if (moneyInserted > costOfBeverage)
                {
                    double change = moneyInserted - costOfBeverage;
                    if (change < moneyInRegister)
                    {
                        AddCoinsInsertedToRegister(coins);
                        DispenseChange(change);
                        DispenseCan(1, beverage);
                    }
                    else// not enough change
                    {
                        CoinReturn(coins);
                    }
                }
            }
            else // enough money but no inventory
            {
                CoinReturn(coins);
            }
        }
        public double CountCoins(List<Coin> coins)
        {
            double sum = 0;
            foreach (Coin coin in coins)
            {
                sum += coin.Value;
            }
            return sum;
        } // static method in UI?

        public double CostOfBeverage(string beverage)
        {
            Can can;
            if (beverage == "cola")
            {
                can = new Cola();
                return can.Cost;
            }
            else if (beverage == "orange")
            {
                can = new Orange();
                return can.Cost;
            }
            else
            {
                can = new RootBeer();
                return can.Cost;
            }
        }
        public void AddCoinsInsertedToRegister(List<Coin> coins)
        {
            register.AddRange(coins);
        }
        public double MoneyInRegister()
        {
            double sum = 0;
            foreach (Coin coin in register)
            {
                sum += coin.Value;
            }
            return sum;
        }
        public bool CheckCanInventory(string beverage)
        {
            foreach (Can can in inventory)
            {
                if (can.name == beverage)
                {
                    return true;
                }
            }
            return false;
        }
        public void DispenseCan(double quantity, string beverage)
        {
            foreach (Can can in inventory)
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (beverage == can.name)
                    {
                        inventory.Remove(can);
                        drinkBin.Add(can);
                    }
                }
            }
        }

        public bool CheckRegisterCoinInventory(string nameOfCoin)
        {
            foreach (Coin coin in register)
            {
                if (coin.name == nameOfCoin)
                {
                    return true;
                }
            }
            return false;
        }
        public double DispenseChange(double change)
        {
            double changeCalc = change;
            while (change > .01)
            {
                if (change >= 0.25 && CheckRegisterCoinInventory("quarter"))
                {
                    var quantity = Math.Round(changeCalc / .25);
                    for (int i = 0; i < quantity; i++)
                    {
                        CoinsFromRegisterToChangeBin("quarter");
                    }
                    change -= quantity * .25;
                    return DispenseChange(change);
                }
                else if (change >= 0.1 && CheckRegisterCoinInventory("dime"))
                {
                    var quantity = Math.Round(changeCalc / .1);
                    for (int i = 0; i < quantity; i++)
                    {
                        CoinsFromRegisterToChangeBin("dime");
                    }
                    change -= quantity * .1;
                    return DispenseChange(change);
                }
                else if (change >= 0.05 && CheckRegisterCoinInventory("nickel"))
                {
                    var quantity = Math.Round(changeCalc / .05);
                    for (int i = 0; i < quantity; i++)
                    {
                        CoinsFromRegisterToChangeBin("nickel");
                    }
                    change -= quantity * .05;
                    return DispenseChange(change);
                }
                else
                {
                    var quantity = Math.Round(changeCalc / .01);
                    for (int i = 0; i < quantity; i++)
                    {
                        CoinsFromRegisterToChangeBin("penny");
                    }
                }
            }
            return change;
        }

        public Coin CoinsFromRegisterToChangeBin(string nameOfCoin)
        {
            foreach (Coin coin in register)
            {
                if (nameOfCoin == coin.name)
                {
                    register.Remove(coin);
                    changeBin.Add(coin);
                }
            }
            return null;
        }
        public void CoinReturn(List<Coin> coins)
        {
            changeBin.AddRange(coins);
        }

        //public void RemoveCoinsFromRegister(double quantity, string nameOfCoin)
        //{
        //    for (int i = 0; i < quantity; i++)
        //    {
        //        foreach (Coin coin in register)
        //        {
        //            if (nameOfCoin == coin.name)
        //            {
        //                register.Remove(coin);
        //            }
        //        }
        //    } 
        //}
        //public void RemoveCoinsFromRegister(double quantity, string nameOfCoin)
        //{
        //    double iterations = 0;
        //    do
        //    {
        //        foreach (Coin coin in register)
        //        {
        //            if (nameOfCoin == coin.name)
        //            {
        //                register.Remove(coin);
        //            }
        //            iterations++;
        //        }
        //    } while (iterations <= quantity);
        //}
        //public void AddCoinsToChangeBin(double quantity, string nameOfCoin)
        //{
        //    Coin coin;
        //    for (int i = 0; i < quantity; i++)
        //    {
        //        if (nameOfCoin == "penny")
        //        {
        //            coin = new Penny();
        //            changeBin.Add(coin);
        //        }
        //        else if (nameOfCoin == "nickel")
        //        {
        //            coin = new Nickel();
        //            changeBin.Add(coin);
        //        }
        //        else if (nameOfCoin == "dime")
        //        {
        //            coin = new Dime();
        //            changeBin.Add(coin);
        //        }
        //        else
        //        {
        //            coin = new Quarter();
        //            changeBin.Add(coin);
        //        }
        //    }
        //}
        //public void AddCansToDrinkBin(int quantity, string nameOfCan)
        //{
        //    Can can;
        //    for (int i = 0; i < quantity; i++)
        //    {
        //        if (nameOfCan == "orange")
        //        {
        //            can = new Orange();
        //            drinkBin.Add(can);
        //        }
        //        else if (nameOfCan == "cola")
        //        {
        //            can = new Cola();
        //            drinkBin.Add(can);
        //        }
        //        else
        //        {
        //            can = new RootBeer();
        //            drinkBin.Add(can);
        //        }
        //    }
        //}
        //public Can DispenseSoda(string beverage)
        //{
        //    foreach (Can can in inventory)
        //    {
        //        if (can.name == beverage)
        //        {
        //            inventory.Remove(can);
        //            return can;
        //        }
        //    }
        //    return null;
        //}
    }
}
