using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniProject;
using Model;

namespace UnitTestProject
{
    [TestClass]
    public class EmployeeTest
    {
        Program p = new Program();
        // we have declared the static list

        [TestMethod]
        public void AddEmployeeTest()
        {
            DellEmp o = new DellEmp
            {
                Emp_Id = 1,
                Emp_Name = "Shubham",
                Emp_Address = "Bangalore",
                Emp_Designation = "SDE2",
                Emp_Pay = 223456.9f
            };
            Program.employeeList.Add(o);

            //p.Function_Add_Employee(Program.employeeList);
            //static members are accessed with the name of class
            Assert.AreEqual(1, Program.employeeList.Count());
            var empAdded = Program.employeeList.Where(x => x.Emp_Id == 1);
            Assert.IsNotNull(empAdded);

            //upto here i have a new elist which have an object o 
            foreach (DellEmp e in Program.employeeList)
            {
                Assert.AreEqual("Shubham", e.Emp_Name);
                Assert.AreEqual("SDE2", e.Emp_Designation);
                Assert.AreEqual("Bangalore", e.Emp_Address);


            }

        }


        [TestMethod]
        public void UpdateEmployeeTest()
        {
            var obj = Program.employeeList.FirstOrDefault(x => x.Emp_Name == "Shubham");
            if (obj != null) obj.Emp_Id = 2;
            foreach (DellEmp e in Program.employeeList)
            {
                Assert.AreEqual("Shubham", e.Emp_Name);
                Assert.AreEqual("SDE2", e.Emp_Designation);
                Assert.AreEqual("Bangalore", e.Emp_Address);
                Assert.AreEqual(2 , e.Emp_Id);

            }
        }

        [TestMethod]
        public void DeleteEmployeeTest()
        {
            Program.employeeList.RemoveAll(y => y.Emp_Id == 2);
            Assert.AreEqual(0, Program.employeeList.Count());
        }

    }

}

//Arrange
// Program p = new Program();
//string E= "Shubham";
//float s= 11087.9f ;
//int i =1;
//string d= "FTA";

//Act
//p.AddEmployeeTest(E,s,i,d);

//Assert

/*foreach (DellEmp e in p.Employeelist)
{
    Assert.AreEqual(E, e.EmployeeName);
    Assert.AreEqual(s, e.Salary);
    Assert.AreEqual(i, e.EmployeeID);
    Assert.AreEqual(d, e.DeptWorking);
}*/

//