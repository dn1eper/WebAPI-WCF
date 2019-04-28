using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Server.Models;

namespace Server.Controllers
{
    public class EmployeeController : ApiController
    {
        private static List<Employee> employees = new List<Employee>()
        {
            new Employee() {
                Id         = 1,
                FirstName  = "John",
                LastName   = "Smith",
                Department = "IT"
            },
            new Employee() {
                Id         = 2,
                FirstName  = "Kira",
                LastName   = "Lambert",
                Department = "Sales"
            },
            new Employee() {
                Id = 3,
                FirstName  = "Lisa",
                LastName   = "Martin",
                Department = "Managment"
            },
            new Employee() {
                Id         = 4,
                FirstName  = "Patric",
                LastName   = "Neon",
                Department = "IT"
            },
            new Employee() {
                Id = 5,
                FirstName  = "Martin",
                LastName   = "Martin",
                Department = "Sales"
            }
        };

        public IEnumerable<Employee> Get()
        {
            return employees;
        }

        public Employee Get(int id)
        {
            lock (employees)
            {
                return employees.First(emp => emp.Id == id);
            }
        }

        public IEnumerable<Employee> Get(string name)
        {
            lock (employees)
            {
                return employees.Where(emp => emp.FirstName == name || emp.LastName == name);
            }
        }

        [HttpPost]
        public void Post([FromBody]Employee emp)
        {
            lock (employees)
            {
                emp.Id = employees.Max(e => e.Id) + 1;
                employees.Add(emp);
            }
        }

        [HttpPut]
        public void Edit([FromBody]Employee emp)
        {
            lock (employees)
            {
                Employee oldEmp = employees.First(e => e.Id == emp.Id);
                if (oldEmp != null)
                {
                    employees.Remove(oldEmp);
                    employees.Add(emp);
                }
            }
        }

        [HttpDelete]
        public void Remove(int id)
        {
            lock (employees)
            {
                Employee oldEmp = employees.First(e => e.Id == id);
                employees.Remove(oldEmp);
            }
        }
    }
}
