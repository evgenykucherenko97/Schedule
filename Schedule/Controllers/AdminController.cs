using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Schedule.BLL.DTO;
using Schedule.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Schedule.Controllers
{
    public class AdminController : Controller
    {

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Users()
        {
            List<UserDTO> userlist = await UserService.GetAll();
            if (userlist != null)
            {
                return View(userlist);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}