using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class MoviesController : Controller
    {
	    private ApplicationDbContext _context;

	    public MoviesController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
		    _context = new ApplicationDbContext();
	    }

		// GET: Movies/Random
		public ActionResult Movies()
		{
			var movies = _context.Movies.Include(x => x.Genre).ToList();

		    return View(movies);
	    }

	    public ActionResult Details(int id)
	    {
		    Movie movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

			return View(movie);
	    }

	    [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
	    public ActionResult ByReleaseDate(int year, int month)
	    {
		    return Content(year + "/" + month);
	    }
	}
}