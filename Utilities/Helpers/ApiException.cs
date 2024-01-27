using System.Globalization;

namespace FalconOne.Helpers.Helpers
{
    public class ApiException : Exception
    {
        public object Errors { get; set; }
        public ApiException() : base() { }

        public ApiException(string message) : base(message) { }

        public ApiException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
            // Errors = args;
        }
    }
}
