using API_Demo.Models;

namespace API_Demo.Interface
{
    public interface IOrganization
    {
        Task<IEnumerable<Organization>> GetAllOrganizations();

        Task<Organization> GetOrganizationbyid(int id);

        Task AddOrganization(Organization organization);
    }
}
