using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcEFprototype.Models;
using mvcEFprototype.Service;
using System.IO;

namespace mvcEFprototype.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeService _employee_Service = null;
        public EmployeesController()
        {
            this._employee_Service = new EmployeeService();
        }
        public EmployeesController(EmployeeService Service)
        {
            this._employee_Service = Service;
        }

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            
            return View(await _employee_Service.GetAll());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee_Service.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/**[Bind(Include = "Id,FirstName,LastName,Age,Position,Office,Salary")]**/ Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    employee.UploadFile = binaryReader.ReadBytes(Request.Files[0].ContentLength); 
                    employee.UploadFilename = Request.Files[0].FileName;
                }
                _employee_Service.Insert(employee);
                _employee_Service.Save();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee_Service.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/**[Bind(Include = "Id,FirstName,LastName,Age,Position,Office,Salary")]***/ Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    if(Request.Files[0].ContentLength!=0 && Request.Files[0].FileName.Length != 0) 
                    {
                        employee.UploadFile = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                        employee.UploadFilename = Request.Files[0].FileName;
                    }
                    
                }
                _employee_Service.Update(employee);
                _employee_Service.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _employee_Service.GetById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _employee_Service.Delete(id);
            _employee_Service.Save();
            return RedirectToAction("Index");
        }

        public FileResult DownloadFile(int id)
        {
            return File(_employee_Service.GetById(id).UploadFile, System.Net.Mime.MediaTypeNames.Application.Octet, _employee_Service.GetById(id).UploadFilename);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _employee_Service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
