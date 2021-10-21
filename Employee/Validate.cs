using System;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace EmployeeDetails
{
    class Validate
    {
        public bool ValidateId(string employeeId)
        {
            bool Result = false;
            Result = Regex.IsMatch(employeeId, "^(ace|ACE)[0-9]{4}$");
            if (!Result)
            {
                Console.WriteLine("The valid Employee ID should Starts with ace followed by 4 digit numbers ");
                Console.WriteLine("Re-enter the Employee id:");
            }
            return Result;
        }

        public bool ValidateName(string employeeName)
        {
            //return Regex.IsMatch(employeeName, "^[a-zA-Z ]{3,}$");
            bool Result = false;
            Result = Regex.IsMatch(employeeName, "^[a-zA-Z ]{3,}$");
            if (!Result)
            {
                Console.WriteLine("The valid Employee Name Should contains only alphabets ");
                Console.WriteLine("Re-enter the Employee Name :");
            }
            return Result;
        }

        public bool ValidateBirth(string dateBirth)
        {
            bool Result = false;
            DateTime dateOfBirth = Convert.ToDateTime(dateBirth);
            Result = (DateTime.UtcNow.Year - dateOfBirth.Year > 18 && DateTime.UtcNow.Year - dateOfBirth.Year < 60);
            if (!Result)
            {
                Console.WriteLine("The age of the employee must between 18 and 60");
                Console.WriteLine("Re-enter the Date Of Birth :");
            }
            return Result;


        }

        public bool ValidateJoining(string dateJoining, string dateBirth)
        {
            bool Result = false;
            DateTime dateOfJoining = Convert.ToDateTime(dateJoining);
            DateTime dateOfBirth = Convert.ToDateTime(dateBirth);
            Result= (dateOfJoining.Year - dateOfBirth.Year > 18 && DateTime.UtcNow.Date >= dateOfJoining.Date);
            if (!Result)
            {
                Console.WriteLine("The Joining date of the employee must not be future date");
                Console.WriteLine("Re-enter the Date Of Joining :");
            }
            return Result;
        }

        public bool ValidateMobile(string mobileNo)
        {
            bool Result = false;
            Result= Regex.IsMatch(mobileNo, "^[6-9][0-9]{9}$");
            if (!Result)
            {
                Console.WriteLine("The valid Mobile number should starts with between 6 and 9 and followed by 9 digit numbers");
                Console.WriteLine("Re-enter the Mobile no :");
            }
            return Result;
        }

        public bool ValidateMail(string eMail)
        {
            bool Result = false;
            Result = Regex.IsMatch(eMail, @"[0-9a-zA-Z]@[a-zA-Z]+.[a-zA-Z]{2,}$");
            if (!Result)
            {
                Console.WriteLine("Email should contain @ followed by domain Name in Alphabetics");
                Console.WriteLine("Re-enter the Mail id :");
            }
            return Result;

        }


    }
}