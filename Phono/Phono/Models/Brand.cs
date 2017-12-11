using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Phono.Models
{
    public class Brand
    {

        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string BrandName { get; set; }
        [Required]
        [MaxLength(50)]
        public string CountryOfOrigin { get; set; }
    }
}