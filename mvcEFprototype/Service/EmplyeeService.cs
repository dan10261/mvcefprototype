using mvcEFprototype.Models;
using mvcEFprototype.Repository;
using System.Web.Mvc;

namespace mvcEFprototype.Service
{
    public class EmployeeService : EmployeeRepository,IEmployeeService
    {
        private IGenericRepository<Employee> _repository = null;
        private IEmployeeRepository _employee_repository = null;
        public EmployeeService()
        {
            this._employee_repository = new EmployeeRepository();
            this._repository = new GenericRepository<Employee>();
        }
        public EmployeeService(EmployeeRepository Repository)
        {
            this._employee_repository = Repository;
        }
        public EmployeeService(IGenericRepository<Employee> Repository)
        {
            this._repository = Repository;
        }

        public byte[] getFileBinaryById(int id)
        {
            Employee employee = _employee_repository.GetById(id);
            byte[] imageBinary = employee.UploadFile;
            return imageBinary;
        }
        // GET: Employees

    }
}