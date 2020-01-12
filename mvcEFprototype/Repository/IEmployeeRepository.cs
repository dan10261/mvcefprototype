using mvcEFprototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcEFprototype.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> GetEmployeesByDepartment(string Dept);
        Task<IEnumerable<Employee>> GetAllWithImages();
        
    }
}
