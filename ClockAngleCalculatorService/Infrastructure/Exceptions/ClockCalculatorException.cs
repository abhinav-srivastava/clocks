using System;

namespace SampleService.Infrastructure.Exceptions
{
    /// <summary>
    /// Exception type for app exceptions
    /// </summary>
    public class ClockCalculatorException : Exception
    {
        public ClockCalculatorException()
        { }

        public ClockCalculatorException(string message)
            : base(message)
        { }

        public ClockCalculatorException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
