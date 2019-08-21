﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using BusinessManagementSystemApp.Models.Models;

namespace BusinessManagementSystemApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(c =>
            {
                c.CreateMap<Customer, CustomerViewModel>();
                c.CreateMap<CustomerViewModel, Customer>();
            });
        }
    }
}
