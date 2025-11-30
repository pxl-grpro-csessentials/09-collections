namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[100];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int index = 2; index <= fibonacci.Length / 2; index++)
            {
                fibonacci[index] = fibonacci[index - 2] + fibonacci[index - 1];
            }

            foreach (int number in fibonacci)
            {
                Console.WriteLine(number);
            }
        }
    }
}
