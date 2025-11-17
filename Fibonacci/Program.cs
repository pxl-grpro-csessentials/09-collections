namespace Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[12];
            fibonacci[0] = 0;
            fibonacci[1] = 1;

            for (int index = 2; index < fibonacci.Length; index++)
            {
                int sum = fibonacci[index - 2] + fibonacci[index - 1];
                fibonacci[index] = sum;
            }

            //Print
            string result = string.Join(",", fibonacci);
            Console.WriteLine(result);
        }
    }
}
