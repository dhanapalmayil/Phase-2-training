using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    internal class PermanentEmployee : Employee
    {
        public int pf { get; set; }

        public override float CalculateBonus(float salary, int criteria)
        {
            if(this.pf < 1000)
            {
                return salary * 0.10f;
            }
            else if(this.pf >= 1000 && pf<1500) {
                return salary * 0.115f;
            }
            else if(pf >= 1500 && pf < 1800)
            {
                return salary * 0.12f;
            }
            else
            {
                return salary * 0.15f;
            }
               
        }

        public override float CalculateSalary(int id, string name, float basicSalary)
        {
            return basicSalary-this.pf;
        }
    }
}
