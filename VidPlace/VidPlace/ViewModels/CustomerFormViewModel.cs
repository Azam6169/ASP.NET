using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPlace.Models;

namespace VidPlace.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public List<Membership> MembershipTypes { get; set; }
    }
}