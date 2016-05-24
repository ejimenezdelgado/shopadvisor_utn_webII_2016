using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopAdvisor.Models
{
    public class Comment
    {
        [Key]
        public int id { set; get; }

        public Place place { set; get; }

        public string comment { set; get; }
    }
}