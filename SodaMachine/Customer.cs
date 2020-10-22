namespace SodaMachine
{
    class Customer
    {
        public Wallet wallet;
        public Backpack backpack;


        public Customer()
        {

        }

        public void CreateCansInBackpack(double quantity, string nameOfCan)
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




    }
}
