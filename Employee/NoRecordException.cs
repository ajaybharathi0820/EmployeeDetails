using System;
using System.Runtime.Serialization;

namespace EmployeeDetails
{
    
    public class NoRecordException : Exception
    {
        public NoRecordException(): base("No records Are Matching")
        {
        }

        public NoRecordException(string message) : base(message)
        {
        }

        public NoRecordException(string message, Exception innerException) : base(message, innerException)
        {
        }

        
    }
}