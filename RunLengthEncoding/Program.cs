using System;
using RunLengthEncoding.Services;
using RunLengthEncoding.Domain.Models;
using RunLengthEncoding.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        IValidator<EncodeRequest> validator = new InputValidator();
        IEncoder encoder = new RunLengthEncoder();
        ILogger logger = new ConsoleLogger();
        var encodingService = new EncodingService(validator, encoder, logger);

        while (true)
        {
            Console.Write("Enter a string to encode: ");
            var request = new EncodeRequest { Input = Console.ReadLine() };

            string result = encodingService.Encode(request);

            if (result.StartsWith("Error:"))
            {
                Console.WriteLine(result);
                continue;
            }

            Console.WriteLine($"Encoded result: {result}");
            break;
        }
    }
}

public class ConsoleLogger : ILogger
{
    public void LogError(Exception ex, string message)
    {
        Console.WriteLine($"{message} Exception: {ex.Message}");
    }
}