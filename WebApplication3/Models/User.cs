using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {


        [Key]
        [ScaffoldColumn(false)]
        public int User_Id { get; set; }
        public string User_FullName { get; set; }

        public decimal EmailId { get; set; }
        public int Password { get; set; }
        public int RoleId { get; set; }

    }
}
