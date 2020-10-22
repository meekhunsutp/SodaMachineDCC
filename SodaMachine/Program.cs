namespace SodaMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SodaMachine sodaMachine = new SodaMachine();
            sodaMachine.PopulateSodaMachine();
            sodaMachine.DispenseChange(1.32);
        }
    }
}
