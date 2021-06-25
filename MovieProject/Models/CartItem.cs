using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class CartItem
    {
        public Movie Movie { get; set; }
        public int Quantity { get; set; }


    }
}