namespace SodaMachine
{
    class Card
    {
        protected double availableFunds;
        public double AvailableFunds
        {
            get
            {
                return availableFunds;
            }
            set
            {
                availableFunds = value;
            }
        }
        public Card()
        {
            availableFunds = 5;
        }
    }
}
