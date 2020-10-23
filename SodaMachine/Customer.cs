using System.Collections.Generic;

namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }
        public void TakeCoins(List<Coin> coins)
        {
            wallet.coins.AddRange(coins);
        }
        public void TakeBeverages(List<Can> beverage)
        {
            backpack.cans.AddRange(beverage);
        }
    }
}
