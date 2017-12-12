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
    //
    
    public class CustomersController : Controller
    {
        //Class variables
        private ApplicationDbContext _context;

        //Class contructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
               

        //Execise (1) - MVC slide set 2
        public ActionResult Index()
        {
            //var customers = getCustomers();
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
                
        //Execise (1) - MVC slide set 2
        public ActionResult Details(int id)
        {
            //var customer = getCustomers().SingleOrDefault(c => c.ID == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //Action from Building Form section
        public ActionResult New()
        {
            //var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormModelView()
            {
                Customer = new Customer(),
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        //Adding a new customer -  http post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //Server side validation - start
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormModelView()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            //**********Server side validation - end *********
            if(customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerinDB = _context.Customers.Single(c => c.ID == customer.ID);
                /*
                 * TryUpdateModel(customerinDB);
                 * this is defualt method to update used by MS
                 * It has major security flow.
                 * 
                 * */
                 //This manual way to it.
                customerinDB.Name = customer.Name;
                customerinDB.Address = customer.Address;
                customerinDB.MembershipTypeId = customer.MembershipTypeId;
                customerinDB.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerinDB.Birthdate = customer.Birthdate;

            }
            
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        //Edit action to edit a customer
        public ActionResult Edit(int id)
        {
            var customerinDB = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customerinDB == null)
                return HttpNotFound();

            var viewModel = new CustomerFormModelView()
            {
                Customer = customerinDB,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", viewModel);
        }













        //Temp method to provide dummy data
        private IEnumerable<Customer> getCustomers()
        {
            return new List<Customer>
            {
                new Customer {ID = 1, Name = "John Smith"},
                new Customer {ID = 2, Name = "Alice Wonderland"}

            };
        }
        // GET: Customers
        public ActionResult getCustomer()
        {
            var customer = new Customer()
            { Name = "Alex ABC", Address = "Toronto, Canada", ID = 777 };
            return View(customer);
        }

    }
}