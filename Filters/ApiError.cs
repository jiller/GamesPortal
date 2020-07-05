using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AcmeGames.Filters
{
    public class ApiError
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public string Detail { get; set; }
        public Dictionary<string, string> Errors { get; set; }

        public ApiError(string message)
        {
            this.Message = message;
            IsError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                Message = "Please correct the specified errors and try again.";
                Errors = modelState
                    .SelectMany(m => m.Value.Errors.Select(me => new KeyValuePair<string,string>( m.Key,me.ErrorMessage)))
                    .ToDictionary(kv => kv.Key, kv => kv.Value);
            }
        }
    }
}