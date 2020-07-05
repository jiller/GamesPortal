using System;
using System.Collections.Generic;

namespace AcmeGames.Filters
{
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        public Dictionary<string, string> Errors { get; set; }

        public ApiException(string message, 
            int statusCode = 500, 
            Dictionary<string, string> errors = null) :
            base(message)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }
}