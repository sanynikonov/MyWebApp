using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public virtual List<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();
        }
    }
}