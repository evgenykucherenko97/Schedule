using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Schedule.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Schedule.BLL.Interfaces;
using Schedule.BLL.Infrastructure;
using Schedule.BLL.DTO;
using System.Net;

namespace Schedule.Controllers
{
    public class AccountController : Controller
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

        //admin
        public async Task<ActionResult> GetAll()
        {
            List<UserDTO> users = await UserService.GetAll();
            return View(users);
        }

        public async Task<ActionResult> Index()
        {
            UserDTO user = await UserService.GetUser(User.Identity.Name);
            UserDisplayModel userToDisplay = AutoMapper.Mapper.Map<UserDisplayModel>(user);
            return View(userToDisplay);
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO { Email = model.Email, Password = model.Password };
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        //admin does
        public ActionResult Register()
        {
            return View();
        }

        //admin does
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name
                };               
                switch (model.Role)
                {
                    case Roles.Admin: userDto.Role = "admin"; break;
                    case Roles.User: userDto.Role = "user"; break;
                    default: userDto.Role = "user"; break;
                }
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }



        public async Task<ActionResult> Edit()
        {
            UserDTO user = await UserService.GetUser(User.Identity.Name);
            EditModel model = AutoMapper.Mapper.Map<EditModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.Address,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await UserService.Edit(User.Identity.Name,userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("Index", "Home");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }


        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "evgenykucherenko97@gmail.com",
                UserName = "evgenykucherenko97@gmail.com",
                Password = "12345",
                Name = "name name name",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }




        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            OperationDetails result = await UserService.Delete(User.Identity.Name);
            if (result.Succedeed)
            {
                return RedirectToAction("Logout", "Account");
            }            
            return RedirectToAction("Index", "Home");
        }


        //admin does
        [HttpGet]
        public async Task<ActionResult> DeleteConcrete(string id)
        {
            if (id == null || id == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = await UserService.GetUserById(id);
            return View(userDTO);
        }

        //admin does
        [HttpPost]
        [ActionName("DeleteConcrete")]
        public async Task<ActionResult> DeleteConcreteConfirmed(string id)
        {            
            OperationDetails result = await UserService.DeleteById(id);
            if (result.Succedeed)
            {
                return RedirectToAction("GetAll", "Account");
            }
            return RedirectToAction("Index", "Home");
        }

        //admin does
        public async Task<ActionResult> DetailsConcrete(string id)
        {
            if (id == null || id == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = await UserService.GetUserById(id);
            return View(userDTO);
        }

        //admin does
        public async Task<ActionResult> EditConcrete(string id)
        {
            UserDTO user = await UserService.GetUserById(id);
            EditModelForAdmin model = new EditModelForAdmin()
            {
                Id = id,
                Name = user.Name,
                Address = user.Address,
                Email = user.Email,
                Role = Roles.User
            };
            switch (user.Role)
            {
                case "user": model.Role = Roles.User; break;
                case "admin": model.Role = Roles.Admin; break;
                default: model.Role = Roles.User; break;
            }
            //EditModel model = AutoMapper.Mapper.Map<EditModel>(user);
            return View(model);
        }

        //admin does
        [HttpPost]
        public async Task<ActionResult> EditConcrete(EditModelForAdmin model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Id = model.Id,
                    Email = model.Email,
                    Address = model.Address,
                    Name = model.Name
                };
                switch (model.Role)
                {
                    case Roles.Admin: userDto.Role = "admin"; break;
                    case Roles.User: userDto.Role = "user"; break;
                    default: userDto.Role = "user"; break;
                }
                OperationDetails operationDetails = await UserService.EditByIdWithoutPassword(userDto.Id, userDto);
                if (operationDetails.Succedeed)
                    return RedirectToAction("GetAll", "Account");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }
    }
}