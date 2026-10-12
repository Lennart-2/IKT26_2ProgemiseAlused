namespace SwitchColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta värvi nimi!");

            string color = Console.ReadLine();

            switch (color)
            {
                case "red":
                    Console.WriteLine("Sisestasid punase värvi");
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "green":
                    Console.WriteLine("Sisestasid rohelise värvi");
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.WriteLine("Sisestasid sinise värvi");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case "white":
                    Console.WriteLine("Sisestasid valge värvi");
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case "orange":
                    Console.WriteLine("Sisestasid oranži värvi");
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    break;
                default:
                    Console.WriteLine("Värv puudub");
                    break;
            }
        }
    }
}
