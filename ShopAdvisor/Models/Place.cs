using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopAdvisor.Models
{
    public class Place
    {
        [Key]
        public int id { set; get; }
        [Required]
        public string name { set; get; }
        [Required]
        public double latitud { set; get; }
        [Required]
        public double longitud { set; get; }
    }
}