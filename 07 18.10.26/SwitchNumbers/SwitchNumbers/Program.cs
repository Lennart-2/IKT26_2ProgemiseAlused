namespace SwitchNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("sisesta number");

            //tuleb teha switch, kus esimene case on 10, teine on 20 ja kolmas on 30.
            //küsitakse numbrit ja sisestad konsooli

            int input = int.Parse(Console.ReadLine());

            switch (input)
            {
                case 10:
                    Console.WriteLine("sisestasid numbri 10");
                    break;

                case 20:
                    Console.WriteLine("sisestasid numbri 20");
                    break;

                case 30:
                    Console.WriteLine("sisestasid numbri 30");
                    break;

                default:
                    Console.WriteLine("mingi muu number" + input);
                    break;
            }
        }
    }
}
