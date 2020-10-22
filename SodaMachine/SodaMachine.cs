using System;
using System.Collections.Generic;

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
        }

        public void AddCoinsToRegister(double quantity, string nameOfCoin)
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
        public Coin RemoveCoinsFromRegister(string nameOfCoin)
        {
            foreach (Coin coin in register)
            {
                if (nameOfCoin == coin.name)
                {
                    register.Remove(coin);
                    return coin;
                }
            }
            return null;
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
        public void AddCoinsToChangeBin(double quantity, string nameOfCoin)
        {
            Coin coin;
            for (int i = 0; i < quantity; i++)
            {
                if (nameOfCoin == "penny")
                {
                    coin = new Penny();
                    changeBin.Add(coin);
                }
                else if (nameOfCoin == "nickel")
                {
                    coin = new Nickel();
                    changeBin.Add(coin);
                }
                else if (nameOfCoin == "dime")
                {
                    coin = new Dime();
                    changeBin.Add(coin);
                }
                else
                {
                    coin = new Quarter();
                    changeBin.Add(coin);
                }
            }
        }
        public void AddCansToMachine(double quantity, string nameOfCan)
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
        public void RemoveCansFromInventory(double quantity, string nameOfCan)
        {
            foreach (Can can in inventory)
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (nameOfCan == can.name)
                    {
                        inventory.Remove(can);
                    }
                }
            }
        }
        public void AddCansToDrinkBin(int quantity, string nameOfCan)
        {
            Can can;
            for (int i = 0; i < quantity; i++)
            {
                if (nameOfCan == "orange")
                {
                    can = new Orange();
                    drinkBin.Add(can);
                }
                else if (nameOfCan == "cola")
                {
                    can = new Cola();
                    drinkBin.Add(can);
                }
                else
                {
                    can = new RootBeer();
                    drinkBin.Add(can);
                }
            }
        }
        public void PopulateSodaMachine()
        {
            AddCoinsToRegister(20, "quarter");//20
            AddCoinsToRegister(10, "dime");//10
            AddCoinsToRegister(20, "nickel");//20
            AddCoinsToRegister(50, "penny");//50
            AddCansToMachine(10, "orange");
            AddCansToMachine(10, "cola");
            AddCansToMachine(10, "rootbeer");
        }

        public void PurchaseASoda(List<Coin> coins, string beverage)
        {
            double moneyInserted = CountCoins(coins);
            double costOfBeverage = CostOfBeverage(beverage);
            bool checkInventory = CheckInventory(beverage);
            double moneyInRegister = MoneyInRegister();

            if (checkInventory == true)
            {
                // not enough money passed in, no trans, return money
                if (moneyInserted < costOfBeverage)
                {
                    DispenseChange(moneyInserted);
                }

                // exact change passes in, accept payment,
                //dispense soda instance to be saved in backpack
                else if (moneyInserted == costOfBeverage)
                {
                    //AddCoinsToRegister();
                    RemoveCansFromInventory(1, beverage);
                    AddCansToDrinkBin(1, beverage);
                }

                // too much money, accept payment, return change as list of coins from
                // internal, limited register, dispense soda instance to be saved in backpack
                else if (moneyInserted > costOfBeverage)
                {
                    double change = moneyInserted - costOfBeverage;
                    if(change > moneyInRegister)
                    {
                        DispenseChange(change);
                        //AddCoinsToRegister();
                        RemoveCansFromInventory(1, beverage);
                        AddCansToDrinkBin(1, beverage);
                    }
                    else
                    {
                        DispenseChange(moneyInserted);
                    }
                }
            }
            else // no inventory
            {
                DispenseChange(moneyInserted);
            }
        }
        public void SortCoins(List<Coin> coins)
        {
            foreach (Coin coin in coins)
            {
                if( coin.name == "quarter")
                {

                }
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


        public double MoneyInRegister()
        {
            double sum = 0;
            foreach (Coin coin in register)
            {
                sum += coin.Value;
            }
            return sum;
        }

        public double DispenseChange(double change)
        {
            double changeCalc = change;
            while (change > .01)
            {
                if (change >= 0.25 && RegisterCoinCheck("quarter"))
                {
                    var quantity = Math.Round(changeCalc / .25);
                    for (int i = 0; i < quantity; i++)
                    {
                        RemoveCoinsFromRegister("quarter");
                    }
                    AddCoinsToChangeBin(quantity, "quarter");
                    change -= quantity * .25;
                    return DispenseChange(change);
                }
                else if (change >= 0.1 && RegisterCoinCheck("dime"))
                {
                    var quantity = Math.Round(changeCalc / .1);
                    for (int i = 0; i < quantity; i++)
                    {
                        RemoveCoinsFromRegister("dime");
                    }
                    AddCoinsToChangeBin(quantity, "dime");
                    change -= quantity * .1;
                    return DispenseChange(change);
                }
                else if (change >= 0.05 && RegisterCoinCheck("nickel"))
                {
                    var quantity = Math.Round(changeCalc / .05);
                    for (int i = 0; i < quantity; i++)
                    {
                        RemoveCoinsFromRegister("nickel");
                    }
                    AddCoinsToChangeBin(quantity, "nickel");
                    change -= quantity * .05;
                    return DispenseChange(change);
                }
                else
                {
                    var quantity = Math.Round(changeCalc / .01);
                    for (int i = 0; i < quantity; i++)
                    {
                        RemoveCoinsFromRegister("penny");
                    }
                    AddCoinsToChangeBin(quantity, "penny");
                }
            }
            return change;
        }

        public bool RegisterCoinCheck(string nameOfCoin)
        {
            foreach(Coin coin in register)
            {
                if(coin.name == nameOfCoin)
                {
                    return true;
                }
            }
            return false;
        }
        public Can DispenseSoda(string beverage)
        {
            foreach (Can can in inventory)
            {
                if (can.name == beverage)
                {
                    inventory.Remove(can);
                    return can;
                }
            }
            return null;
        }
        public bool CheckInventory(string beverage)
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


    }
}
