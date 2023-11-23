using Dynamodb_webapi.Models;
using Dynamodb_webapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Dynamodb_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpMethods _empmethods;
        public EmployeeController(IEmpMethods empMethods) {
            _empmethods = empMethods;
        
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var emp=await _empmethods.GetAllEmployees();
            return emp.Count > 0 ? Ok(emp) : Ok(NoContent());
        }
       
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee=await _empmethods.GetEmployeeById(id);
            return employee!=null?Ok(employee):Ok(NotFound());
        }
        [HttpPost]
        public async Task<IActionResult> InsertEmployee(Employee employee)
        {
           //employee.InsertDate = DateTime.Now;
           bool k=await _empmethods.InsertEmployee(employee);
           return Ok(k);

        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateEmployee(int id,Employee employee)
        {
           employee.InsertDate = DateTime.Now;
            bool k =await _empmethods.UpdateEmployee(id,employee);
            return Ok(k);

        }
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteEmployee(int id)
        
        {
            bool k=await _empmethods.DeleteEmployee(id);
            return Ok(k);
        }
       

    }
}
