using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunLengthEncoding
{
    public static class Encoder
    {
        public static string Encode(Request model)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                var context = new ValidationContext(model);

                if (!Validator.TryValidateObject(model, context, validationResults, true))
                {
                    return $"Error: {string.Join("; ", validationResults.Select(v => v.ErrorMessage))}";
                }

                string source = model.Input;
                if (string.IsNullOrEmpty(source))
                    return "Error: Input cannot be empty.";

                var encodedResult = new StringBuilder();

                for (int i = 0; i < source.Length; i++)
                {
                    int count = 1;
                    while (i + 1 < source.Length && source[i] == source[i + 1])
                    {
                        count++;
                        i++;
                    }
                    encodedResult.Append(source[i]);
                    encodedResult.Append(count);
                }

                return encodedResult.ToString();
            }
            catch (Exception ex)
            {
                return $"Error: An unexpected error occurred. {ex.Message}";
            }
        }
    }
}