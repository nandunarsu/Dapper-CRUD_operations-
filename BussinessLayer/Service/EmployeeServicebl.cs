using BussinessLayer.Interface;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Service
{
    public class EmployeeServicebl : IEmployeebl
    {
        private readonly IEmployee employee;

        public EmployeeServicebl(IEmployee employee)
        {
            this.employee = employee;
        }

        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return employee.GetEmployees();
        }
        public Task InsertEmployees(int id, string name, int age, string position)
        {
            return employee.InsertEmployees(id, name, age, position);
        }

        public Task DeleteEmployee(int id)
        {
            return employee.DeleteEmployees(id);
        }
        public Task UpdateEmployees(int id, string name, int age, string position)
        {
            return employee.UpdateEmployees(id, name, age, position);
        }
        public Task InsertorUpdateEmployees(int id, string name, int age, string position)
        {
            return employee.InsertorUpdateEmployees(id,name,age,position);
        }
        public Task<IEnumerable<Employee>> GetEmployeesbyname()
        {
            return employee.GetEmployeesbyname();   
        }
    }
}
