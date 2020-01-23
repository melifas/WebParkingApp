using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Data_Access
    {
        public void CreateEmployee(int employeeid,string employeeFName,string employeeLName, string employeePassword) { 
            using(testDBEntities db = new testDBEntities())
            {
                Employee em = new Employee
                {
                    EmployeeID = employeeid,
                    FirstName = employeeFName,
                    LastName = employeeLName,
                    Password = employeePassword
                };
                db.Employee.Add(em);
                db.SaveChanges();
            }
        }

        public List<Employee> LoadEmployees()
        {
            using (testDBEntities db = new testDBEntities())
            {
                return  db.Employee.ToList();
            }
        }

    }
}
