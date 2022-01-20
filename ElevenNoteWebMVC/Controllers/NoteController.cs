using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElevenNoteWebMVC.Controllers
{

    [Authorize]
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);
            var model = service.GetNotes();

            return View();
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var service = NewMethod();

           if (service.CreateNote(model))
            {
                ViewBag.SaveResult = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Notes could not be created.");

            return View(model);
        }

        private NoteService NewMethod()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userID);
            return service;
        }
    }

}