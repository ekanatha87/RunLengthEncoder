using RunLengthEncoding.Domain.Models;
using RunLengthEncoding.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RunLengthEncoding.Services
{
    public class InputValidator : IValidator<EncodeRequest>
    {
        public bool TryValidate(EncodeRequest model, out List<string> errors)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            errors = results.ConvertAll(r => r.ErrorMessage);
            return isValid;
        }
    }
}