using RunLengthEncoding.Interfaces;
using System.Text;

namespace RunLengthEncoding.Services
{
    public class RunLengthEncoder : IEncoder
    {
        public string Encode(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "Error: Input cannot be empty.";

            var encodedResult = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                int count = 1;
                while (i + 1 < input.Length && input[i] == input[i + 1])
                {
                    count++;
                    i++;
                }
                encodedResult.Append(input[i]);
                encodedResult.Append(count);
            }
            return encodedResult.ToString();
        }
    }
}