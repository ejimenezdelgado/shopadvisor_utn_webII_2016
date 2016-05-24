using ShopAdvisor.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopAdvisor.Controllers
{
    public class LINQController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LINQ
        public async Task<ActionResult> Where()
        {
            var query = await db.Places.Where(item => item.latitud > 0).ToListAsync();

            return View(query);
        }

        // GET: Join
        public async Task<ActionResult> Join()
        {
            var query =
                await
               (from place in db.Places
               join comment in db.Comments
               on place.id equals comment.place.id
               select place).Where(x=>x.longitud>0).ToListAsync();

            return View(query);
        }
    }
}