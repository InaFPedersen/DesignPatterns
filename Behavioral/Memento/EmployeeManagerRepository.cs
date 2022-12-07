using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        //for demo purposes, use an in-memory datastore as a fake "manager list"
        private List<Manager> _managers = new List<Manager>()
    {
        new Manager(1, "Katie"),
        new Manager(2, "George")
    };

        public void AddEmployee(int managerId, Employee employee)
        {
            //in real-life, add additional input and error checks
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            //in real-life, add additional input and error checks
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            //in real-life, add additional input and error checks
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employeeId);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees.");
                }
            }
        }

    }
}
