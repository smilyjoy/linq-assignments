using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.Design;
using Microsoft.Win32.SafeHandles;

namespace linqassign1
{
    public class Employee
    {
        int EmployeeID;
        string FirstName;
        string LastName;
        string Title;
        DateTime DOB;
        DateTime DOJ;
        string City;
        public Employee(int EmployeeID, string FirstName, string LastName, string Title, DateTime DOB, DateTime DOJ, string City)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.DOB = DOB;
            this.DOJ = DOJ;
            this.City = City;

        }
        public int EmployeeId
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }
        public string Firstname
        {
            get { return FirstName; }
            set { FirstName = value; }
        }
        public string Lastname
        {
            get { return LastName; }
            set { LastName = value; }
        }
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }
        public DateTime dob
        {
            get { return DOB; }
            set { DOB = value; }
        }
        public DateTime doj
        {
            get { return DOJ; }
            set { DOJ = value; }
        }
        public string city
        {
            get { return City; }
            set { City = value; }
        }
        public static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee(1001, "Malcolm", "Daruwalla", "Manager", new DateTime(1984, 11, 16), new DateTime(2011, 6, 8), "Mumbai"));
            empList.Add(new Employee(1002, "Asdin", "Dhalla", "AsstManager", new DateTime(1984, 8, 20), new DateTime(2012, 7, 7), "Mumbai"));
            empList.Add(new Employee(1003, "Madhavi", "Oza", "Consultant", new DateTime(1987, 11, 14), new DateTime(2015, 4, 12), "Pune"));
            empList.Add(new Employee(1004, "Saba", "Shaikh", "SE", new DateTime(1990, 6, 3), new DateTime(2016, 2, 2), "Pune"));
            empList.Add(new Employee(1005, "Nazia", "Shaikh", "SE", new DateTime(1991, 3, 8), new DateTime(2016, 2, 2), "Mumbai"));
            empList.Add(new Employee(1006, "Amit", "Pathak", "Consultant", new DateTime(1989, 11, 7), new DateTime(2014, 8, 8), "Chennai"));
            empList.Add(new Employee(1007, "Vijay", "Natrajan", "Consultant", new DateTime(1989, 12, 2), new DateTime(2015, 6, 1), "Mumbai"));
            empList.Add(new Employee(1008, "Rahul", "Dubey", "Associate", new DateTime(1993, 11, 11), new DateTime(2014, 11, 6), "Chennai"));
            empList.Add(new Employee(1009, "Suresh", "Mistry", "Associate", new DateTime(1992, 8, 12), new DateTime(2014, 12, 3), "Chennai"));
            empList.Add(new Employee(1010, "Sumit", "Shah", "Manager", new DateTime(1991, 4, 12), new DateTime(2016, 1, 2), "Pune"));
            IEnumerable<Employee> employeeQuery = from emp in empList select emp;
            foreach (Employee employee in employeeQuery)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("----------------Employee details whose city is not Mumbai----------------");
            IEnumerable<Employee> employeeQuery2 = from emp in empList where emp.City != "Mumbai" select emp;
            foreach (Employee employee in employeeQuery2)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("----------------Employee details whose title is AsstManager-----------------");
            IEnumerable<Employee> employeeQuery3 = from emp in empList where emp.Title == "AsstManager" select emp;
            foreach (Employee employee in employeeQuery3)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("-------------Employee details whose lastname starts with S-----------------");
            IEnumerable<Employee> employeeQuery4 = from emp in empList where emp.LastName.StartsWith("S") select emp;
            foreach (Employee employee in employeeQuery4)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("--------------Employee details who joined before 1/1/2015--------------");
            IEnumerable<Employee> employeeQuery5 = from emp in empList where emp.DOJ < (new DateTime(2015, 1, 1)) select emp;
            foreach (Employee employee in employeeQuery5)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("--------------Employee details whose date of birth is after 1/1/1990---------------");
            IEnumerable<Employee> employeeQuery6 = from emp in empList where emp.DOB > (new DateTime(1990, 1, 1)) select emp;
            foreach (Employee employee in employeeQuery6)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("---------------Employee details whose designation is consulant and Associate--------------");
            IEnumerable<Employee> employeeQuery7 = from emp in empList where (emp.Title == "Consultant") || (emp.Title == "Associate") select emp;
            foreach (Employee employee in employeeQuery7)
            {
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("----------Total number of Employees-------------");
            int Result = empList.Count();
            Console.WriteLine("Total number of employees are {0}", Result);
            Console.WriteLine("----------------Number of Employees belonging to Chennai-------------");
            int result = (from emp in empList where emp.City == "Chennai" select emp).Count();
            Console.WriteLine("Total number of employees in chennai are {0}", result);
            Console.WriteLine("--------------Highest employee ID from the list------------------");
            int Highest = empList.Max(emp => emp.EmployeeID);
            Console.WriteLine("Highhest employeeID value is {0}", Highest);
            Console.WriteLine("--------------Employee details who joined after 1/1/2015--------------");
            IEnumerable<Employee> employeeQuery8 = from emp in empList where emp.DOJ > (new DateTime(2015, 1, 1)) select emp;
            foreach (Employee employee in employeeQuery)
            { 
                Console.WriteLine("Employee:{0},{1},{2},{3},{4},{5},{6}", employee.EmployeeId, employee.Firstname, employee.Lastname, employee.title, employee.dob, employee.doj, employee.city);
            }
            Console.WriteLine("-----------number of employees whose designation is not Associate-----------------");
            int count = empList.Count(emp => emp.Title != "Associate");
            Console.WriteLine("Total number of employees whose designation is not Associate are {0}", count);
            Console.WriteLine("-------------number of employees based on city-----------------");
            int result1 = (from emp in empList group emp by emp.City).Count();
            Console.WriteLine("Total number of employees based on Cities {0}", result1);
            Console.WriteLine("---------------Number of employees based on city and Title-----------------");
            int result2 = (from emp in empList group emp by (emp.City, emp.Title)).Count();
            Console.WriteLine("Total number of employees based on city and title {0}", result2);
            Console.WriteLine("---------------employee details who is youngest in the list--------------");
            var Youngest = empList.Select(emp => emp.DOB);
            Console.WriteLine(Youngest.Min());
            Console.ReadKey();
        }



    }
}