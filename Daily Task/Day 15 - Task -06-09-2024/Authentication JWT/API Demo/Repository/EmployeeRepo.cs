using API_Demo.Interface;
using API_Demo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API_Demo.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly EmployeeOrgContext _context;

        public EmployeeRepo(EmployeeOrgContext context)
        {
            _context = context;
        }

        public async Task AddEmployee(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeee(int id)
        {
            Employee delvalues=await  _context.Employees.FirstOrDefaultAsync(e => e.empId == id)?? throw new NullReferenceException();
            if (delvalues != null)
            {
                _context.Entry(delvalues).State = EntityState.Deleted;
                // _context.Employees.Remove(delvalues);
                await _context.SaveChangesAsync();
            }
            
           
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
           return await _context.Employees.Include(e=>e.organization).ToListAsync();
        }

        public async Task<Employee> GetEmployeebyid(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.empId == id);
        }

        public async Task UpdateEmployee(Employee employee)
        {
           
                _context.Employees.Update(employee);

                await _context.SaveChangesAsync();
            
        }
    }
}
