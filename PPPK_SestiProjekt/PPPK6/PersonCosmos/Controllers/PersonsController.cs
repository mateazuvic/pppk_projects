using PersonCosmos.Dao;
using PersonCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PersonCosmos.Controllers
{
    public class PersonsController : Controller
    {
        private static readonly ICosmosDbService<Person> service = CosmosDbServiceProvider.CosmosDbService;

        // GET: Persons
        public async Task<ActionResult> Index()
        {
            return View(await service.GetAllAsync("SELECT * FROM Person"));
        }

        // GET: Persons/Details/5
        public async Task<ActionResult> Details(string id) => await ShowObject(id);


        // GET: Persons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Persons/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = nameof(Person.Id) + "," + nameof(Person.FirstName) + "," + nameof(Person.LastName) + "," + nameof(Person.Age) + "," + nameof(Person.IsMarried))] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Persons/Edit/5
        public async Task<ActionResult> Edit(string id) => await ShowObject(id);

        private async Task<ActionResult> ShowObject(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var item = await service.GetOneAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Persons/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = nameof(Person.Id) + "," + nameof(Person.FirstName) + "," + nameof(Person.LastName) + "," + nameof(Person.Age) + "," + nameof(Person.IsMarried))] Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdateAsync(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        // GET: Persons/Delete/5
        public async Task<ActionResult> Delete(string id) => await ShowObject(id);


        // POST: Persons/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include = nameof(Person.Id) + "," + nameof(Person.FirstName) + "," + nameof(Person.LastName) + "," + nameof(Person.Age) + "," + nameof(Person.IsMarried))] Person person)
        {
            await service.DeleteAsync(person);
            return RedirectToAction("Index");
        }
    }
}
