using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidPlace.Models
{
    public class Customer
    {
        public int ID { get; set; }


        [Required][MaxLength(50)]

        public string Name { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }

        public Boolean IsSunscribedToNewsLetter { get; set; }

        public DateTime? Birthdate { get; set; }


        //new prperty voer here
        //new property over here
        public Membership Membership { get; set; }


        [Display(Name="Membership Type")]
        public byte MembershipId { get; set; }

        //override toString Method
        public override string ToString()
        {
            return "Customer Name: " + Name + " | Address: " + Address;
        }
        
    }
}