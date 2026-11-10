namespace MaaKalkulaator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Meil on münt. mille diameeter on 25.75 mm
            //Arvutada välja Maa ümbermõõt ja mitu münti 
            //Mahub järjestikku ümber Maa
            //Arvutuses tohib kasutada ainult mündi diameetrit ja Maa raadiust 6371 km

            double coinDiameter = 0.02575; //mm
            double earthRadius = 6371000; //m

            double aroundEarth = 2 * Math.PI * earthRadius; //m
            Console.WriteLine("Maa ümbermõõt on " + aroundEarth);

            double howManyCoins = aroundEarth / coinDiameter;
            Console.WriteLine("Kahe euroseid läheb ümber maa {0:0}", howManyCoins);
        }
    }
}
