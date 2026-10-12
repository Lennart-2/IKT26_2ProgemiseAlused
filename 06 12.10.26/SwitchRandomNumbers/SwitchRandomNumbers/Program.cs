namespace SwitchRandomNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Genereerib numbreid ühest kuni kuueni");

            //genereerib juhuslikke numbreid 1 kuni 6
            int roll = new Random().Next(1, 7);

            //kasutada switchi
            //peab kontrollima tulemust ja kuvama vastavalt sõnumit

            switch (roll)
            {
                case 1:
                    Console.WriteLine("Veeretasi numbri ühe");
                    break;
                case 2:
                    Console.WriteLine("Veeretasid numbri kahe");
                    break;
                case 3:
                    Console.WriteLine("Veeretasid numbri kolme");
                    break;
                case 4:
                    Console.WriteLine("Veeretasid numbri nelja");
                    break;
                case 5:
                    Console.WriteLine("Veeretasid numbri viie");
                    break;
                case 6:
                    Console.WriteLine("Veeretasid numbri kuue");
                    break;
            }
        }
    }
}
