namespace ForLoop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("For loop!");

            int loop = 10;


            for (int i = 0; i < loop; i++)
            {
                Console.WriteLine($"Loop {i}");
                Thread.Sleep(1000);
                Console.Beep();
            }
        }
    }
}
