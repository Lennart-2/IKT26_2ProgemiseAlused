namespace DecimalToBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Decimal to binary!");

            Console.WriteLine("Sisesta number: ");

            //tuleb kasutada while
            int num = Convert.ToInt32(Console.ReadLine());

            string binaryNumber = "";

            while (num > 0)
            {
                int remainder = num % 2;
                binaryNumber = remainder + binaryNumber;
                num /= 2;
            }

            Console.WriteLine("Binary number: " + binaryNumber);
            
        }
    }
}
