using API_Demo.Interface;
using API_Demo.Models;

namespace API_Demo.Service
{
    public class OrganizationService
    {
        private readonly IOrganization _Org;

        public OrganizationService(IOrganization org)
        {
            _Org = org;
        }

        public async Task<IEnumerable<Organization>> GetOrganizations()
        {
            return await _Org.GetAllOrganizations();
        }

        public async Task<Organization> GetOrganizationbyid(int id)
        {
            return await _Org.GetOrganizationbyid(id);
        }
        public async Task addorganization(Organization organ)
        {
            await _Org.AddOrganization(organ);
        }
    }
}
