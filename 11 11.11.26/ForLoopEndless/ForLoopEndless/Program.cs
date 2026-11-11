namespace ForLoopEndless
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Endless for loop");

            //kui on 10 rida konsoolis, siis lõpetab ära
            //kasutada break;
            ushort counter = 1;
            for (; ; )
            {
                Console.WriteLine($"Counter: {counter}");
                counter++;

                if (counter > 10)
                {
                    break;
                }
            }
        }
    }
}
