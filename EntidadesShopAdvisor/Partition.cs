using DataShopAdvisor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntidadesShopAdvisor
{
    public class Partition
    {
        public IEnumerable<Place> Skip { get; set; }
        public IEnumerable<Place> SkipWhile { get; set; }
        public IEnumerable<Place> Take { get; set; }
        public IEnumerable<Place> TakeWhile { get; set; }
    }
}