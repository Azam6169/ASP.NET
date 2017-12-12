using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPlace.Models;

namespace VidPlace.ViewModels
{
    public class MediaFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public IEnumerable<MediaType> MediaTypes { get; set; }
        public Media Media { get; set; }


        public string Title
        {
            get
            {
                return Media.ID == 0 ? "New Media" : "Edit Media";
            }
        }

        public MediaFormViewModel()
        {
            Media = new Media();
            Media.ID = 0;
        }
    }
}