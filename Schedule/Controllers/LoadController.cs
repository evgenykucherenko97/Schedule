using Schedule.Classes;
using Schedule.COM;
using Schedule.Models;
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

        public async Task<ActionResult> Parse(Guid? Id)
        {
            if (Id == null)
            {
                return null;
            }
            FileModel filemodel = await db.Files.FindAsync(Id);
            if (filemodel == null)
            {
                return null;
            }
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/" + filemodel.Path);
            List<TableDataDTO> list = Import_COM.Import_Excel(file_path);
            //// Тип файла - content-type
            //string file_type = filemodel.Path.Substring(filemodel.Path.IndexOf('.'));
            //// Имя файла - необязательно
            //string file_name = filemodel.Path;
            //return File(file_path, file_type, file_name);
            return RedirectToAction("Index");
        }
    }
}