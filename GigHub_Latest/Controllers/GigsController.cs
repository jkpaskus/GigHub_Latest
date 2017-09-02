using System.Web.Mvc;

namespace GigHub_Latest.Controllers
{
    using GigHub_Latest.Models;
    using GigHub_Latest.ViewModels;
    using System.Linq;

    public class GigsController : Controller
    {
        private ApplicationDbContext _context;

        public GigsController()
        {
            this._context = new ApplicationDbContext();
        }
        // GET: Gigs
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
                                {
                                    Genres = this._context.Genres.ToList()
                                };
            return View(viewModel);
        }
    }
}