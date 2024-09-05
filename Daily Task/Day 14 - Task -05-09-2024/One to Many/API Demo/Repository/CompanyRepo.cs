using API_Demo.Interface;
using API_Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Repository
{
    public class CompanyRepo : IOrganization
    {

        private readonly EmployeeOrgContext _Context;

        public CompanyRepo(EmployeeOrgContext context)
        {

            _Context = context;

        }

        public async Task AddOrganization(Organization organization)
        {
            await _Context.Organizations.AddAsync(organization);
            await _Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Organization>> GetAllOrganizations()
        {
            return await _Context.Organizations.Include(e=>e.Employees).ToListAsync();
        }

        public async Task<Organization> GetOrganizationbyid(int id)
        {
            return await _Context.Organizations.FirstOrDefaultAsync(e => e.OrgId == id) ?? new Organization();
        }
    }
}
