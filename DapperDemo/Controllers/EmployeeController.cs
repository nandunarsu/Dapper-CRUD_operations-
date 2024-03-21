using BussinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeebl employeebl;

        public EmployeeController(IEmployeebl employeedl)
        {
            this.employeebl = employeedl;
        }

        [HttpGet("getEmployeeValues")]
        public async Task<IActionResult> GetEmployeeList()
        {
            try
            {
                var employee = await employeebl.GetEmployees();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("InsertintoEmployee")]
        public async Task<IActionResult> InsertEmployees(int id,string name,int age,string position)
        {
            try {
                await employeebl.InsertEmployees(id, name, age, position);
                return Ok("Employee created");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occured while inserting the values");
            }
        }
        [HttpDelete("Deletebyid")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await employeebl.DeleteEmployee(id);
                return Ok("Employee deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occured while deleting");
            }
        }

        [HttpPut("Updatebyid")]
        public async Task<IActionResult> UpdateEmployees(int id, string name, int age, string position)
        {
            try
            {
                await employeebl.UpdateEmployees(id, name, age, position);
                return Ok("Employee updated");
            }
            catch
            {
                return StatusCode(500, "An error occured while updating");
            }
        }

        [HttpPut("InsertorUpdate")]

        public async Task<IActionResult> InsertorUpdateEmployees(int id, string name, int age, string position)
        {
            try
            {
                await employeebl.InsertorUpdateEmployees(id,name,age,position);
                return Ok("Employee updated if present else inserted");
            }
            catch
            {
                return StatusCode(500, "An error occured while updating or inserting");
            }
        }

        [HttpGet("Orderbyname")]
        public async Task<IActionResult> GetEmployeesbyname()
        {
            try
            {
               var employee =  await employeebl.GetEmployeesbyname();
                return Ok(employee);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
