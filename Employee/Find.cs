using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails
{
    class Find
    {
        public Employee FindEmployee(List<Employee> EmployeeList, string employeeId)
        {
            
            Employee data = null;
            
                if (EmployeeList.Exists(Employee => Employee.EmployeeId == employeeId))
                {
                    data = EmployeeList.Find(Employee => Employee.EmployeeId == employeeId);

                }
                
            return data;
        }

        public Employee FindEmployee(List<Employee> EmployeeList, long mobileNo)
        {
            
            Employee data = null;
            
                if (EmployeeList.Exists(Employee => Employee.MobileNumber == mobileNo))
                {
                    data = EmployeeList.Find(Employee => Employee.MobileNumber == mobileNo);

                }           
           
            return data;
        }
    }
}
