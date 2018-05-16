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
        public List<RegularStudyDayLoadSubjects> FromDTOtoListOfDayRegularLoads(TableDataDTODay tableDataDTODay)
        {
            List<RegularStudyDayLoadSubjects> loads = new List<RegularStudyDayLoadSubjects>();
            string[] groupNames = tableDataDTODay.Groups.Split(null);
            RegularStudyDayLoadSubjects temp;
            //for lector
            if ((tableDataDTODay.LectionCountPerFirstHalf != null || tableDataDTODay.LectionCountPerSecondHalf != null) &&
                (tableDataDTODay.LectionCountPerFirstHalf != 0 || tableDataDTODay.LectionCountPerSecondHalf != 0))
                {
                    temp = new RegularStudyDayLoadSubjects();
                    temp.KindOfClasses = KindOfClasses.Lections;
                    temp.Subject = new Subject()
                    {
                        Id = Guid.NewGuid(),
                        Name = tableDataDTODay.SubjectName
                    };
                    temp.DZ = null;
                    foreach (string group in groupNames)
                    {
                        temp.Groups.Add(db.Groups.Where(p => p.Name == group).FirstOrDefault());
                    }
                    temp.StudentCount = 0;
                    foreach (var group in temp.Groups)
                    {
                        temp.StudentCount += (int)group.StudentCount;
                        temp.Subject.Name += ", " + group.Name;
                    }
                    if ((bool)tableDataDTODay.FormControlZach)
                    {
                        temp.FormOfControl = FormOfControl.FormControlZach;
                        temp.HoursForControl = 2;
                        temp.Cons = null;
                    }
                    if ((bool)tableDataDTODay.FormControlDiv)
                    {
                        temp.FormOfControl = FormOfControl.FormControlDiv;
                        temp.HoursForControl = 2;
                        temp.Cons = null;
                    }
                    if ((bool)tableDataDTODay.FormControlExam)
                    {
                        temp.FormOfControl = FormOfControl.FormControlExam;
                        temp.HoursForControl = temp.StudentCount / 3.0303;
                        temp.Cons = temp.Groups.Count * 2;
                    }
                    temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                    temp.Term = tableDataDTODay.Term;
                    temp.CourseWork = CourseWork.None;
                    temp.HoursForCourseWork = null;
                    temp.HoursOfWork = tableDataDTODay.LectionCountPerFirstHalf + tableDataDTODay.LectionCountPerSecondHalf;
                    temp.HoursOfWorkAll = temp.HoursOfWork;
                    temp.AllCredits = (double)temp.HoursOfWorkAll + (double)temp.HoursForControl;
                    if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                    if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                    loads.Add(temp);
                }

            if ((tableDataDTODay.LabCountPerFirstHalf != null || tableDataDTODay.LabCountPerSecondHalf != null) &&
                (tableDataDTODay.LabCountPerFirstHalf != 0 || tableDataDTODay.LabCountPerSecondHalf != 0))
                {
                    bool noLections = loads.Count == 0;
                    foreach (var group in groupNames)
                    {
                        temp = new RegularStudyDayLoadSubjects();
                        temp.KindOfClasses = KindOfClasses.Labs;
                        temp.Subject = new Subject()
                        {
                            Id = Guid.NewGuid(),
                            Name = tableDataDTODay.SubjectName
                        };
                        temp.DZ = null;
                        temp.Groups.Add(db.Groups.Where(p => p.Name == group).FirstOrDefault());
                        temp.StudentCount = (int)temp.Groups.FirstOrDefault().StudentCount;
                        temp.DZ = temp.StudentCount / 2.0 * (tableDataDTODay.RK + tableDataDTODay.RGR + tableDataDTODay.RR);
                        temp.Subject.Name += ", " + temp.Groups.FirstOrDefault().Name;
                        temp.HoursForControl = null;
                        if ((bool)tableDataDTODay.FormControlZach)
                        {
                            if (noLections) temp.HoursForControl = 2;
                            temp.FormOfControl = FormOfControl.FormControlZach;
                        }
                        if ((bool)tableDataDTODay.FormControlDiv)
                        {
                            if (noLections) temp.HoursForControl = 2;
                            temp.FormOfControl = FormOfControl.FormControlDiv;
                        }
                        if ((bool)tableDataDTODay.FormControlExam)
                        {
                            temp.FormOfControl = FormOfControl.FormControlExam;
                        }
                        
                        temp.Cons = null;
                        temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                        temp.Term = tableDataDTODay.Term;
                        temp.HoursOfWork = tableDataDTODay.LabCountPerFirstHalf + tableDataDTODay.LabCountPerSecondHalf;
                        temp.HoursOfWorkAll = temp.HoursOfWork;
                        #region
                        //course
                        temp.CourseWork = CourseWork.None;
                        temp.HoursForCourseWork = null;
                        if (tableDataDTODay.CourserWork != null && tableDataDTODay.CourserWork != 0)
                        {
                            temp.CourseWork = CourseWork.CourseWork;
                            temp.HoursForCourseWork = temp.StudentCount * 3;
                        }
                        else if (tableDataDTODay.CourseProject != null && tableDataDTODay.CourseProject != 0)
                        {
                            temp.CourseWork = CourseWork.CourseProject;
                            temp.HoursForCourseWork = temp.StudentCount * 4;
                        }
                        #endregion
                        
                        temp.AllCredits = (double)temp.HoursOfWorkAll;
                        if (temp.HoursForControl != null) temp.AllCredits += (double)temp.HoursForControl;
                        if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                        if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                        if (temp.HoursForCourseWork != null) temp.AllCredits += (double)temp.HoursForCourseWork;
                        loads.Add(temp);
                    }
                }

            if ((tableDataDTODay.PracticeCountPerFirstHalf != null || tableDataDTODay.PracticeCountPerSecondHalf != null) &&
                (tableDataDTODay.PracticeCountPerFirstHalf != 0 || tableDataDTODay.PracticeCountPerSecondHalf != 0))
                {
                    bool noLections = loads.Count == 0;
                    foreach (var group in groupNames)
                    {
                        temp = new RegularStudyDayLoadSubjects();
                        temp.KindOfClasses = KindOfClasses.Labs;
                        temp.Subject = new Subject()
                        {
                            Id = Guid.NewGuid(),
                            Name = tableDataDTODay.SubjectName
                        };
                        temp.Groups.Add(db.Groups.Where(p => p.Name == group).FirstOrDefault());
                        temp.StudentCount = (int)temp.Groups.FirstOrDefault().StudentCount;
                        //if (tableDataDTODay.LabCountPerFirstHalf == null || tableDataDTODay.LabCountPerSecondHalf == null)
                            temp.DZ = temp.StudentCount / 2.0 * (tableDataDTODay.RK + tableDataDTODay.RGR + tableDataDTODay.RR);
                        temp.Subject.Name += ", " + temp.Groups.FirstOrDefault().Name;
                        temp.HoursForControl = null;
                        if ((bool)tableDataDTODay.FormControlZach)
                        {
                            if (noLections) temp.HoursForControl = 2;
                            temp.FormOfControl = FormOfControl.FormControlZach;
                        }
                        if ((bool)tableDataDTODay.FormControlDiv)
                        {
                            if (noLections) temp.HoursForControl = 2;
                            temp.FormOfControl = FormOfControl.FormControlDiv;
                        }
                        if ((bool)tableDataDTODay.FormControlExam)
                        {
                            temp.FormOfControl = FormOfControl.FormControlExam;
                        }
                        temp.Cons = null;
                        temp.SelfWorkHours = tableDataDTODay.SelfWorkHours;
                        temp.Term = tableDataDTODay.Term;
                        temp.HoursOfWork = tableDataDTODay.PracticeCountPerFirstHalf + tableDataDTODay.PracticeCountPerSecondHalf;
                        temp.HoursOfWorkAll = temp.HoursOfWork;

                        #region
                        //course
                        if (tableDataDTODay.CourserWork != null && tableDataDTODay.CourserWork != 0)
                        {
                            temp.CourseWork = CourseWork.CourseWork;
                            temp.HoursForCourseWork = temp.StudentCount * 3;
                        }
                        else if (tableDataDTODay.CourseProject != null && tableDataDTODay.CourseProject != 0)
                        {
                            temp.CourseWork = CourseWork.CourseProject;
                            temp.HoursForCourseWork = temp.StudentCount * 4;
                        }
                        #endregion

                        temp.AllCredits = (double)temp.HoursOfWorkAll;
                        if (temp.HoursForControl != null) temp.AllCredits += (double)temp.HoursForControl;
                        if (temp.DZ != null) temp.AllCredits += (double)temp.DZ;
                        if (temp.Cons != null) temp.AllCredits += (double)temp.Cons;
                        if (temp.HoursForCourseWork != null) temp.AllCredits += (double)temp.HoursForCourseWork;
                        loads.Add(temp);
                    }
                }
            
            return loads;
        }

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
            
            dynamic list, gek;
            string file_path = Server.MapPath("~/Files/" + model.Filepath);
            string file_path_GEK = Server.MapPath("~/Files/" + model.Filepath_GEK);
            if (model.LoadKind == LoadKind.Day)
            {
                list = Import_COM.Import_Excel(file_path);
                gek = Import_COM.Import_Excel_GEKDay(file_path_GEK);
                var loads = new List<RegularStudyDayLoadSubjects>();// LoadConverter.FromDTOtoListOfDayRegularLoads(list[2]);
                var geks = new List<RegularStudyDayLoadGEK>();

                for (int i = 0; i < list.Count; i++)
                {
                    loads.AddRange(FromDTOtoListOfDayRegularLoads(list[i]));
                }

                for (int i = 0; i < gek.Count; i++)
                {
                    geks.AddRange(LoadConverter.FromDTOtoListOfDayGEK(gek[i]));
                }
                
                DayLoadRegular dayLoadRegular = new DayLoadRegular()
                {
                    LoadName = model.Name,
                    StudentKind = model.StudentKind,
                    regularStudyDayLoadSubjects = loads,
                    //gekLoadModels = geks
                };
                for (int i = 0; i<dayLoadRegular.regularStudyDayLoadSubjects.Count; i++)
                {
                    dayLoadRegular.regularStudyDayLoadSubjects.ElementAt(i).LoadId = dayLoadRegular.Id;
                    //dayLoadRegular.gekLoadModels.ElementAt(i).IdLoad = dayLoadRegular.Id;
                }

                db.DayLoadRegulars.Add(dayLoadRegular);
                await db.SaveChangesAsync();
                return RedirectToAction("CreatedLoad", new { id = dayLoadRegular.Id });
            }
            else if (model.LoadKind == LoadKind.ZO)
            {
                list = Import_COM.Import_Excel_Zaoch(file_path);
                RegularStudyZOLoadSubjects load = LoadConverter.FromDTOtoZORegularLoad(list[0]);
                var loads = new List<RegularStudyZOLoadSubjects>();
                loads.Add(load);
                foreach (var group in load.Groups)
                {
                    db.Groups.Attach(group);
                }
                ZOLoadRegular zoLoadRegular = new ZOLoadRegular()
                {
                    LoadName = model.Name,
                    StudentKind = model.StudentKind,
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
            ViewBag.LoadKind = "Дневная";

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
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Surname");
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
        public ActionResult DoneLoad(Guid? id, Guid? teacher)
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
            ViewBag.LoadKind = "Дневная";

            List<RegularStudyDayLoadSubjects> list = db.RegularStudyDayLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (teacher != null)
            {
                list = db.RegularStudyDayLoadSubjects
                .Include(p => p.Teacher).Where(p => p.Teacher.Id == teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            }
            if (list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<DayLoadDTO> loadsDTO = new List<DayLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.DayLoadDTO(loadReg));
            }
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Surname");
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
            ViewBag.LoadKind = "Дневная";

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
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Surname");
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
        public ActionResult DoneLoadZO(Guid? id, Guid? teacher)
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
            ViewBag.LoadKind = "Заочная"; 

            List<RegularStudyZOLoadSubjects> list = db.RegularStudyZOLoadSubjects
                .Include(p => p.Teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            if (teacher != null)
            {
                list = db.RegularStudyZOLoadSubjects
                .Include(p => p.Teacher).Where(p => p.Teacher.Id == teacher)
                .Include(r => r.Subject)
                .Include(k => k.Groups)
                .Where(e => e.LoadId == id).ToList();
            }
            if (list == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<ZOLoadDTO> loadsDTO = new List<ZOLoadDTO>();
            foreach (var loadReg in list)
            {
                loadsDTO.Add(LoadTypesMapper.ZOLoadDTO(loadReg));
            }
            ViewBag.Teachers = new SelectList(db.TeacherModels, "Id", "Surname");
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.DayLoadRegulars.Find(id);
            if (load != null)
            {
                List<RegularStudyDayLoadSubjects> loads = db.RegularStudyDayLoadSubjects.Include(r => r.Subject).Where(p => p.LoadId == id).ToList();
                foreach (var item in loads)
                {
                    db.Subjects.Remove(item.Subject);
                }
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var load = db.ZOLoadRegulars.Find(id);
            if (load != null)
            {
                List<RegularStudyZOLoadSubjects> loads = db.RegularStudyZOLoadSubjects.Include(r => r.Subject).Where(p => p.LoadId == id).ToList();
                foreach (var item in loads)
                {
                    db.Subjects.Remove(item.Subject);
                }
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