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

        //Get getString
        public string getString()
        {
            return "Hello World, Welcome to MVC";
        }

        //Get customer
        public Customer GetCustomer()
        {
            Customer c = new Customer();
            c.Name = "Thomas Adinson";
            c.Address = "Montreal,QC, Canada";
            return c;

        }

        //getview
        public ActionResult GetView()
        {
            return View("ViewTest");
        }

        public ActionResult GetDeveloper()
        {
            return View("Developer");
        }

        public ActionResult getLayoutView()
        {
            return View("ViewLayOut");
        }


    }

    
}