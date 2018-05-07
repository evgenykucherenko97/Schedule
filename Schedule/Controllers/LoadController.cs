using Schedule.Classes;
using Schedule.COM;
using Schedule.Models;
using Schedule.Models.DTOs;
using Schedule.Models.HelpingModels;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Schedule.Controllers
{
    public class LoadController : Controller
    {
        private ScheduleContext db = new ScheduleContext();

        // GET: File
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            LoadsViewModel model = new LoadsViewModel()
            {
                DayLoadRegulars = await db.DayLoadRegulars.ToListAsync(),
                ZOLoadRegulars = await db.ZOLoadRegulars.ToListAsync()
            };
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateLoad()
        {
            SelectList files = new SelectList(db.Files, "Path", "Path");
            ViewBag.Files = files;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> CreateLoad(LoadHelperModel model)
        {
            if (model == null)
            {
                return HttpNotFound();
            }
            
            dynamic list;
            string file_path = Server.MapPath("~/Files/" + model.Filepath);
            if (model.LoadKind == LoadKind.Day)
            {
                list = Import_COM.Import_Excel(file_path);
                List<RegularStudyDayLoadSubjects> loads = LoadConverter.FromDTOtoListOfDayRegularLoads(list[2]);
                foreach(var load in loads)
                {
                    foreach(var group in load.Groups)
                    {
                        db.Groups.Attach(group);
                    }
                }
                DayLoadRegular dayLoadRegular = new DayLoadRegular()
                {
                    LoadName = model.Name,
                    StudentKind = model.StudentKind,
                    LoadKind = model.LoadKind,
                    regularStudyDayLoadSubjects = loads
                };
                for (int i = 0; i<dayLoadRegular.regularStudyDayLoadSubjects.Count; i++)
                {
                    dayLoadRegular.regularStudyDayLoadSubjects.ElementAt(i).LoadId = dayLoadRegular.Id;
                }

                db.DayLoadRegulars.Add(dayLoadRegular);
                await db.SaveChangesAsync();
                return RedirectToAction("CreatedLoad", new { id = dayLoadRegular.Id });
            }
            else if (model.LoadKind == LoadKind.ZO)
            {
                list = Import_COM.Import_Excel_Zaoch(file_path);
                RegularStudyZOLoadSubjects load = LoadConverter.FromDTOtoZORegularLoad(list[0]);
                List<RegularStudyZOLoadSubjects> loads = new List<RegularStudyZOLoadSubjects>();
                loads.Add(load);
                foreach (var group in load.Groups)
                {
                    db.Groups.Attach(group);
                }
                ZOLoadRegular zoLoadRegular = new ZOLoadRegular()
                {
                    LoadName = model.Name,
                    StudentKind = model.StudentKind,
                    LoadKind = model.LoadKind,
                    regularStudyZOLoadSubjects = loads
                };

                for (int i = 0; i < zoLoadRegular.regularStudyZOLoadSubjects.Count; i++)
                {
                    zoLoadRegular.regularStudyZOLoadSubjects.ElementAt(i).LoadId = zoLoadRegular.Id;
                }
                db.ZOLoadRegulars.Add(zoLoadRegular);
                await db.SaveChangesAsync();
                db.SaveChanges();
                return RedirectToAction("CreatedLoadZO", new { id = zoLoadRegular.Id });
            }
            else
            {
                list = null;
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult CreatedLoad(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            DayLoadRegular load = db.DayLoadRegulars.Find(id);
            if (load == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.LoadName = load.LoadName;
            switch (load.LoadKind)
            {
                case LoadKind.Day: ViewBag.LoadKind = "Дневная"; break;
                case LoadKind.ZO: ViewBag.LoadKind = "Заочная"; break;
            }

            List<RegularStudyDayLoadSubjects> list = db.RegularStudyDayLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (list == null)
            {                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);   
            }
            List<DayLoadDTO> loadsDTO = new List<DayLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.DayLoadDTO(loadReg));
            }
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Name");
            return View(loadsDTO);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreatedLoad(List<DayLoadDTO> model)
        {
            Guid? idLoad = null;
            if (model == null)
            {
                return HttpNotFound();
            }
            foreach (var item in model)
            {
                RegularStudyDayLoadSubjects load = db.RegularStudyDayLoadSubjects.Where(t => t.Id == item.Id).FirstOrDefault();
                idLoad = load.LoadId;
                load.Teacher = db.TeacherModels.Where(t => t.Id == item.TeacherId).FirstOrDefault();
                db.Entry(load).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DoneLoad", new { id = idLoad });
        }

        [Authorize]
        public ActionResult DoneLoad(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            DayLoadRegular load = db.DayLoadRegulars.Find(id);
            if (load == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.LoadName = load.LoadName;
            ViewBag.Id = load.Id;
            switch (load.LoadKind)
            {
                case LoadKind.Day: ViewBag.LoadKind = "Дневная"; break;
                case LoadKind.ZO: ViewBag.LoadKind = "Заочная"; break;
            }

            List<RegularStudyDayLoadSubjects> list = db.RegularStudyDayLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<DayLoadDTO> loadsDTO = new List<DayLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.DayLoadDTO(loadReg));
            }
            //ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Name");
            return View(loadsDTO);
        }

        [Authorize(Roles = "admin")]
        public ActionResult CreatedLoadZO(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ZOLoadRegular load = db.ZOLoadRegulars.Find(id);
            if (load == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.LoadName = load.LoadName;
            switch (load.LoadKind)
            {
                case LoadKind.Day: ViewBag.LoadKind = "Дневная"; break;
                case LoadKind.ZO: ViewBag.LoadKind = "Заочная"; break;
            }

            List<RegularStudyZOLoadSubjects> list = db.RegularStudyZOLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ZOLoadDTO> loadsDTO = new List<ZOLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.ZOLoadDTO(loadReg));
            }
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Name");
            return View(loadsDTO);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult CreatedLoadZO(List<ZOLoadDTO> model)
        {
            Guid? idLoad = null;
            if (model == null)
            {
                return HttpNotFound();
            }
            foreach (var item in model)
            {
                RegularStudyZOLoadSubjects load = db.RegularStudyZOLoadSubjects.Where(t => t.Id == item.Id).FirstOrDefault();
                idLoad = load.LoadId;
                load.Teacher = db.TeacherModels.Where(t => t.Id == item.TeacherId).FirstOrDefault();
                db.Entry(load).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("DoneLoadZO", new { id = idLoad });
        }

        [Authorize]
        public ActionResult DoneLoadZO(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ZOLoadRegular load = db.ZOLoadRegulars.Find(id);
            if (load == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.LoadName = load.LoadName;
            ViewBag.Id = load.Id;
            switch (load.LoadKind)
            {
                case LoadKind.Day: ViewBag.LoadKind = "Дневная"; break;
                case LoadKind.ZO: ViewBag.LoadKind = "Заочная"; break;
            }

            List<RegularStudyZOLoadSubjects> list = db.RegularStudyZOLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ZOLoadDTO> loadsDTO = new List<ZOLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.ZOLoadDTO(loadReg));
            }
            //ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Name");
            return View(loadsDTO);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dynamic load;
            load = db.DayLoadRegulars.Find(id);
            if (load != null)
            {
                return RedirectToAction("DeleteDay", new { id = load.Id });
            }
            else
            {
                load = db.ZOLoadRegulars.Find(id);
                if (load != null)
                {
                    return RedirectToAction("DeleteZO", new { id = load.Id });
                }
                else
                {
                    return HttpNotFound();
                }
            }            
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteDay(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.DayLoadRegulars.Find(id);
            if (load != null)
            {
                return View(load);
            }
            else
            {                
                return HttpNotFound();                
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult DeleteZO(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.ZOLoadRegulars.Find(id);
            if (load != null)
            {
                return View(load);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ActionName("DeleteDay")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteDayConfirmed(Guid id)
        {
            //add subject deleting!!!!!
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.DayLoadRegulars.Find(id);
            if (load != null)
            {
                List<RegularStudyDayLoadSubjects> loads = db.RegularStudyDayLoadSubjects.Where(p => p.LoadId == id).ToList();
                db.RegularStudyDayLoadSubjects.RemoveRange(loads);
                db.DayLoadRegulars.Remove(load);                
            }
            else
            {
                return HttpNotFound();
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("DeleteZO")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteZOConfirmed(Guid id)
        {
            //add subject deleting!!!!!
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.ZOLoadRegulars.Find(id);
            if (load != null)
            {
                List<RegularStudyZOLoadSubjects> loads = db.RegularStudyZOLoadSubjects.Where(p => p.LoadId == id).ToList();
                db.RegularStudyZOLoadSubjects.RemoveRange(loads);
                db.ZOLoadRegulars.Remove(load);
            }
            else
            {
                return HttpNotFound();
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}