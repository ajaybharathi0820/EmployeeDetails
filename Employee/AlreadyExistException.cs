using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails
{
    class AlreadyExistException : Exception
    {
        
        public AlreadyExistException() : base("Employee Id is Already Exist.")
        { 
        
        }

        public AlreadyExistException(string message) : base(message)
        {

        }


    }
}
