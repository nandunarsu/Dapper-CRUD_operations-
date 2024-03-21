using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IEmployee
    {
        public Task<IEnumerable<Employee>> GetEmployees();
        public Task<IEnumerable<Employee>> GetEmployeesbyname();
        public Task InsertEmployees(int id, string name, int age, string position);
        public Task DeleteEmployees(int id);
        public Task UpdateEmployees(int id, string name, int age, string position);

        public Task InsertorUpdateEmployees(int id, string name, int age, string position);

    }
}
