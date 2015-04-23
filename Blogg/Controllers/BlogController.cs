using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Blogg.Controllers
{
    public class BlogController : Controller
    {
        IBlogRepository repository;

        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.GetPosts(0, 10));
        }

        public ActionResult Post(int id)
        {
            return View(repository.GetPost(id));
        }

        public ActionResult GetPosts(int id)
        {
            return PartialView("_PostList", repository.GetPosts(1 * id, 10));
        }

        [HttpPost]
        public ActionResult PostComment(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            FormsAuthentication.SetAuthCookie(model.UserName, true);

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            MembershipCreateStatus status;
            Membership.CreateUser(model.UserName,
                                  model.Password,
                                  model.Email,
                                  model.Question,
                                  model.Answer,
                                  true,
                                  out status);

            Roles.AddUserToRole(model.UserName, "Members");

            return RedirectToAction("Index", "Blog");
        }
    }
}