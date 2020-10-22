using System.Collections.Generic;
using System.Linq;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;
        public List<Coin> coinsInserted;


        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
            coinsInserted = new List<Coin>();
        }

        //insert coins into sodamachine
        //user selects coins desired to insert into machine
        //coins selected become a list, which will be passed into machine
        // user selects beverage from list which will be passed into machine as string
        public void SelectCoinsToInsert(double quantity, string nameOfCoin)
        {
            foreach (Coin coin in wallet.coins)
            {
                for (int i = 0; i < quantity; i++)
                {
                    if (nameOfCoin == coin.name)
                    {
                        wallet.coins.Remove(coin);
                        coinsInserted.Add(coin);
                    }
                }
            }
        }

        //take change, add to wallet
        public void TakeCoins(List<Coin> coins)
        {
            wallet.coins.AddRange(coins);
        }

        //take soda, add to backpack
        public void TakeBeverages(List<Can> beverage)
        {
            backpack.cans.AddRange(beverage);
        }




    }
}
