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

        [Required(ErrorMessage ="Please enter the customer's name")]
        [MaxLength(50)]
        public string Name { get; set; }

        //[MaxLength(255)]
        [MaxLength(255,ErrorMessage ="Address cannot exceed 255 characters")]
        public string Address { get; set; }

        public Boolean IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name ="Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfMemeber]
        public DateTime? Birthdate { get; set; }

        //override toString method
        public override string ToString()
        {
            return "Customer name:" + Name + " | Address: " + Address;
        }
    }
}