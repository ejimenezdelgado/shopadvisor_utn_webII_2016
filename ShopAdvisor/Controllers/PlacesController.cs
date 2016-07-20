using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DataShopAdvisor;
using DataShopAdvisor.Modelos;
using BIShopAdvisor;
using EntidadesShopAdvisor;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ShopAdvisor.Controllers
{
    public class PlacesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Places
        public async Task<ActionResult> Index()
        {
            if (Request.IsAjaxRequest())
            {
                 return Json(await new BIPlace().GetAll(),
                     JsonRequestBehavior.AllowGet);
            }
            else
                return View(await new BIPlace().GetAll());
        }

        // GET: Places/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlaceComments oPlaceComments = new PlaceComments();
            Place place = await db.Places.FindAsync(id);
            IEnumerable<Comment> comments = await db.Comments.Where(x=>x.place.id==id).ToListAsync();
            oPlaceComments.Place = place;
            oPlaceComments.Comments = comments;
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(oPlaceComments);
        }

        // GET: Places/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Places/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,latitud,longitud")]
        Place place, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                var filename = image.FileName;
                var filePathOriginal = Server.MapPath("/content/uploads/places");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                place.image_path = @"/content/uploads/places/" + filename;
                db.Places.Add(place);
                await db.SaveChangesAsync();                
                image.SaveAs(savedFileName);
                return RedirectToAction("Index");
            }

            return View(place);
        }

        // GET: Places/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,latitud,longitud")] Place place)
        {
            if (ModelState.IsValid)
            {
                db.Entry(place).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(place);
        }

        // GET: Places/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Place place = await db.Places.FindAsync(id);
            if (place == null)
            {
                return HttpNotFound();
            }
            return View(place);
        }

        // POST: Places/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Place place = await db.Places.FindAsync(id);
            db.Places.Remove(place);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("CreateCommentPlace")]
        public async Task<ActionResult> CreateCommentPlace(FormCollection data)
        {
            Comment oComment = new Comment();
            oComment.comment = data["comment"];
            Place oPlace = await db.Places.FindAsync(Convert.ToInt32(data["place"]));
            oComment.place = oPlace;
            db.Comments.Add(oComment);
            await db.SaveChangesAsync();
            IEnumerable<Comment> comments = await db.Comments.Where(x => x.place.id == oComment.place.id).ToListAsync();
            PlaceComments oPlaceComments = new PlaceComments();
            oPlaceComments.Place = oPlace;
            oPlaceComments.Comments = comments;
            return PartialView("PartialViewComment", oPlaceComments);
        }

        [HttpPost, ActionName("DeleteCommentPlace")]
        public async Task<ActionResult> DeleteCommentPlace(int place, int comment)
        {
            Comment oComment = await db.Comments.FindAsync(comment);
            db.Comments.Remove(oComment);
            await db.SaveChangesAsync();
            PlaceComments oPlaceComments = new PlaceComments();
            Place oPlace = await db.Places.FindAsync(place);
            IEnumerable<Comment> comments = await db.Comments.Where(x => x.place.id == place).ToListAsync();
            oPlaceComments.Place = oPlace;
            oPlaceComments.Comments = comments;
            return PartialView("PartialViewComment", oPlaceComments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
