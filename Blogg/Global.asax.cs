using AutoMapper;
using Blogg.App_Start;
using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blogg
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Mapper.CreateMap<Post, PostListViewModel>();
            Mapper.CreateMap<Post, PostPageViewModel>()
                .ForMember(vm => vm.PostId, em => em.MapFrom(p => p.Id));
            Mapper.CreateMap<CreatePostViewModel, Post>();
            Mapper.CreateMap<Error, LogViewModel>();
            Mapper.CreateMap<Comment, CommentViewModel>();
        }

        protected void Application_Error()
        {
            using (var db = new LogContext("LogDB"))
            {
                db.Errors.Add(new Error { Time = DateTime.Now, Message = Server.GetLastError().Message });
                db.SaveChanges();
            }
        }
    }
}
