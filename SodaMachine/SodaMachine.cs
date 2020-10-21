using System.Collections.Generic;
using System.Linq;

namespace SodaMachine
{
    class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        //public double moneyInRegister = MoneyInRegister(register);
        public SodaMachine()
        {
            register = new List<Coin>();
        }

        public void AddCoins(int quantity, string nameOfCoin)
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


        //public void PurchaseASoda(List<Coin> coins, string beverage)
        //{
        //    double moneyInserted = CountCoins(coins);
        //    double costOfBeverage = CostOfBeverage(beverage);
        //    //double changeAmount = CalculateChange;
        //    // not enough money passed in, no trans, return money
        //    if (moneyInserted < costOfBeverage)
        //    {

        //    }

        //    // exact change passes in, accept payment,
        //    //dispense soda instance to be saved in backpack
        //    else if (moneyInserted == costOfBeverage)
        //    {

        //    }

        //    // too much money, accept payment, return change as list of coins from
        //    // internal, limited register, dispense soda instance to be saved in backpack
        //    else if (moneyInserted > costOfBeverage)
        //    {

        //    }

        //    // too much money, not enough change in machine internal register,
        //    // no trans, return money
        //    else if (moneyInserted > costOfBeverage && )
        //    {

        //    }

        //    // exact or too much money but no inventory soda, no trans, return money
        //    else
        //    {

        //    }
        //}
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
            if (beverage == "Cola")
            {
                can = new Cola();
                return can.Cost;
            }
            else if (beverage == "OrangeSoda")
            {
                can = new OrangeSoda();
                return can.Cost;
            }
            else
            {
                can = new RootBeer();
                return can.Cost;
            }
        }

        public void DispenseSoda()
        {

        }
        public void AddToRegister()
        {

        }


        //public double MoneyInRegister(List<Coin> register)
        //{
        //    double sum = 0;
        //    foreach (Coin coin in register)
        //    {
        //        sum += coin.Value;
        //    }
        //    return sum;
        //}
        //public double Refund()
        //{

        //}
        //public double CalculateChange()
        //{

        //}

        //public double DispenseChange()
        //{

        //}

        //public bool InventoryCheck(string beverage)
        //{
        //    Can can;
        //    if (inventory.Contains(can.name))
        //    {
        //        return true;
        //    }
        //}


    }
}
