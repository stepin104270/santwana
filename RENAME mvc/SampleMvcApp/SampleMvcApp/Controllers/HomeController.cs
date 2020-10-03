using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleMvcApp.Models;

namespace SampleMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public string Greeting()
        {
            return "<h1>Hello World!!<h1>";
        }

        /*public Employee ShowMe()
        {
            return new Employee
            {
                EmployeeId = 104310,
                EmployeeName = "Sachin",
                EmployeeAddress = "Bangalore",
                EmployeeSalary = 100000
            };
        }

        public ViewResult ShowHtml()
        {
            var emp = new Employee
            {
                EmployeeId = 104310,
                EmployeeName = "Sachin",
                EmployeeAddress = "Bangalore",
                EmployeeSalary = 100000
            };

            return View(emp);
        }*/

        public ViewResult EmployeeDetails()
        {
            var context = new lttstrainingEntities();
            var model = context.Employees.ToArray();
            return View(model);
        } 

        public ViewResult Find(string id)
        {
            var empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            return View(model);
        }

        //ActionResult is the abstract base class of all action 

        [HttpPost]
        public ActionResult Find(Employee emp)
        {
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == emp.EmployeeId);
            model.EmployeeName = emp.EmployeeName;
            model.EmployeeAddress = emp.EmployeeAddress;
            model.EmployeeSalary = emp.EmployeeSalary;
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }

        public ViewResult NewEmployee()
        {
            var model = new Employee();
            return View(model);
        }

        [HttpPost]
        public ActionResult NewEmployee(Employee emp)
        {
            var context = new lttstrainingEntities();
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }

        public ViewResult Delete(string id)
        {
            var empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string id, string confirmButton)
        {
            int empId = int.Parse(id);
            var context = new lttstrainingEntities();
            var model = context.Employees.FirstOrDefault((e) => e.EmployeeId == empId);
            context.Employees.Remove(model);
            context.SaveChanges();
            return RedirectToAction("EmployeeDetails");
        }
    }
} 