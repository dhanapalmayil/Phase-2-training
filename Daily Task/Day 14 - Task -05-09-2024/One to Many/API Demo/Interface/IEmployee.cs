using API_Demo.Models;

namespace API_Demo.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeebyid(int id);


         Task AddEmployee(Employee employee);

         Task UpdateEmployee(Employee employee);

         Task DeleteEmployeee(int id);
    }
}
