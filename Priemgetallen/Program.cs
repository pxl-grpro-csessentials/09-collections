using System;

namespace Priemgetallen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] primeNumbers = new int[100];

            int number = 2;
            int index =0;

            Console.WriteLine("De eerste 100 priemgetallen zijn: ");
            Console.WriteLine();

            do
            {
                //Start met het idee dat elk getal een priemgetal is:
                bool isPrime = true; 

                //Lus door alle mogelijke delers beginnende met 2 (elk getal is deelbaar door 1)
                for(int divisor = 2; divisor <= (number / 2) ; divisor++)
                {
                    //Controleer of het getal deelbaar is door de deler
                    if(number % divisor == 0)
                    {
                        //Onderbreek de lus wanneer een getal deelbaar is door een deler
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                {
                    primeNumbers[index] = number;
                    index++;
                }
                number++;
            } while (primeNumbers[99] == 0);

            int maxLength = primeNumbers[99].ToString().Length;

            //Toon resultaat
            for (int i = 0; i < primeNumbers.Length; i++) 
            {
                if(i > 0 && i % 10 == 0)
                {
                    Console.WriteLine();
                }
                
                Console.Write(primeNumbers[i].ToString().PadLeft(maxLength + 2));
            }

            Console.WriteLine();
        }
    }
}
