using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidPlace.Models
{
    public class Media
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Media Name")]
        public string name { get; set; }

        /*
         * To avoid the dateTime element to be pre-initialized
         * Make it required and add "?" to let be null
         * */
        [Required]
        [Display(Name="Release Date")]
        public DateTime? ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number is Stock")]
        [Range(1,20)]
        public int NumberInStock { get; set; }

        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name="Genre")]
        public byte GenreId { get; set; }

        
        public MediaType MediaType { get; set; }
        [Required]
        [Display(Name = "Media Type")]
        public byte MediaTypeId { get; set; }
    }
}