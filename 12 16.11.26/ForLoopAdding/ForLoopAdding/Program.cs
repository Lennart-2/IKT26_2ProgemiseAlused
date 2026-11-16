namespace ForLoopKillKoll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Eelnevaid teadmisi kasutades kirjuta programm, mis väljastaks:
            //kill - koll
            //kill - koll
            //killadi - koll
            //kill - koll
            //kill - koll
            //killadi - koll
            //kill - koll
            //kill - koll
            //killadi - koll
            //kill - koll
            //kill - koll
            //killadi - koll
            //jne
            //Kasutada for loopi ja kasutaja saab sisestada korduse arvu

            Console.WriteLine("Sisesta korduste arv");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\n\n");

            int arv = Convert.ToInt16(Console.ReadLine());
            Console.Clear();

            for (int i = 1; i <= arv; i++)
            {
                Console.WriteLine("See on rida nr {0}", i);

                for (int j = 1; j <= 2; j++)
                {
                    Console.WriteLine("Kill - koll");
                }
                Console.WriteLine("killadi koll");
            }         
        }
    }
}
