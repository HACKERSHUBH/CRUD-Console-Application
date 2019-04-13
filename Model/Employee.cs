using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   /* public class Employee
    {
        // All the properties of Employee are described below
        public int EmployeeID
        {
            get;
            set;
        }
        public string EmployeeName
        {
            get;
            set;
        }
        public string DeptWorking
        {
            get;
            set;
        }
        public float Salary
        {
            get;
            set;
        }
    }
    */

    public class DellEmp
    {
        double _basic = 5000;
        protected BenefitPackage empBenefits = new BenefitPackage();

        //Containment/Delegation or aggregation
        //Every Employee "has-a" BenefitPackage
        public class BenefitPackage
        {
            public enum BenefitPackageLevel
            {
                Standard, Gold, Platinum
            }

            public double ComputePayDeduction()
            {
                return 120.5;
            }
        }

        public double CalculateSalary()
        {
            return _basic*2;
        }


        public double GetBenefitCost()
        {
            return empBenefits.ComputePayDeduction();
        }

        public BenefitPackage Benefits
        {
            get { return empBenefits; }
            set { empBenefits = value; }
        }



        public int Emp_Id
        {
            get ;
            set ;
        }
        public string Emp_Name
        {
            get;
            set;
        }
        public string Emp_Address
        {
            get;
            set;
        }
        public string Emp_Designation
        {
            get;
            set;
        }

        public float Emp_Pay
        {
            get;
            set;
        }

        public DellEmp() { }
        public DellEmp(int id, string name, string address , string designation, float pay)
        {
            Emp_Id = id;
            Emp_Name = name;
            Emp_Address = address;
            Emp_Designation = designation;
            Emp_Pay = pay;
        }
        public void GiveBonus(float amount)
        {
            Emp_Pay += amount;
        }
    }

    public class Manager : DellEmp
    {
        double _basic = 5000 ;
        double _sales= 2000;

        public Manager() { }

        public Manager(int id, string name, string address, string designation, float pay, int numbOfOpts) : base(id, name, address, designation, pay)
        {
            StockOptions = numbOfOpts;
        }

        public new double CalculateSalary()
        {
            return _basic*2 + _sales;
        }

        public int StockOptions { get; set; }
    }


    class SalesPerson : DellEmp
    {
        public SalesPerson() { }

        public SalesPerson(int id, string name, string address, string designation, float pay, int numOfSales) : base(id, name, address, designation, pay)

        {
            SalesNumber = numOfSales;
        }

        public int SalesNumber { get; set; }
    }

    [Serializable]
    public class ClassToSerialize
    {
        
        public int Age { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        
    }
    
}




