using DataShopAdvisor;
using DataShopAdvisor.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIShopAdvisor
{
    public class BIPlace
    {
        public async Task<List<Place>> GetAll()
        {
           ApplicationDbContext db = new ApplicationDbContext();
            return await db.Places.ToListAsync();
        }
    }
}
