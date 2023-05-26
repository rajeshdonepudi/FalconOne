﻿using System.Globalization;

namespace FalconOne.Helpers.Helpers
{
    public class AppException : Exception
    {
        public object Errors { get; set; }
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
            Errors = args;
        }
    }
}
