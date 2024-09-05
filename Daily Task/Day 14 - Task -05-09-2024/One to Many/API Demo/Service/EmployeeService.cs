using API_Demo.Interface;
using API_Demo.Models;

namespace API_Demo.Service
{
    public class EmployeeService
    {

        private readonly IEmployee _emprepo;

        public EmployeeService(IEmployee emprepo)

        {
            _emprepo = emprepo;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _emprepo.GetAllEmployees();
        }

        public async Task<Employee> GetEmployeebyid(int id)
        {
            return await _emprepo.GetEmployeebyid(id);
        }

        public async Task  addemployee(Employee employee)
        {
            await _emprepo.AddEmployee(employee);
            
        }
        public async Task updateemployee(Employee employee)
        {
            await _emprepo.UpdateEmployee(employee);
        }

        public async Task DeleteEmployees(int id)
        {
            await _emprepo.DeleteEmployeee(id);
        }


    }
}
