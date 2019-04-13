using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Services;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace MiniProject
{

    public class Program
    {
        public static List<DellEmp> employeeList = new List<DellEmp>();
        public static void Main(string[] args)
        {
           
            Program obj_Company = new Program();

            //DellEmp DEmp = new DellEmp();
            
            char ans;
            int search_Id;
            do
            {
                Console.Clear();
                Console.WriteLine("**************************EMPLOYEE MANAGEMENT SYSTEM MENU******************************");
                Console.WriteLine("1. Add  an Employee");
                Console.WriteLine("2. View Employee details");
                Console.WriteLine("3. Search Employee details");
                Console.WriteLine("4. Modify Employee details");
                Console.WriteLine("5. Remove Employee details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Enter Your Choice Here:-");
                int choose_number = Convert.ToInt32(Console.ReadLine());

                switch (choose_number)
                {
                    case 1:
                        obj_Company.Function_Add_Employee(employeeList);
                        obj_Company.Function_Display_Employee(employeeList);
                        break;
                    case 2:
                        obj_Company.Function_Display_Employee(employeeList);
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        DellEmp obj_search = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_search != null)
                        {
                            Console.WriteLine("Employee ID \t{0}", obj_search.Emp_Id);
                            Console.WriteLine("Employee Name \t{0}", obj_search.Emp_Name);
                            Console.WriteLine("Employee Address \t{0}", obj_search.Emp_Address);
                            Console.WriteLine("Designation \t{0}\n", obj_search.Emp_Designation);
                            Console.WriteLine("Pay \t{0}\n", obj_search.Emp_Pay);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        DellEmp obj_Modify = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_Modify != null)
                        {
                            Console.WriteLine("Employee ID      :" + obj_Modify.Emp_Id);
                            Console.WriteLine("Employee Name    :" + obj_Modify.Emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Modify.Emp_Address);
                            Console.WriteLine("Designation      :" + obj_Modify.Emp_Designation);
                            Console.WriteLine("Pay      :" + obj_Modify.Emp_Pay);
                            obj_Company.Fucntion_Modify_Employee(employeeList, obj_Modify);
                            obj_Company.Function_Display_Employee(employeeList);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = Convert.ToInt32(Console.ReadLine());
                        DellEmp obj_Delete = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_Delete != null)
                        {
                            Console.WriteLine("Employee ID      :" + obj_Delete.Emp_Id);
                            Console.WriteLine("Employee Name    :" + obj_Delete.Emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Delete.Emp_Address);
                            Console.WriteLine("Designation      :" + obj_Delete.Emp_Designation);
                            Console.WriteLine("Pay      :" + obj_Delete.Emp_Pay);
                            obj_Company.Function_Remove(employeeList, obj_Delete);
                            obj_Company.Function_Display_Employee(employeeList);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice....!!! Please Enter Correct Choice...!!!");
                        break;
                }
                Console.Write("Would You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'y' || ans == 'Y');
        }

        public void Function_Add_Employee(List<DellEmp> employeeList)
        {
            DellEmp obj_Comapny1 = new DellEmp();
            Console.Write("Enter Employee Id:");
            obj_Comapny1.Emp_Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name:");
            obj_Comapny1.Emp_Name = Console.ReadLine();
            Console.Write("Enter Employee Addess:");
            obj_Comapny1.Emp_Address = Console.ReadLine();
            Console.Write("Enter Employee Designation:");
            obj_Comapny1.Emp_Designation = Console.ReadLine();
            Console.Write("Enter Employee Pay:");
            obj_Comapny1.Emp_Pay = float.Parse(Console.ReadLine());

            employeeList.Add(obj_Comapny1);

            


            if (!File.Exists("Test.xml"))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create("Test.xml", xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("School");

                    xmlWriter.WriteStartElement("Student");
                    xmlWriter.WriteElementString("Name", obj_Comapny1.Emp_Name);
                    xmlWriter.WriteElementString("Address", obj_Comapny1.Emp_Address);
                    xmlWriter.WriteElementString("ID", obj_Comapny1.Emp_Id.ToString());
                    xmlWriter.WriteElementString("Designation", obj_Comapny1.Emp_Designation);
                    xmlWriter.WriteElementString("Pay", obj_Comapny1.Emp_Pay.ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load("Test.xml");
                XElement root = xDocument.Element("School");
                IEnumerable<XElement> rows = root.Descendants("Student");
                XElement firstRow = rows.First();
                firstRow.AddBeforeSelf(
                   new XElement("Student",
                   new XElement("Name", obj_Comapny1.Emp_Name),
                   new XElement("Address", obj_Comapny1.Emp_Address),
                   new XElement("ID", obj_Comapny1.Emp_Id.ToString()),
                   new XElement("Designation", obj_Comapny1.Emp_Designation),
                   new XElement("Pay", obj_Comapny1.Emp_Pay.ToString())));
                xDocument.Save("Test.xml");
            }

            Console.ReadKey();
            Console.WriteLine("Employee Detail Added Successfully...!!!!:");

        }

        public void Function_Display_Employee(List<DellEmp> employeeList)
        {

            Console.WriteLine("****************************Employee Details****************************************");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Employee Id\tEmployee Name\tEmployee Addess\tEmployee Designation\tEmployee Pay");
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (DellEmp i in employeeList)
            {
                Console.WriteLine(i.Emp_Id + "      \t|  " + i.Emp_Name + " \t| " + i.Emp_Address + "   \t|  " + i.Emp_Designation + "   \t|  " + i.Emp_Pay);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
            //List<DellEmp> list = new List<DellEmp>();
            //XmlSerializer serializer = new XmlSerializer(typeof(List<DellEmp>));
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "TestView.txt");
            XmlSerializer xs = new XmlSerializer(typeof(List<DellEmp>));
            xs.Serialize(stream, employeeList);
            stream.Close();


        }
       



        public DellEmp Function_Search(List<DellEmp> employeeList, int search_Id)
        {
            return employeeList.Find(emp => emp.Emp_Id == search_Id);
        }


        public void Fucntion_Modify_Employee(List<DellEmp> employeeList, DellEmp obj_Modify)
        {
            Console.WriteLine("Chose Option for Modify Employee Detail:");
            Console.WriteLine("1.Id 2.Name 3.Address 4.Designation 5.Pay");
            int modify_number = Convert.ToInt32(Console.ReadLine());
            switch (modify_number)
            {
                case 1:
                    Console.WriteLine("Enter New Employee Id:");
                    int new_Id = Convert.ToInt32(Console.ReadLine());
                    obj_Modify.Emp_Id = new_Id;
                    break;
                case 2:
                    Console.WriteLine("Enter New Employee Name:");
                    string new_Name = Console.ReadLine();
                    obj_Modify.Emp_Name = new_Name;
                    break;
                case 3:
                    Console.WriteLine("Enter New Employee Address:");
                    string new_Address = Console.ReadLine();
                    obj_Modify.Emp_Address = new_Address;
                    break;
                case 4:
                    Console.WriteLine("Enter New Employee Designation:");
                    string new_Designation = Console.ReadLine();
                    obj_Modify.Emp_Designation = new_Designation;
                    break;
                case 5:
                    Console.WriteLine("Enter New Employee Pay:");
                    float new_Pay = float.Parse(Console.ReadLine());
                    obj_Modify.Emp_Pay = new_Pay;
                    break;
                default:
                    Console.WriteLine("Invalide Choise....");
                    break;
            }
            // employeeList.Add(obj_Modify);
        }

        public void Function_Remove(List<DellEmp> employeeList, DellEmp obj_Modify)
        {
            employeeList.Remove(obj_Modify);
            Console.WriteLine("1 Record Removed SuccessFully....!!!");
        }


    }

}