using mvcEFprototype.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace mvcEFprototype.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Employee GetById(object id);
        void Insert(Employee obj);
        void Update(Employee obj);
        void Delete(object id);
        void Save();
        void Dispose();
        IEnumerable<Employee> GetEmployeesByDepartment(string Dept);
        byte[] getFileBinaryById(int id);
    }
}
