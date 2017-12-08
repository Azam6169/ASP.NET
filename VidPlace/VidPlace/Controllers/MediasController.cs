using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPlace.Models;
using VidPlace.ViewModels;
using System.Data.Entity;


namespace VidPlace.Controllers
{
    public class MediasController : Controller
    {

        //class varables
        private ApplicationDbContext _context;

        //class constructor to initialize
        public MediasController()
        {
            _context = new ApplicationDbContext();


        }

        //excersice1 slide set 2
        public ActionResult Index()
        {
            
            var medias = _context.Medias.Include(c => c.Genre).ToList();//igger coding

            return View(medias);
        }


        //detailActionto display media details
        


        public ActionResult Details(int id)
        {
            //var customers = getCustomers().SingleOrDefault(c => c.ID == id);
            var media = _context.Medias.Include(m => m.Genre).Include(n => n.MediaType).
                SingleOrDefault(c => c.ID == id);//now from the database not from the dummy 


            if (media == null)

                return HttpNotFound();
            return View(media);

        }

        //
        private IEnumerable<Media> GetMedias()
        {
            return new List<Media>
            {
               new Media{ ID=1,Name="Mummy 1"},
               new Media{ ID=2,Name="Mummy 2"},
            };
        }


        // GET: Medias
        public ActionResult Random()
        {
            var media = new Media();
            media.Name = "Jurasic Park";

            return View(media);
        }

        // GET: Medias
        public ActionResult RandomViewData()
        {
            var media = new Media();
            media.Name = "Inception";
            media.ID = 123;

            ViewData["mediaObject"] = media;
            return View();
        }

        //
        public ActionResult ActionResultDemo()
        {
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home");
            //return RedirectToAction("GetCustomer", "test");
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
            return RedirectToAction("Random", "Medias", new { userName = "alex123" });

        }

        public ActionResult Edit(int id)
        {
            return Content("Provide ID = " + id);
        }

        // Part A
        //public ActionResult index(int pageIndex, string sortBy)
        //{
        //    return Content("Page number = " + pageIndex + " Sort by: " + sortBy);
        //}

        // Part B
        // int cannot be null ( exception: non-nunable)
        // to make an int parameter to be optional add the "?"
        [Route("medias/Index/{pageIndex:range(1,100)}/{sortBy:maxlength(3)}")]
        public ActionResult index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content("Page number = " + pageIndex + " Sort by: " + sortBy);
        }

        public ActionResult userName(string first, string last)
        {
            return Content("FistName = " + first + " LastName: " + last);
        }

        // released action with a attribute route
        // Fix Ii
        [Route("medias/released/{Year:range(1900,2017)}/{Month:range(1,12)}")]
        //[Route("medias/released/{Year}/{Month}")]
        public ActionResult released(int Year, int Month)
        {
            return Content("Year = " + Year + " Month: " + Month);
        }

        public ActionResult listCustomer() {
            var tempMedia = new Media() { Name = "pulp fiction" };
            var tempCustomers = new List<Customer> {
                new Customer(){ Name="berrry allan"},
                new Customer(){ Name="tom jery"},
                new Customer(){ Name="roberto rubio"}

            };
            var viewModelObject = new CustomerMediaViewModel()
            {
                media = tempMedia,
                customers = tempCustomers

            };
            
            return View(viewModelObject);

        }

    }
}