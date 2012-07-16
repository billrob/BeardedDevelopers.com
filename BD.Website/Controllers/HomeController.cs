using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BD.Website.DbModels;

namespace BD.Website.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			ViewBag.Message = "Welcome to ASP.NET MVC!";

			List<SubmittedDeveloper> list = null;
			using (var db = new BDDbContext())
			{
				list = db.SubmittedDevelopers.ToList();
			}

			return View(list);
		}

		public ActionResult About()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View(new SubmittedDeveloper());
		}

		[HttpPost]
		public ActionResult Create(SubmittedDeveloper model)
		{
			if (!ModelState.IsValid)
				return View(model);

			using (var db = new BDDbContext())
			{
				if (model.SubmittedDeveloperId == 0)
					db.SubmittedDevelopers.Add(model);
				else
					throw new NotImplementedException("Can't update existing models");

				db.SaveChanges();
			}

			return Redirect("~/");
		}
	}
}
