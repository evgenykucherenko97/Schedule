using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schedule.Models;

namespace Schedule.Controllers
{
    public class PositionModelsController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: PositionModels
        public async Task<ActionResult> Index()
        {
            return View(await db.Positions.ToListAsync());
        }

        // GET: PositionModels/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = await db.Positions.FindAsync(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // GET: PositionModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PositionModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] PositionModel positionModel)
        {
            if (ModelState.IsValid)
            {
                positionModel.Id = Guid.NewGuid();
                db.Positions.Add(positionModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(positionModel);
        }

        // GET: PositionModels/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = await db.Positions.FindAsync(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // POST: PositionModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] PositionModel positionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(positionModel);
        }

        // GET: PositionModels/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = await db.Positions.FindAsync(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // POST: PositionModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PositionModel positionModel = await db.Positions.FindAsync(id);
            db.Positions.Remove(positionModel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
