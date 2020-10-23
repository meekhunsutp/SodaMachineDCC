using System.Collections.Generic;

namespace SodaMachine
{
    internal class Simulation
    {
        private SodaMachine sodaMachine;
        private Customer customer;
        private List<Coin> coinsInserted;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
            coinsInserted = new List<Coin>();
        }

        public void RunSim()
        {
            UserInterface.DisplayMessage("\n\nThank you for choosing this machine\n");
            UserInterface.DisplayMessage("Which beverage will quench your thirst?");
            string beverage = UserInterface.SelectBeverage();
            double cost = sodaMachine.CostOfBeverage(beverage);
            UserInterface.DisplayMessage($"\nThe {beverage} costs: {cost}\n");
            UserInterface.DisplayWallet(customer.wallet);
            bool payWithCoins = UserInterface.MethodOfPayment();
            if (payWithCoins == true)
            {
                do
                {
                    string nameOfCoin = UserInterface.SelectCoin();
                    double quantity = UserInterface.QuantityCoins();
                    for (int i = 0; i < quantity; i++)
                    {
                        InsertCoins(nameOfCoin);
                    }
                } while (UserInterface.AddMoreCoins());
                sodaMachine.PurchaseASoda(coinsInserted, beverage);
            }
            else
            {
                sodaMachine.PurchaseASoda(customer.wallet.card.AvailableFunds, beverage);
                customer.wallet.card.AvailableFunds -= cost;
            }
            customer.TakeBeverages(sodaMachine.drinkBin);
            if (sodaMachine.CountCoins(sodaMachine.changeBin) > 0)
            {
                customer.TakeCoins(sodaMachine.changeBin);
            }
            UserInterface.DisplayMessage("Thank you, may your thirst be quenched");
        }
        private void InsertCoins(string nameOfCoin)
        {
            for (int i = 0; i < customer.wallet.coins.Count; i++)
            {
                if (customer.wallet.coins[i].name == nameOfCoin)
                {
                    coinsInserted.Add(customer.wallet.coins[i]);
                    customer.wallet.coins.RemoveAt(i);
                    break;
                }
            }
        }

        //    for (int i = 0; i < quantity; i++)
        //    {
        //    }

        //    foreach (Coin coin in customer.wallet.coins)
        //    {
        //    }
        //}
        //public void InsertCoin(string nameOfCoin)
        //{
        //    Quarter quarter = new Quarter();
        //    Dime dime = new Dime();
        //    Nickel nickel = new Nickel();
        //    Penny penny = new Penny();
        //    switch (nameOfCoin)
        //    {
        //        case "quarter":
        //            customer.wallet.coins.Remove(Coin coin);

        //            break;
        //        case "dime":
        //            break;
        //        case "nickel":
        //            break;
        //        case "penny":
        //            break;

        //    }
        //}
        //public void InsertCoins(string nameOfCoin)
        //{
        //    foreach (Coin coin in customer.wallet.coins)
        //    {
        //        if (nameOfCoin == coin.name)
        //        {
        //            customer.wallet.coins.Remove(coin);
        //            coinsInserted.Add(coin);
        //        }
        //        break;
        //    }

        //}
    }
}