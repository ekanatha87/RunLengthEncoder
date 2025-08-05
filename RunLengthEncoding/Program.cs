using System;
using RunLengthEncoding;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Enter a string to encode: ");
            var model = new Request { Input = Console.ReadLine() };

            string encoded = Encoder.Encode(model);

            if (encoded.StartsWith("Error:"))
            {
                Console.WriteLine(encoded);
                continue;
            }

            Console.WriteLine($"Encoded result: {encoded}");
            break;
        }
    }
}
