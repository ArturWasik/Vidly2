using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
		public ActionResult Index()
		{
			var movies = _context.Movies.Include(x => x.Genre).ToList();

			return View(movies);
		}

		public ActionResult Details(int id)
		{
			Movie movie = _context.Movies.Include(x => x.Genre).SingleOrDefault(x => x.Id == id);

			return View(movie);
		}

		public ActionResult New()
		{
			var viewModel = new MovieFormViewModel
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.Single(x => x.Id == id);

			if (movie == null)
			{
				return HttpNotFound();
			}

			var viewModel = new MovieFormViewModel(movie)
			{
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}

		[HttpPost]
		public ActionResult Save(Movie movie)
		{

			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genres.ToList()
				};
			}

			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				_context.Movies.Add(movie);
			}
			else
			{
				var customerInDb = _context.Movies.Single(x => x.Id == movie.Id);
				customerInDb.Name = movie.Name;
				customerInDb.GenreId = movie.GenreId;
				customerInDb.ReleaseDate = movie.ReleaseDate;
				customerInDb.NumberInStock = movie.NumberInStock;
			}

			_context.SaveChanges();

			return RedirectToAction("Index", "Movies");
		}

		[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content(year + "/" + month);
		}
	}
}