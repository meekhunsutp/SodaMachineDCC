namespace SodaMachine
{
    abstract class Coin
    {
        protected double value;
        public double Value
        {
            get
            {
                return value;
            }
        }
        public string name;
    }
}
