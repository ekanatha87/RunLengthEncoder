using RunLengthEncoding.Domain.Models;
using RunLengthEncoding.Interfaces;
using System;
using System.Collections.Generic;

namespace RunLengthEncoding.Services
{
    public class EncodingService
    {
        private readonly IValidator<EncodeRequest> _validator;
        private readonly IEncoder _encoder;
        private readonly ILogger _logger;

        public EncodingService(IValidator<EncodeRequest> validator, IEncoder encoder, ILogger logger)
        {
            _validator = validator;
            _encoder = encoder;
            _logger = logger;
        }

        public string Encode(EncodeRequest request)
        {
            try
            {
                if (!_validator.TryValidate(request, out List<string> errors))
                {
                    return $"Error: {string.Join("; ", errors)}";
                }
                return _encoder.Encode(request.Input);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred during encoding.");
                return "Error: An unexpected error occurred. Please check logs for details.";
            }
        }
    }
}