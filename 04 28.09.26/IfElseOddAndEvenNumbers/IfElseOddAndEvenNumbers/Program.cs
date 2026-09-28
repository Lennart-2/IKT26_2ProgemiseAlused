using System.Threading.Channels;

namespace IfElseOddAndEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //konsool küsib numbrit
            //number tuleb ära parsida
            Console.WriteLine("Sisesta number");

            string arv = Console.ReadLine();
            int number = int.Parse(arv);

            //if ja else juures toimub kontroll, et 
            //kas on paaris või paaritu nr
            //mida % operaator tähendab?
            //see leiab jäägi ja nii kaua kontrollib, kas on 0 
            Console.WriteLine("--------------------");
            if (number % 2 == 0)
            {
                //Console.WriteLine("See on paaris arv");

            }
            else
            {
                //Console.WriteLine("See on paaritu arv");

            }
            //kutsuda paarisarvu ja paarituarvu tekst välja
            //läbi meetodi kutsumise

        }

        static void EvenNumbers()
        {
            Console.WriteLine("Paarisarvud");
        }

        static void OddNumbers()
        {
            Console.WriteLine("Paarituarv");
        }
    }
}
