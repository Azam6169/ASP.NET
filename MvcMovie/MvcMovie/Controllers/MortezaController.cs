using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMovie.Controllers
{
    public class MortezaController : Controller
    {
        //
        // GET: /Morteza/
        public string testparam(string name, int numT= 23 )
        {
           return HttpUtility.HtmlEncode("سلام " + name +  "شماره ی  شما:  " + numT + "می باشد");
        }

	}
}