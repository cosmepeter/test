using MVCFirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MVCFirstApp.Class;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;



using System.Web.Script.Serialization;
using System.Net;


namespace MVCFirstApp.Controllers
{
    public class LearnDBController : Controller
    {

        public ActionResult Index()
        {
             Entities entites = new Entities();
            return View(from disc_name in entites.tb_discount.Take(5)
                        select disc_name);
         
        }



    }
}