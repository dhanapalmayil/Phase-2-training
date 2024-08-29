// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!"); 

Console.WriteLine(  "Enter the Insurance Number");
string inNo=Console.ReadLine();
Console.WriteLine("Enter the Insurance Name");
string inName=Console.ReadLine();
Console.WriteLine("Enter amount Covered");
double amt=Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Select \n 1)Life Insurance \n2)Motor Insurance");
int type=Convert.ToInt32(Console.ReadLine());
Insurance idv;
int pt=0;
double bp=0;
float depper=0;
if (type == 1)
{
    Console.WriteLine("Enter the Policy Term");
     pt=Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the Benefit Percent");
     bp= Convert.ToSingle(Console.ReadLine());
    idv = new LifeInsurance();
    Console.WriteLine("Calculated Premium :"+addPolicy(idv, 1));
}

else if (type == 2)
{
    Console.WriteLine("Enter Deprectian Percentage");
    depper=Convert.ToSingle(Console.ReadLine());
    idv = new MotorInsurance();
    Console.WriteLine("Calculated Premium :" + addPolicy(idv, 2));
}

 double addPolicy(Insurance ins,int opt)
{
    if (opt==1)
    {
        ins.InsuranceNo = inNo;
        ins.InsuranceName = inName;
        ins.AmountCovered= amt;
        LifeInsurance lf=(LifeInsurance)ins;
        lf.PolicyTerm = pt;
        lf.BenefitPercent = Convert.ToSingle(bp);
        return (lf.CalculatePremium());
    }
    else
    {
        ins.InsuranceNo = inNo;
        ins.InsuranceName = inName;
        ins.AmountCovered = amt;
        MotorInsurance mt= (MotorInsurance)ins;
        mt.DepPercent= Convert.ToSingle(depper);
        return (mt.CalculatePremium());
    }

    
}


