using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetails
{
    public abstract class Home{

        public abstract void CallMenu();
    }

    class MainMenu : Home
    {
        Crud crud = new Crud();
        Find find = new Find();

        public override void CallMenu()
        {
        option:
            Console.WriteLine(" ----------------------");
            Console.WriteLine("| Employee Application |");
            Console.WriteLine(" ----------------------");
            Console.WriteLine("1.Create An Employee Detail");
            Console.WriteLine("2.Display The Employee Details");
            Console.WriteLine("3.Update The Employee Details");
            Console.WriteLine("4.Delete The Employee Details");
            Console.WriteLine("5.Exit");
            Console.WriteLine();
            Console.WriteLine("Select the Option to perform:");
        option1:
            int option = 0;
            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            switch (option)
            {
                case 1:

                    crud.Create();
                    Console.WriteLine();
                    Console.ReadKey();
                    goto option;

                case 2:
                    Crud.Read();
                    Console.ReadKey();
                    goto option;

                case 3:
                    Console.WriteLine("Update the Existing Data using options below :");
                    Console.WriteLine("1.Using Employee ID\n2.Using Employee Mobile Number");
                    bool UpdateIn =int.TryParse( Console.ReadLine(),out int UpdateOut);
                    if (UpdateOut == 1)
                    {
                        UpdateWithId();
                    }
                    else if (UpdateOut == 2)
                    {
                        UpdateWithMobile();
                    }
                    Console.ReadKey();
                    goto option;

                case 4:
                    Console.WriteLine("Delete the Existing Data using options below :");
                    Console.WriteLine("1.Using Employee ID\n2.Using Employee MObile Number");
                    bool DeleteIn = int.TryParse(Console.ReadLine(), out int DeleteOut);
                    if (DeleteOut == 1)
                    {
                        DeleteWithId();
                    }
                    else if (DeleteOut == 2)
                    {
                        DeleteWithMobile();
                    }
                    Console.ReadKey();
                    goto option;

                case 5:
                    break;

                default:
                    Console.WriteLine("Please Enter the correct option between 1 and 5 :");
                    goto option1;

            }




        }

        private void DeleteWithMobile()
        {
        DeleteMobile:
            Console.WriteLine("Enter the employee mobile number which you want to delete: ");
            var findUpdate = Console.ReadLine();
            bool ismobileno = long.TryParse(findUpdate, out long mobileno);
            if (ismobileno)
            {

                Employee DeleteEmployee = find.FindEmployee(Crud.EmployeeList, mobileno);
                try
                {
                    if (DeleteEmployee != null)
                    {
                         Crud.Delete(Crud.EmployeeList, DeleteEmployee);
                    }
                    else
                    {
                        throw new NoRecordException();
                    }
                }
                catch (NoRecordException Exception)
                {
                    Console.WriteLine(Exception.Message);
                    goto DeleteMobile;
                }
            }
            else
            {
                Console.WriteLine("The valid Mobile number should starts with between 6 and 9 and followed by 9 digit number");
                goto DeleteMobile;
            }
        }

        private void DeleteWithId()
        {
        DeleteID:
            Console.WriteLine("Enter the employee id which you want to update: ");
            string findUpdate = Console.ReadLine();
            Employee DeleteEmployee = find.FindEmployee(Crud.EmployeeList, findUpdate);
            try
            {
                if (DeleteEmployee != null)
                {
                    Crud.Delete(Crud.EmployeeList, DeleteEmployee);
                }
                else
                {
                    throw new NoRecordException();
                }
            }
            catch (NoRecordException Exception)
            {
                Console.WriteLine(Exception.Message);
                goto DeleteID;
            }
        }
    

        private void UpdateWithMobile()
        {
            UpdateMobile:
            Console.WriteLine("Enter the employee mobile number which you want to update: ");
            var findUpdate = Console.ReadLine();
            bool ismobileno = long.TryParse(findUpdate, out long mobileno);
            if (ismobileno)
            {

                Employee UpdateEmployee = find.FindEmployee(Crud.EmployeeList, mobileno);
                try
                {
                    if (UpdateEmployee != null)
                    {
                        crud.Update(Crud.EmployeeList, UpdateEmployee);
                    }
                    else
                    {
                        throw new NoRecordException();
                    }
                }
                catch (NoRecordException Exception)
                {
                    Console.WriteLine(Exception.Message);
                    goto UpdateMobile;
                }
            }
            else {
                Console.WriteLine("The valid Mobile number should starts with between 6 and 9 and followed by 9 digit number");
                goto UpdateMobile;
            }
        }

        private void UpdateWithId()
        {
            UpdateId:
            Console.WriteLine("Enter the employee id which you want to update: ");
            string findUpdate = Console.ReadLine();
            Employee UpdateEmployee = find.FindEmployee(Crud.EmployeeList, findUpdate);
            try
            {
                if (UpdateEmployee != null)
                {
                    crud.Update(Crud.EmployeeList, UpdateEmployee);
                }
                else
                {
                    throw new NoRecordException();
                }
            }
            catch (NoRecordException Exception) {
                Console.WriteLine(Exception.Message);
                goto UpdateId;
            }
        }
    }
}
