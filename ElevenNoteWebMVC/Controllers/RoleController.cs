using ElevenNoteWebMVC.Data;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNoteWebMVC.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _db;

        public RoleController()
        {
            _db = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = _db.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _db.Roles.Add(Role);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}