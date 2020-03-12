using MVCFirstApp.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCSimpleApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDBContext db = new EmpDBContext();
        // GET: Employee

        public ActionResult Index()
        {
            var employees =  from e in db.Employees
                            orderby e.ID
                            select e;

            
            return View(employees);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        { 
            db.Employees.Add(emp);
                
                db.SaveChanges();
              
                return RedirectToAction("Index");
           
        }

        public ActionResult Edit(int id)
        {
            var employee = db.Employees.Single(m => m.ID == id);
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection post)
        {
            
            var employee = db.Employees.Single(m => m.ID == id);
          
            if (TryUpdateModel(employee))
                {

                employee.Name = post["Name"];
                employee.Age = Convert.ToInt32(post["Age"]);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(employee);
             
        }

        public ActionResult Delete(int id, FormCollection post)
        {

            var employee = db.Employees.Single(m => m.ID == id);
            
            if (TryUpdateModel(employee))
            {

                db.Employees.Remove(employee);
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

        }




    }
}