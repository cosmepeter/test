using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCFirstApp.Models;
using Newtonsoft.Json;

namespace MVCFirstApp.Controllers
{
    public class LoginController : Controller
    {
        private EmpDBContext db = new EmpDBContext();
        public ActionResult Login()
        { 
            return View();
        }
         
        [HttpPost]
        public ActionResult Login(FormCollection post)  //suppose to check if record exists in employee db or not
        { 
            string msg = "username doesn't exist or password incorrect";
            System.Diagnostics.Debug.WriteLine(post["Name"]);
            System.Diagnostics.Debug.WriteLine(post["Password"]);

            string username = post["Name"];
            var password = from e in db.Employees
                           where e.Name == username
                           select e.Password;
              
            var list = password.ToList();

            System.Diagnostics.Debug.WriteLine(list.Count);

            if (list.Count > 0 && list[0] == post["Password"] )
            {
                msg = ""; 
            }

            ViewBag.message = msg;

            if(msg == "") //login sucessful
            { 
                Session["Name"] = post["Name"];
                return RedirectToAction("../Order/OrderForm");
            }
            else
            {
                return View();
            }
              
        }


        [HttpPost]
        public ActionResult OrderForm(string category)
        {
            var products = (from p in db.Products
                            where p.category == category
                            select p);


            List<Product> list = products.ToList();


            string result = "";
            if (list == null)
            {

                return Json(result);
            }
            else
            {
                result = JsonConvert.SerializeObject(list);
                return Json(result);
            }

        }
    }
}