using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ApartmentsManger.Controllers
{
    public class RoomController : Controller
    {
        private readonly ModelContainer db = new ModelContainer();
        ~RoomController()
        {
            if (db != null)
            {
                db.Dispose();
            }
        }
        // GET: Room
        public ActionResult Index()
        {
            return View(db.Rooms);
        }

        // GET: Room/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms
                //.Include(r => r.UploadedFileID)
                .SingleOrDefault(r => r.IDRoom == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pictures = new SelectList(GetPictures(), "IDUploadedFile", "IDUploadedFile");
            return View(room);
        }

        // GET: Room/Create
        public ActionResult Create()
        {
            ViewBag.ApartmentsList = new SelectList(GetList(), "IDApartment", "IDApartment");
            ViewBag.Pictures = new SelectList(GetPictures(), "IDUploadedFile", "Name");
            return View();
        }

        // POST: Room/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = nameof(Room.Number)+","+ nameof(Room.Capacity)+","+ nameof(Room.ApartmentIDApartment)+","+ nameof(Room.UploadedFileID))] 
        Room room)
        {
            if (ModelState.IsValid)
            {

                db.Rooms.Add(room);
                db.SaveChanges();
            }
             return RedirectToAction("Index");
            
        }

        // GET: Room/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms
                //.Include(r => r.UploadedFileID)
                .SingleOrDefault(r => r.IDRoom == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApartmentsList = new SelectList(GetList(), "IDApartment", "IDApartment");
            ViewBag.Pictures = new SelectList(GetPictures(), "IDUploadedFile", "Name");
            return View(room);
        }

        // POST: Room/Edit/5
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditConfirmed(int id)
        {
            Room roomToUpdate = db.Rooms.Find(id);
            if (TryUpdateModel(roomToUpdate, "", new string[] {nameof(Room.Number), nameof(Room.Capacity), nameof(Room.ApartmentIDApartment), nameof(Room.UploadedFileID) }))
            {
                db.Entry(roomToUpdate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            
            return View(roomToUpdate);
        }

        // GET: Room/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Room room = db.Rooms
                //.Include(r => r.UploadedFileID)
                .SingleOrDefault(r => r.IDRoom == id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pictures = new SelectList(GetPictures(), "IDUploadedFile", "Name");
            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Rooms.Remove(db.Rooms.Find(id));
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private List<Apartment> GetList()
        {
            var list = new List<Apartment>();
            list.AddRange(db.Apartments);
            return list;
        }

        private List<UploadedFile> GetPictures()  //tu bi trebala jos poslati id od selektiranog apartmana i da se prikazu samo njegove slike, ali neznam to bez javascripta
        {
            var list = new List<UploadedFile>();
            db.Apartments.ToList().ForEach(a => list.AddRange(a.UploadedFiles));
            return list;
        }
    }
}
