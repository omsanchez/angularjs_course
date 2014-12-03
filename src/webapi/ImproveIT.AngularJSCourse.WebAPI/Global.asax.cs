using ImproveIT.AngularJSCourse.Data;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ImproveIT.AngularJSCourse.WebAPI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {

        public static ISessionFactory SessionFactory = DataContextBuilder.BuildNHibernateSessionFactory("web");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public WebApiApplication()
        {
            this.BeginRequest += WebApiApplication_BeginRequest;
            this.EndRequest += WebApiApplication_EndRequest;
        }

        void WebApiApplication_BeginRequest(object sender, EventArgs e)
        {
            var session = WebApiApplication.SessionFactory.OpenSession();
            NHibernate.Context.CurrentSessionContext.Bind(session);
        }

        void WebApiApplication_EndRequest(object sender, EventArgs e)
        {
            var session = NHibernate.Context.CurrentSessionContext.Unbind(WebApiApplication.SessionFactory);
        }

    }
}