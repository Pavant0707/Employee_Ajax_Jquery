using EmployeeAjax.Context;
using EmployeeAjax.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAjax.Controllers
{
    public class AjaxController : Controller
    {
        public readonly EmployeeContext context;

        public AjaxController(EmployeeContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public JsonResult EmployeeList()
        {
            var a = context.Employeedb.ToList();
            return new JsonResult(a);
        }

        
        public JsonResult AddEmployee(EntityEmployee entityEmployee)
        {
            
            var emp = new EntityEmployee()
            {
                Name = entityEmployee.Name,
                country = entityEmployee.country,
                city = entityEmployee.city,
                salary = entityEmployee.salary,
            };
            context.Employeedb.Add(emp);
            context.SaveChanges();
            return new JsonResult("Data is ");
        }
        public JsonResult Edit(int id)
        {
            var data = context.Employeedb.Where(e => e.Id== id).SingleOrDefault();
            return new JsonResult(data);
        }
        [HttpPost]
        public JsonResult Update(EntityEmployee employee)
        {
            context.Employeedb.Update(employee);
            context.SaveChanges();
            return new JsonResult("Record updated");
        }
        
        public JsonResult Delete(int id)
        {
            var data = context.Employeedb.Where(e => e.Id == id).SingleOrDefault();
            this.context.Employeedb.Remove(data);
            context.SaveChanges();
            return new JsonResult("Data Delted");
        }

    }
}
