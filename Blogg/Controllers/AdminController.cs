using Blogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blogg.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        IBlogRepository repository;

        public AdminController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Log()
        {
            return View(repository.GetLog());
        }

        public ActionResult CreatePost()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            repository.AddPost(model);

            return RedirectToAction("Index", "Admin");
        }
    }
}