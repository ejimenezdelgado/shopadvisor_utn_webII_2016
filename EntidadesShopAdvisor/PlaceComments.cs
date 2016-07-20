using DataShopAdvisor.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesShopAdvisor
{
    public class PlaceComments
    {
        public Place Place { set; get; }

        public IEnumerable<Comment> Comments { set; get; }

    }
}
