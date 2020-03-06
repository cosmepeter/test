using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFirstApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Registration
        public ActionResult LoginForm()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authentication(FormCollection post)
        {

            System.Diagnostics.Debug.WriteLine(post.Count);

            //handle authentication

            return View();
        }
    }
}