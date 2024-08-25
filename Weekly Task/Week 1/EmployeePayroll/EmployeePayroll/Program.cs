using EmployeePayroll;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Employee Payroll Management");
        Console.WriteLine("Enter the details");
        Console.WriteLine("Enter the type of Employee: \n Press (1) for Permanent \n Press (2) for Temporary");
        int emptype = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Employee ID : ");
        int empId= Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter the Employee Name : ");
        string empname=Console.ReadLine();
        int basicSalary=0, pf = 0, dailypay = 0, noOfDays = 0;
        if (emptype == 1) {
            Console.Write("Enter the Basic Salary : ");
            basicSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the PF : ");
            pf = Convert.ToInt32(Console.ReadLine());
        }
        else if (emptype == 2)
        {
            Console.Write("Enter the Daily Pay : ");
            dailypay= Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter No.of Days Worked : ");
            noOfDays = Convert.ToInt32(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("Please Enter valid input");
        }
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("The Details are :");
        Console.WriteLine("Employee Id : "+empId );
        Console.WriteLine("Employee Name : " + empname);
        if (emptype == 1)
        {
            PermanentEmployee pobj=new PermanentEmployee();
            pobj.pf = pf;
            float bonus = pobj.CalculateBonus(basicSalary, emptype);
            float netsalary = pobj.CalculateSalary(empId,empname,basicSalary);
            Console.WriteLine("Basic Salary : "+basicSalary);
            Console.WriteLine("PF : "+pf);
            Console.WriteLine( "Bonus : "+bonus);
            Console.WriteLine("Net Salary : "+netsalary);
        }
        else
        {
            TemporaryEmployee tobj= new TemporaryEmployee();
            tobj.DailyWages= dailypay;
            tobj.NoOfDays = noOfDays;
            float bonus=tobj.CalculateBonus((dailypay*noOfDays), emptype);
            float netsalary=tobj.CalculateSalary(empId, empname,(dailypay*noOfDays));
            Console.WriteLine("Daily Wages : " + dailypay);
            Console.WriteLine("No of Days : " + noOfDays);
            Console.WriteLine("Bonus : " + bonus);
            Console.WriteLine("Net salary : "+netsalary);
        }
    }
}