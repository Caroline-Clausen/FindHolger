using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Channels;

namespace FindHolger
{
    internal class Program
    {
        // OPGAVE BESKRIVELSE:

        // Der skal laves et program der kan udskrive 40 rækker med 40 tilfældige bogstaver i hver række
        //Ét af bogstaverne skal erstattes med et @
        //Spillet handler om at finde @’et

        //Udvidelser til ekstra udfordring:
        //- Prøv at lege med om det er store eller små bogstaver der skrives
        //- Prøv at skifte farve på bogstaverne
        //- Prøv at lave en måde hvor man kan indtaste en løsning(måske med koordinater)

        static void Main(string[] args)
            
        {
            string value = @"abcdefghijklmnopqrstuvxyzæøå1234567890!#¤%&/()=?£${[]}ABCDEFGHIJKLMNOPQRSTUVXYZÆØÅ<>\|~^¨'*½§";
            char[] charArray = value.ToCharArray();

            Random rand1 = new Random();

            int x = rand1.Next(0, 40);
            int y = rand1.Next(0, 40);

            for (int tal = 0; tal <= 40; tal++)
            {
                Console.Write($"{string.Format("{0,3}", tal)}");
                int farveRandom = rand1.Next(1, 14);
            }
            Console.WriteLine();

            for (int række = 0; række < 40; række++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{string.Format("{0,3}", række + 1)}");

                for (int kolonne = 0; kolonne < 40; kolonne++)
                {
                    int i = rand1.Next(0, charArray.Length);
                    if (række == y && kolonne == x)
                    {
                        // For at gøre det nemmer for dig at finde @ så er der sat baggrundsfarve på 
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("  @");
                    }

                    else
                    {
                        int farveRandom = rand1.Next(1, 14);
                        Console.ForegroundColor = (ConsoleColor)farveRandom;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"{string.Format("{0,3}", charArray[i])}");
                    }
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Hvad er X koordinat?");
            int gætX = int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Hvad er Y koordinat?");
            int gætY = int.Parse(Console.ReadLine()) - 1;

            Console.WriteLine($"Dit gæt var X = {gætX + 1} og Y = {gætY + 1} ");

            while (x != gætX || y != gætY)
            {
                Console.WriteLine("Det var ikke helt rigtig prøv igen");
                Console.WriteLine("Hvad er X koordinat?");
                int gætNyX = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine("Hvad er Y koordinat?");
                int gætNyY = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine($"Dit gæt var X = {gætNyX + 1} og Y = {gætNyY + 1} ");
                gætX = gætNyX;
                gætY = gætNyY;
            }

            if (x == gætX && y == gætY)
                Console.WriteLine(" HURRA!!!! Det var rigtig");

            Console.WriteLine($"Svaret er {x + 1} , {y + 1}");

        }
    }
}

