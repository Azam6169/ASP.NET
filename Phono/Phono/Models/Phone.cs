using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;


namespace Phono.Models
{
    public class Phone
    {

        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PhoneName { get; set; }
        public Brand Brand { get; set; }
        public int BrandID { get; set; }
        [Required]
        public DateTime DateReleased { get; set; }
        [Required]
        public float ScreenSize { get; set; }
        public PhoneType PhoneType { get; set; }
        public byte PhoneTypeID { get; set; }
    }
}