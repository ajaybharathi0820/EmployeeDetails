using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace EmployeeDetails
{
    class Crud
    {
        public static List<Employee> EmployeeList = new List<Employee>();
        Employee employee = new Employee();
        Validate validate = new Validate();

        public  void Create()
        {
            
            Console.WriteLine("Enter Employee Details");
            Console.WriteLine("======================");
            FromFirst:
            Console.WriteLine("Enter The Employee Id :");
            ReId:
            string employeeId = Console.ReadLine();
            var isvalidId = validate.ValidateId(employeeId);
            if (isvalidId)
            {
                employee.EmployeeId = employeeId;
            }
            else
            {
                
                goto ReId;

            }
            Console.WriteLine("Enter The Employee Name :");
            ReName:
            string employeeName = Console.ReadLine();
            var isvalidName = validate.ValidateName(employeeName);
            if (isvalidName)
            {
                employee.EmployeeName = employeeName;
            }
            else
            {
                goto ReName;  
            }
           

            Console.WriteLine("Enter The Employee Date Of Birth :");
            ReDob:
            string dateOfBirth = Console.ReadLine();
            var isvalidBirth =validate.ValidateBirth( dateOfBirth);
            if (isvalidBirth)
            {
                employee. DateOfBirth =Convert.ToDateTime( dateOfBirth);
            }
            else
            {
                
                
                goto ReDob;

            }

            Console.WriteLine("Enter The Employee Date Of Joining :");
        ReDoj:
            string dateOfJoining = Console.ReadLine();
            string dateBirth =Convert.ToString( employee.DateOfBirth);
            var isvalidJoining = validate.ValidateJoining(dateOfJoining,dateBirth);
            if (isvalidJoining)
            {
                employee.DateOfJoining =Convert.ToDateTime( dateOfJoining);
            }
            else
            {
                goto ReDoj;
            }

            Console.WriteLine("Enter 10 Digit Mobile No : ");
        ReMobile:
            string mobileNo = Console.ReadLine();
            var isvalidNo = validate.ValidateMobile(mobileNo);  
            if (isvalidNo)
            {
                employee.MobileNumber= Convert.ToInt64(mobileNo);

            }
            else
            {
                
                goto ReMobile;

            }
            Console.WriteLine("Enter New Mail ID:");
        ReMail:
            string eMail = Console.ReadLine();
            var isvalidMail = validate.ValidateMail(eMail);
            if (isvalidMail)
            {
                employee.EMail = eMail;
            }
            else
            {
                goto ReMail;
            }



            try
            {
                if (EmployeeList.Exists(Employee => Employee.EmployeeId == employee.EmployeeId))
                {
                    throw new AlreadyExistException();
                }

                else
                {
                    EmployeeList.Add(employee);
                    Console.WriteLine("Successfully created");
                }
            }
            catch (AlreadyExistException Exception) {
                Console.WriteLine(Exception.Message);
                goto FromFirst;
            }
            

        }

        public static void Read()
        {
            if (EmployeeList.Count > 0)
            {

                for (int i = 0; i < EmployeeList.Count; i++)
                {
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("| Employee detail |");
                    Console.WriteLine(" -----------------");
                    Console.WriteLine("Employee Name :{0}\nEmployee Id :{1}\nEmployee DOB :{2}\nEmployee DOJ :{3}\nEmployee Mobile Number:{4} ", EmployeeList[i].EmployeeName, EmployeeList[i].EmployeeId, EmployeeList[i].DateOfBirth.ToShortDateString(), EmployeeList[i].DateOfJoining.ToShortDateString(), EmployeeList[i].MobileNumber);
                }
            }
            else {
                Console.WriteLine();
                Console.WriteLine("No Records Found");
            }

        }

    
                
        public  void Update(List<Employee> EmployeeList,Employee UpdateEmployee)
        {

            bool isupdated = false;
            int ModifyNumber=0;
            Console.WriteLine("Chose Option for Modify Employee Detail:");
            Console.WriteLine("1.Id \n2.Name \n3.dob \n4.Doj \n5.mobilenumber \n6.email ");
            try
            {
                ModifyNumber = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            switch (ModifyNumber)
            {
                case 1:
                    Console.WriteLine("Enter New Employee Id:");
                ReId:
                    string employeeId = Console.ReadLine();
                    var isvalidId = validate.ValidateId(employeeId);
                    if (isvalidId)
                    {
                        UpdateEmployee.EmployeeId = employeeId;
                        isupdated = true;
                    }
                    else {
                        goto ReId;
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter New Employee Name:");
                    ReName:
                    string employeeName = Console.ReadLine();
                    var isvalidName = validate.ValidateName(employeeName);
                    if (isvalidName)
                    {
                        UpdateEmployee.EmployeeName = employeeName;
                        isupdated = true;
                    }
                    else
                    {
                        goto ReName;
                    }
                    
                    break;
                case 3:
                    Console.WriteLine("Enter New Date Of Birth:");
                    ReDob:
                    string dateOfBirth =Console.ReadLine();
                    var isvalidBirth = validate.ValidateBirth(dateOfBirth);
                    if (isvalidBirth)
                    {
                        UpdateEmployee.DateOfBirth = Convert.ToDateTime(dateOfBirth);
                        isupdated = true;
                    }
                    else
                    {
                        goto ReDob;

                    }
                    
                    break;
                case 4:
                    Console.WriteLine("Enter New Date Of Joining:");
                    ReDoj:
                    string dateOfJoining = Console.ReadLine();                 
                    string dateBirth = Convert.ToString(employee.DateOfBirth);
                    var isvalidJoining = validate.ValidateJoining(dateOfJoining, dateBirth);
                    if (isvalidJoining)
                    {
                        UpdateEmployee.DateOfJoining = Convert.ToDateTime(dateOfJoining);
                        isupdated = true;
                    }
                    else
                    {
                        goto ReDoj;
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter New Mobile Number:");
                ReMobile:
                    string mobileNumber = Console.ReadLine();
                    var isvalidNo = validate.ValidateMobile(mobileNumber);
                    if (isvalidNo)
                    {
                        UpdateEmployee.MobileNumber = Convert.ToInt64(mobileNumber);
                        isupdated = true;
                    }
                    else
                    {
                        goto ReMobile;

                    }
                    
                    break;
                case 6:
                    Console.WriteLine("Enter New Mail ID:");
                ReMail:
                    string eMail = Console.ReadLine();
                    var isvalidMail = validate.ValidateMail(eMail);
                    if (isvalidMail)
                    {
                        UpdateEmployee.EMail = eMail;
                        isupdated = true;
                    }
                    else
                    {
                        goto ReMail;
                    }

                    break;

            }
              
            if (isupdated)
            {
                Console.WriteLine("successfully updated");
            }
            else
            {
                Console.WriteLine("employee not found");
            }
        }

        public static void Delete(List<Employee> EmployeeList, Employee DeleteEmployee)
        {
            bool isremoved = false;
            
            EmployeeList.Remove(DeleteEmployee);
            isremoved = true;
            if (isremoved)
            {
                Console.WriteLine("\nsuccessfully Removed");
            }
            else {
                Console.WriteLine("\nemployee  not found");
            }
        }     
    }
}