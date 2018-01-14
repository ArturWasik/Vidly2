using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;
using Action = Antlr.Runtime.Misc.Action;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
	    private ApplicationDbContext _context;

	    public CustomersController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
		    _context = new ApplicationDbContext();
	    }

	    public ActionResult New()
	    {
		    var membershipTypes = _context.MembershipTypes.ToList();
		    var viewModel = new CustomerFormViewModel()
		    {
			    MembershipTypes = membershipTypes
		    };

		    return View("CustomerForm", viewModel);
	    }

		[HttpPost]
	    public ActionResult Create(Customer customer)
		{
			_context.Customers.Add(customer);
			_context.SaveChanges();

			return RedirectToAction("Index", "Customers");
		}

	    // GET: Customers
	    public ActionResult Index()
	    {
		    var customers = _context.Customers.Include(c => c.MembershipType).ToList();

		    return View(customers);
	    }

	    [Route("Customers/Details/{id}")]
	    public ActionResult Details(int id)
	    {
		    Customer customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);

		    if (customer == null)
		    {
			    return HttpNotFound();
		    }

		    return View(customer);
	    }

	    public ActionResult Edit(int id)
	    {
		    var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

		    if (customer == null)
		    {
			    return HttpNotFound();
		    }

		    var viewModel = new CustomerFormViewModel
		    {
				Customer = customer,
				MembershipTypes = _context.MembershipTypes.ToList()
		    };

		    return View("CustomerForm", viewModel);
	    }
    }
}