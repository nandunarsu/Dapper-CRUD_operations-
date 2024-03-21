using Repository.Context;
using Repository.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Reflection.Metadata;

namespace Repository.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly Dappercontext _context;
        public EmployeeService(Dappercontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var query = "SELECT * FROM Employees";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }

        public async Task InsertEmployees(int id,string name,int age,string position)
        {
            var query = "INSERT INTO Employees(Id,Name,Age,Position)VALUES (@id,@name,@age,@position);";
            var Parameter = new DynamicParameters();
            Parameter.Add("Id", id, DbType.Int64);
            Parameter.Add("Name", name, DbType.String);
            Parameter.Add("Age", age, DbType.Int64);
            Parameter.Add("Position", position, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, Parameter);
            }
        }
        public async Task DeleteEmployees(int id)
        {
            var query = "DELETE FROM Employees WHERE Id = @id;";
            var Parameter = new DynamicParameters();
            Parameter.Add("Id", id, DbType.Int64);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, Parameter);
            }
        }
        public async Task UpdateEmployees(int id, string name, int age, string position)
        {

            var query = "UPDATE Employees set Name = @name ,Age = @age,Position = @position where Id = @id;";
            var Parameter = new DynamicParameters();
            Parameter.Add("Id", id, DbType.Int64);
            Parameter.Add("Name", name, DbType.String);
            Parameter.Add("Age", age, DbType.Int64);
            Parameter.Add("Position", position, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, Parameter);
            }
        }
        public async Task InsertorUpdateEmployees(int id, string name, int age, string position)
        {
            var Procedure = "Updatevalue";
            var Parameters = new DynamicParameters();
            Parameters.Add("Id", id,DbType.Int64);
            Parameters.Add("Name", name,DbType.String);
            Parameters.Add("Age", age,DbType.Int64);
            Parameters.Add("Position", position, DbType.String);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(Procedure,Parameters,commandType:CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployeesbyname()
        {
            var query = "SELECT * FROM Employees ORDER BY Name;";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<Employee>(query);
                return employee.ToList();
            }
        }


    }
}
