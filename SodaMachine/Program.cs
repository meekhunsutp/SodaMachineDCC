namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            //SodaMachine sodaMachine = new SodaMachine();
            //sodaMachine.DispenseChange(1.32);

            //List<Coin> coins = new List<Coin>();
            //for(int i = 0; i < 5; i++)
            //{
            //    coins.Add(new Quarter());
            //}

            //List<Coin> register = new List<Coin>();
            //register.Add(new Penny());

            //register.AddRange(coins);

            //UserInterface.SelectCoin();
            Simulation simulation = new Simulation();
            simulation.RunSim();
        }
    }
}
