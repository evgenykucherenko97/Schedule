using Schedule.Models;
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
    public class FileController : Controller
    {
        private ScheduleContext db = new ScheduleContext();
        // GET: File
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return View(await db.Files.ToListAsync());
        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                db.Files.Add(new FileModel()
                {
                    Id = Guid.NewGuid(),
                    Path = fileName.ToString(),
                    Date = DateTime.Now
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        public async Task<FileResult> Download(Guid? Id)
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
            // Тип файла - content-type
            string file_type = filemodel.Path.Substring(filemodel.Path.IndexOf('.'));
            // Имя файла - необязательно
            string file_name = filemodel.Path;
            return File(file_path, file_type, file_name);
        }

        public async Task<ActionResult> Delete(Guid? Id)
        {
            if (Id == null)
            {
                return RedirectToAction("Index");
            }
            FileModel filemodel = await db.Files.FindAsync(Id);
            if (filemodel == null)
            {
                return RedirectToAction("Index");
            }
            string fullPath = Request.MapPath("~/Files/" + filemodel.Path);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                db.Files.Remove(filemodel);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
           
    }
}