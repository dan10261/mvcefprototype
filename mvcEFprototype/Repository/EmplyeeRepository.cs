using mvcEFprototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace mvcEFprototype.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployeesByDepartment(string Office)
        {
            return _context.Employees.Where(e=>e.Office==Office).ToList();
        }
        public async Task<IEnumerable<Employee>> GetAllWithImages()
        {

            return await table.ToListAsync();
        }

    }
}