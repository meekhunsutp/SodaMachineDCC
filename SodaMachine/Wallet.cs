using System.Collections.Generic;

namespace SodaMachine
{
    class Wallet
    {
        public List<Coin> coins;
        public Card card;

        public Wallet()
        {
            coins = new List<Coin>();
            PopulateWallet();
        }

        public void CreateCoinsInWallet(double quantity, string nameOfCoin)
        {
            Coin coin;
            for (int i = 0; i < quantity; i++)
            {
                if (nameOfCoin == "penny")
                {
                    coin = new Penny();
                    coins.Add(coin);
                }
                else if (nameOfCoin == "nickel")
                {
                    coin = new Nickel();
                    coins.Add(coin);
                }
                else if (nameOfCoin == "dime")
                {
                    coin = new Dime();
                    coins.Add(coin);
                }
                else
                {
                    coin = new Quarter();
                    coins.Add(coin);
                }
            }
        }
        public void PopulateWallet()
        {
            CreateCoinsInWallet(10, "quarter");
            CreateCoinsInWallet(10, "dime");
            CreateCoinsInWallet(20, "nickel");
            CreateCoinsInWallet(50, "penny");
        }


    }
}
