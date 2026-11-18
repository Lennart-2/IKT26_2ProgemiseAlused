using System.Threading.Channels;

namespace WhileGuessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //numbri arvamise mäng
            Random random = new Random();
            int secretNumber = random.Next(1, 101);
            int guess = 0;
            int attempts = 0;
            
            //tuleb kasutada while, kus äeldakse,
            //kas sinu pakutud number oli suurem või väiksem

            while (guess !=  secretNumber)
            {
                Console.WriteLine("Arva number 1 - 100-ni");
                guess = Convert.ToInt32(Console.ReadLine());
                attempts++;

                if (guess < secretNumber)
                {
                    Console.WriteLine("Pakutud number on väiksem kui otsitav");
                }
                else if (guess > secretNumber)
                {
                    Console.WriteLine("Pakutud number on suurem kui otsitav");
                }

            }
            Console.WriteLine($"Palju Õnne! Prooisid {attempts}");
        }   
    }
}
