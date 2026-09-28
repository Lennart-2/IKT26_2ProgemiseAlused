namespace IfElseMethodCall
{
    internal class Program
    {
        //see on meetod Main
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //kasutada if ja else
            //kui kasutaja soovib, siis saab ta meetodi välja kutsuda
            Console.WriteLine("Kui soovid meetodit välja kutsuda, siis kirjuta ja");
            string method = Console.ReadLine();

            if (method == "ja")
            {
                //kui kirjutan meetodi nime, siis seda nimetatakse
                //meetodi välja kutsumiseks
                HelloMethod();
            }
            else
            {
                Console.WriteLine("Ei soovinud midagi");
            }
        }

        //tehke uus meetod nimega HelloMethod
        //kirjutage sinna sisse kood, mis kuvab teksti Hello Kitty

        static void HelloMethod()
        {
            Console.WriteLine("Hello Kitty");
        }
    }
}
