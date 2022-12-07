using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Cindy"); //Quick Action to insert using statement
var managerClone = (Manager)manager.Clone();
Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Kevin", managerClone);
var employeeClone = (Employee)employee.Clone();
Console.WriteLine($"Employee was cloned: {employeeClone.Name}");

managerClone.Name = "Karen";
Console.WriteLine($"Employee was cloned: {employeeClone.Name}, " + $"with manager {employeeClone.Manager.Name}");

Console.ReadKey();