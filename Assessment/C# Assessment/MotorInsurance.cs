using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class MotorInsurance:Insurance
    {
        private double idv;
        private float depPercent;
        public double Idv
        {
            get { return idv; }
            set { idv = value; }
        }
        public float DepPercent
            { get { return depPercent; } 
            set { depPercent = value; }
        }  
        public double CalculatePremium()
        {
            idv = AmountCovered - ((AmountCovered * depPercent) / 100);
            return idv * 0.03;
        }

    }
}
