using API_Demo.Models;
using API_Demo.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class OrganizationsController : ControllerBase
    {
        private readonly OrganizationService _ser;

        public OrganizationsController (OrganizationService ser)
        {
              _ser = ser;
        }
        // GET: api/<OrganizationsController>
        [HttpGet]
        public async Task<IEnumerable<Organization>> Get()
        {
            return await _ser.GetOrganizations();
        }

        // GET api/<OrganizationsController>/5
        [HttpGet("{id}")]
        public async Task<Organization> Get(int id)
        {
            return await _ser.GetOrganizationbyid(id);
        }

        // POST api/<OrganizationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Organization org)
        {
            await _ser.addorganization(org);
            return Ok("Added successfully");
        }

        // PUT api/<OrganizationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrganizationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
