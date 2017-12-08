using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPlace.Models;
using System.Data.Entity;
using VidPlace.ViewModels;

namespace VidPlace.Controllers
{

    

    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        //class constructor to initialize
        public CustomersController()
        {
            _context = new ApplicationDbContext();


        }

        // GET: Customers
        public ActionResult Random()
        {
            var cust = new Customer()
            { Name = "MJ Hadi", Address = "3488 Cote Des Neiges" };
            return View(cust);
        }
        //execise one slide 2
        public ActionResult Index()
        {
            //var customers = getCustomers();
            var customers = _context.Customers.Include(c => c.Membership).ToList();//brings oreing data tha is related to my code, iger coding
            return View(customers);
        }
        //provide dumm data
        private IEnumerable<Customer> getCustomers()
        {
            return new List<Customer>(){
            new Customer{ID=1, Name="Juan smiro"},
            new Customer{ID=2, Name="jose perez"},
            };
        }

        //slide2
        public ActionResult Details(int id)
        {
            //var customers = getCustomers().SingleOrDefault(c => c.ID == id);
            var customers = _context.Customers.Include(c => c.Membership).SingleOrDefault(c=> c.ID == id);//now from the database not from the dummy 


            if (customers == null)
            
                return HttpNotFound();
                return View(customers);
            
        }


        //return a view form
        public ActionResult New()
        {
            
            var membershipTypes = _context.membershipTypes.ToList();
            //obejc f my view model
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);//to access it from my drop down menu
            
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {


            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else {
                var customerinDB = _context.Customers.Single(c=>c.ID==customer.ID);


                //TryUpdateModel(customerinDB);
                //default for mayor secrity code
                //manual way to do it
                customerinDB.Name = customer.Name;
                customerinDB.Address= customer.Address;
                customerinDB.MembershipId = customer.MembershipId;
                customerinDB.IsSunscribedToNewsLetter = customer.IsSunscribedToNewsLetter;
            }

            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");

        }
        //edit action 
        public ActionResult Edit(int id)
        {
            var customerinDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerinDb == null) 
                return HttpNotFound();
            

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customerinDb,
                MembershipTypes = _context.membershipTypes.ToList()
            };

            
            return View("CustomerForm", viewModel);
            
        }

    }

}