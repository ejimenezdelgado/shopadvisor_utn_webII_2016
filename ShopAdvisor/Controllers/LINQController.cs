using DataShopAdvisor;
using DataShopAdvisor.Modelos;
using EntidadesShopAdvisor;
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

        // GET: Join
        public async Task<ActionResult> OrderBy(int id)
        {
            int orderBy = 0;
            var query = new List<Place>();
            if (id == 1)
            {
                query = await db.Places.OrderBy(x=>x.name).ToListAsync();
            }
            else
            {
                query = await db.Places.OrderByDescending(x => x.name).ToListAsync();

            } 
            return View(query);
        }

        // GET: Join
        public async Task<ActionResult> Admin()
        {
            var promedio= await db.Places.AverageAsync(x=>x.id);
            var contador = await db.Places.CountAsync();
            var max = await db.Places.MaxAsync(x=>x.id);
            var min = await db.Places.MinAsync(x => x.id);
            var sum = await db.Places.SumAsync(x=>x.id);

            Admin oAdmin = new Admin();
            oAdmin.Promedio = promedio;
            oAdmin.Contador = contador;
            oAdmin.Max = max;
            oAdmin.Min = min;
            oAdmin.Sum = sum;

            return View(oAdmin);
        }

        // GET: Join
        public async Task<ActionResult> Partition()
        {
            var skip = await db.Places.OrderBy(x => x.id).Skip(1).ToListAsync();
            var take = await db.Places.OrderBy(x => x.id).Take(2).ToListAsync();
          //  var skipWhile = await db.Places.SkipWhile(x => x.longitud>0).ToListAsync();
          //  var takeWhile = await db.Places.TakeWhile(x => x.longitud > 0).ToListAsync();

            Partition oPartition = new Partition();
            oPartition.Skip = skip;
            oPartition.Take = take;
            oPartition.SkipWhile = new List<Place>();
            oPartition.TakeWhile = new List<Place>();

            return View(oPartition);
        }
        
    }
}