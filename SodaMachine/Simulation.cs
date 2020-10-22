using System;
using System.CodeDom;

namespace SodaMachine
{
    class Simulation
    {
        public SodaMachine sodaMachine;
        public Customer customer;

        public Simulation()
        {
            sodaMachine = new SodaMachine();
            customer = new Customer();
        }

        public void RunSim()
        {
            UserInterface.DisplayMessage("Thank you for choosing this machine");
            UserInterface.DisplayMessage("Which beverage will quench your thirst?");
            string beverage = UserInterface.SelectBeverage();
            double cost = sodaMachine.CostOfBeverage(beverage); // get cost of beverage
            UserInterface.DisplayMessage($"The {beverage} costs: {cost}");//Display cost of selected beverage
            UserInterface.DisplayWallet(customer.wallet);
            UserInterface.MethodOfPayment();

        }




    }
}
