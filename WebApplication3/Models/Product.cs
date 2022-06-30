using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Product
    {


        [Key]
        [ScaffoldColumn(false)]
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }

        public decimal Product_Price { get; set; }
        public string Company_Name { get; set; }
        public string Product_Description { get; set; }

    }
}
