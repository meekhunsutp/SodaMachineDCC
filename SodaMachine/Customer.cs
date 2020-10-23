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

        //insert coins into sodamachine
        //user selects coins desired to insert into machine
        //coins selected become a list, which will be passed into machine
        // user selects beverage from list which will be passed into machine as string


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
