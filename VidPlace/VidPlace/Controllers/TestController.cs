using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPlace.Models;

namespace VidPlace.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        // Get getString 
        public string getString()
        {
            return "Hello World, Welcome to MVC";
        }

        // Get Getcustomer

        public Customer Getcustomer()
        {
            Customer c = new Customer();
            c.Name = "MJ Hadi";
            c.Address = "3488 Cote Des Neiges";
            return c;
            
        }        

        // Getview
        public ActionResult GetView()
        {
            return View("MyView");
        }

        // Getview
        public ActionResult GetDeveloper()
        {
            return View("DeveloperInfo");
        }      


    }
}