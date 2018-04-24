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
using System.Collections;
using AutoMapper;
using Schedule.Models.DTOs;
using Schedule.EF;

namespace Schedule.Controllers
{
    public class TeacherModelsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        private ScheduleContext db = new ScheduleContext();

        // GET: TeacherModels
        public async Task<ActionResult> Index()
        {
            //doesnt work properly, we dont save fields Position and Degree (just IDs) 
            //need to create new map for displaying 
            var teachers = unitOfWork.Teachers.GetAll();
            //var teachers = await db.TeacherModels.ToListAsync();
            List<TeacherDTO> teacherDTOs = new List<TeacherDTO>();
            foreach(TeacherModel teacher in teachers)
            {
                teacherDTOs.Add(
                     Mapper.Map<TeacherDTO>(teacher)
                );
            }
            return View(teacherDTOs);
            //return View(unitOfWork.Teachers.GetAll());
            //return View(await db.TeacherModels.ToListAsync());
        }

        // GET: TeacherModels/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = await db.TeacherModels.FindAsync(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            TeacherDTO teacherDTO = Mapper.Map<TeacherDTO>(teacherModel);
            ViewBag.Degree = teacherDTO.Degree;
            ViewBag.Position = teacherDTO.Position;
            return View(teacherModel);
        }

        // GET: TeacherModels/Create
        public ActionResult Create()
        {
            SelectList degrees = new SelectList(db.Degrees, "Id", "Name");
            ViewBag.Degrees = degrees;
            SelectList positions = new SelectList(db.Positions, "Id", "Name");
            ViewBag.Positions = positions;
            return View();
        }

        // POST: TeacherModels/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                teacherModel.Id = Guid.NewGuid();
                db.TeacherModels.Add(teacherModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(teacherModel);
        }

        // GET: TeacherModels/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = await db.TeacherModels.FindAsync(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            Degree selectedDegree = await db.Degrees.FindAsync(teacherModel.IdDegree);
            SelectList degrees = new SelectList(db.Degrees, "Id", "Name", selectedDegree);
            ViewBag.Degrees = degrees;

            PositionModel selectedPosition = await db.Positions.FindAsync(teacherModel.IdPosition);
            SelectList positions = new SelectList(db.Positions, "Id", "Name", selectedPosition);
            ViewBag.Positions = positions;

            return View(teacherModel);
        }

        // POST: TeacherModels/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,SecondName,Surname,IdDegree,IdPosition")] TeacherModel teacherModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(teacherModel);
        }

        // GET: TeacherModels/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherModel teacherModel = await db.TeacherModels.FindAsync(id);
            if (teacherModel == null)
            {
                return HttpNotFound();
            }
            return View(teacherModel);
        }

        // POST: TeacherModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            TeacherModel teacherModel = await db.TeacherModels.FindAsync(id);
            db.TeacherModels.Remove(teacherModel);
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
