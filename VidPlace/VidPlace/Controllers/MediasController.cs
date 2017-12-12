using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidPlace.Models;
using VidPlace.ViewModels;
using System.Data.Entity;
using PagedList;

namespace VidPlace.Controllers
{
    public class MediasController : Controller
    {
        //Class variables
        private ApplicationDbContext _context;

        public MediasController()
        {
            _context = new ApplicationDbContext();
        }

        
        //exercise 1 - slide set (2)
        public ActionResult Index(string searchString, string sortOrder, string currentFilter, int? page)
        {
            string view = "IndexReadOnly";
            if (User.IsInRole(RoleNames.CanManageMedia))
                view = "Index";                

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParameter = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.GenreSortParameter = sortOrder == "Genre" ? "Genra_desc" : "Genre";

            if (searchString == null)
                searchString = currentFilter;
            else
                page = 1;

            ViewBag.CurrentFilter = searchString;
            //  var medias = getMedias();
            var medias = _context.Medias.Include(c => c.Genre);

            if(!String.IsNullOrEmpty(searchString))
            {
                medias = medias.Where(m => m.name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    medias = medias.OrderByDescending(m => m.name);
                    break;
                case "Genre":
                    medias = medias.OrderBy(m => m.Genre.Name);
                    break;
                case "Genra_desc":
                    medias = medias.OrderByDescending(m => m.Genre.Name);
                    break;
                default:
                    medias = medias.OrderBy(m => m.name);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(view,medias.ToPagedList(pageNumber, pageSize));

            //return View(medias.ToList());
        }

        //Detail action to display the media detail
        //GET: Media/Details/1
        public ActionResult Details(int id)
        {
            var media = _context.Medias.Include(m => m.Genre).Include(n => n.MediaType).
                SingleOrDefault(c => c.ID == id);

            if (media == null)
                return HttpNotFound();

            return View(media);
        }


        //GET : Medias/New
        [Authorize(Roles = RoleNames.CanManageMedia)]
        public ActionResult New()
        {
            var viewModel = new MediaFormViewModel()
            {
                Genres = _context.Genres.ToList(),
                MediaTypes = _context.MediaTypes.ToList()
            };

            return View("MediaForm", viewModel);
        }

        //POST : Medias/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleNames.CanManageMedia)]
        public ActionResult Save(Media media)
        {
            //Server side validation - start
            if (!ModelState.IsValid)
            {
                var viewModel = new MediaFormViewModel()
                {
                    Media = media,
                    Genres = _context.Genres.ToList(),
                    MediaTypes = _context.MediaTypes.ToList()
                };

                return View("MediaForm", viewModel);
            }
            //**********Server side validation - end *********
            if (media.ID == 0)
            {
                media.DateAdded = DateTime.Now;
                _context.Medias.Add(media);
            }
            else
            {
                var mediaInDB = _context.Medias.Single(c => c.ID == media.ID);

                mediaInDB.name = media.name;
                mediaInDB.GenreId = media.GenreId;
                mediaInDB.MediaTypeId = media.MediaTypeId;
                mediaInDB.NumberInStock = media.NumberInStock;
                mediaInDB.ReleasedDate = media.ReleasedDate;


            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Medias");
        }

        //GET : Medias/Edit
        [Authorize(Roles = RoleNames.CanManageMedia)]
        public ActionResult Edit(int id)
        {
            var mediaInDB = _context.Medias.SingleOrDefault(c => c.ID == id);

            if (mediaInDB == null)
                return HttpNotFound();

            var viewModel = new MediaFormViewModel()
            {
                Media = mediaInDB,
                Genres = _context.Genres.ToList(),
                MediaTypes = _context.MediaTypes.ToList()
            };

            return View("MediaForm", viewModel);
        }


        //Test Actions******************************************************
        // GET: Medias
        public ActionResult Random()
        {
            var media = new Media();
            media.name = "Jurasic Park";
            media.ID = 123;
            return View(media);
        }

        // GET: Medias
        public ActionResult RandomViewData()
        {
            var media = new Media();
            media.name = "Inception";
            media.ID = 111;

            ViewData["mediaObject"] = media;
            ViewBag.mediaObject = media;
            return View();
        }



        //
        public ActionResult ActionResultDemo()
        {
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index","Home");
            //return RedirectToAction("GetCustomer", "test");
            //return RedirectToAction("Index","Home", new { page = 1, sortBy ="name"});
            return RedirectToAction("Random", "Medias", new { userName = "alex123"});
        }

        /*
        public ActionResult edit(int ID)
        {
            return Content("Provided ID = " + ID);
        }*/

        //Temp method to creat dummy medias
        private IEnumerable<Media> getMedias()
        {
            return new List<Media>
            {
                new Media{ID = 1 , name= "Mummy 1"},
                new Media{ID = 2 , name = "Mummy 2"}
            };
        }


        //Part A
        /*public ActionResult index(int pageIndex, string sortBy)
        {
            return Content("Page Number = " + pageIndex + " Sort By: " + sortBy);
        }*/

        /*Part B:
         * int cannot be null (exception: non-nunlable)
         * to make an int parameter to be optional add the "?"
         * 
         * */
        /*[Route("medias/index/{pageIndex:range(1,100)}/{sortBy:maxlength(3)}")]
        public ActionResult index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "NAM";
            return Content("Page Number = " + pageIndex + " Sort By: "+ sortBy);
        }*/

        public ActionResult userName(string first, string last)
        {
            return Content("First Name = " + first + " Last Name = " + last);
        }

        //released action with a attribute route
        [Route("medias/released/{year:range(1900,2030)}/{month:range(1,12)}")]
        public ActionResult released(int year, int month)
        {
            return Content("Year = " + year + " Month= " + month);
        }

        public ActionResult listCustomers()
        {
            var tempMedia = new Media() { name = "Pulp Fiction" };
            var tempCustomers = new List<Customer>
            {
                new Customer(){Name = "Berry Alan"},
                new Customer(){Name = "Jerry Tom"},
                new Customer(){Name = "Andy Alex"}
            };
            var emptyCustomerList = new List<Customer>();

            var viewModelObject = new customerMediaViewModel()
            {
                media = tempMedia,
                //customers = tempCustomers
                customers = emptyCustomerList
            };

            return View(viewModelObject);
        }
    }


}