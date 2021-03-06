﻿using System.Web.Mvc;

namespace GigHub_Latest.Controllers
{
    using GigHub_Latest.Models;
    using GigHub_Latest.ViewModels;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            this._context = new ApplicationDbContext();
        }
        

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
                {
                    Genres = this._context.Genres.ToList()
                };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = this._context.Genres.ToList();
                return this.View("Create", viewModel);
            }

            var gig = new Gig
                          {
                              ArtistId = this.User.Identity.GetUserId(),
                              DateTime = viewModel.GetDateTime(),
                              GenreId = viewModel.Genre,
                              Venue = viewModel.Venue
                          };
            this._context.Gigs.Add(gig);
            this._context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}