using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Owin;
using Schedule.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Schedule.BLL.Interfaces;
using Schedule.BLL.Services;

[assembly: OwinStartup(typeof(Schedule.App_Start.Startup))]

namespace Schedule.App_Start
{

    public class Startup
    {
        //С помощью фабрики сервисов здесь создается сервис для работы с сервисами
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            //Потом сервис региструется контекстом OWIN                                                      
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }

      //  <add name = "IdentityDb" providerName="System.Data.SqlClient"
      //connectionString="Data Source=(localdb)\v11.0;AttachDbFilename=|DataDirectory|\IdentityDb.mdf;Integrated Security=True;"/>
    
    }
}