using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class TemporaryEmployee : Employee
    {
        public int DailyWages { get; set; }

        public int NoOfDays {  get; set; }
        public override float CalculateBonus(float salary, int criteria)
        {
            if (DailyWages < 1000)
            {
                return salary * (0.15f);
            }
            else if(DailyWages >=1000 && DailyWages < 1500)
            {
                return salary * (0.12f);
            }
            else if (DailyWages >=1500 && DailyWages < 1750)
            {
                return salary * 0.11f;
            }
            else
            {
                return salary * 0.08f;
            }
        }

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            return DailyWages* NoOfDays;
        }
    }
}
