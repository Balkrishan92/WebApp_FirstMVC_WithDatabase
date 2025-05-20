using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp_FirstMVC_WithDatabase.Data;
using WebApp_FirstMVC_WithDatabase.Models;

namespace WebApp_FirstMVC_WithDatabase.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            var employeeList = context.Employees.ToList();

            return View(employeeList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var employeeListInDb = context.Employees.Find(id);
            if (employeeListInDb == null) return HttpNotFound();
            return View(employeeListInDb);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            var employeeInDb = context.Employees.Find(employee.Id);
            if (employeeInDb == null) return HttpNotFound();
            employeeInDb.Name = employee.Name;
            employeeInDb.Address = employee.Address;
            employeeInDb.Salary = employee.Salary;
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Details(int id)
        {
            var employeFromDb = context.Employees.Find(id);
            if (employeFromDb == null) return HttpNotFound();

            return View(employeFromDb);
        }
        public ActionResult Delete(int id)
        {
            var employeFromDb = context.Employees.Find(id);
            if (employeFromDb == null) return HttpNotFound();
            return View(employeFromDb);
        }
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            if (employee == null) return HttpNotFound();
            var employeeInDb = context.Employees.Find(employee.Id);
            if (employeeInDb == null) return HttpNotFound();
            context.Employees.Remove(employeeInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
        public ActionResult Delete_Rec(int id)
        {
            var employeeInDb = context.Employees.Find(id);
            if (employeeInDb == null) return HttpNotFound();
            context.Employees.Remove(employeeInDb);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}