using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidPlace.Models;

namespace VidPlace.ViewModels
{
    public class CustomerMediaViewModel
    {
        public Media media { get; set; }
        public List<Customer> customers { get; set; }
    }
}