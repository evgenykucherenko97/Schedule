﻿using Schedule.Classes;
using Schedule.COM;
using Schedule.Models;
using Schedule.Models.DTOs;
using Schedule.Models.HelpingModels;
using Schedule.Models.LoadModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        public async Task<ActionResult> Index()
        {
            return View(await db.Files.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> CreateLoad()
        {
            SelectList files = new SelectList(db.Files, "Path", "Path");
            ViewBag.Files = files;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateLoad(LoadHelperModel model)
        {
            dynamic list;
            string file_path = Server.MapPath("~/Files/" + model.Filepath);
            if (model.LoadKind == LoadKind.Day)
            {

                //////////////////////////
                DayLoadRegular dayLoadRegular = new DayLoadRegular()
                {
                    LoadName = model.Name,
                    StudentKind = model.StudentKind,
                    LoadKind = model.LoadKind
                };
                db.DayLoadRegulars.Add(dayLoadRegular);
                await db.SaveChangesAsync();
                //////////////////////////



                list = Import_COM.Import_Excel(file_path);
                List<RegularStudyDayLoadSubjects> loads = LoadConverter.FromDTOtoListOfDayRegularLoads(list[2]);
                DayLoadDTO temp;
                foreach (var load in loads)
                {
                    temp = LoadTypesMapper.DayLoadDTO(load);
                    temp.LoadId = dayLoadRegular.Id;
                    db.DayLoadDTOs.Add(temp);
                    db.SaveChanges();
                }
                

                return RedirectToAction("CreatedLoad", new { id = dayLoadRegular.Id });
            }
            else if (model.LoadKind == LoadKind.ZO)
            {
                list = Import_COM.Import_Excel_Zaoch(file_path);
                 RegularStudyZOLoadSubjects load = LoadConverter.FromDTOtoZORegularLoad(list[0]);
                db.ZOLoadDTOs.Add(LoadTypesMapper.ZOLoadDTO(load));
                db.SaveChanges();
                return RedirectToAction("CreatedLoadZO");
            }
            else
            {
                list = null;
                return RedirectToAction("Index");
                //exception
            }
        }

        public ActionResult CreatedLoad(Guid? id)
        {
            DayLoadRegular load = db.DayLoadRegulars.Find(id);
            List<DayLoadDTO> loadsDTO = db.DayLoadDTOs.Where(p => p.LoadId == load.Id).ToList();            
            return View(loadsDTO);
        }

        public ActionResult CreatedLoadZO()
        {
            return View(db.ZOLoadDTOs.ToList());
        }

        [HttpPost, ActionName("CreatedLoad")]
        public ActionResult RemoveAll()
        {
            db.DayLoadDTOs.RemoveRange(db.DayLoadDTOs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public async Task<ActionResult> Parse(Guid? Id)
        //{
        //    if (Id == null)
        //    {
        //        return null;
        //    }
        //    FileModel filemodel = await db.Files.FindAsync(Id);
        //    if (filemodel == null)
        //    {
        //        return null;
        //    }
        //    // Путь к файлу
        //    string file_path = Server.MapPath("~/Files/" + filemodel.Path);
        //    List<TableDataDTODay> list = Import_COM.Import_Excel(file_path);
        //    //// Тип файла - content-type
        //    //string file_type = filemodel.Path.Substring(filemodel.Path.IndexOf('.'));
        //    //// Имя файла - необязательно
        //    //string file_name = filemodel.Path;
        //    //return File(file_path, file_type, file_name);
        //    return RedirectToAction("Index");
        //}
    }
}