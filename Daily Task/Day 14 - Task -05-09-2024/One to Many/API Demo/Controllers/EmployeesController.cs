using API_Demo.Models;
using API_Demo.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _ser;

        public EmployeesController(EmployeeService ser)
        {
            _ser = ser;
        }


        // GET: api/<EmployeesController>
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _ser.GetEmployees();
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _ser.GetEmployeebyid(id);
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
           await _ser.addemployee(employee);
            return Ok("Added Successfully");
        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employee employee)
        {
            
            if (id == employee.empId)
            { 
                await _ser.updateemployee(employee);
                return Ok("Updated successfully");
            }
            else
            {
                return Ok("Id MisMatch");
            }
            
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public async Task  Delete(int id)
        {
          await _ser.DeleteEmployees(id);
            
        }
    }
}
