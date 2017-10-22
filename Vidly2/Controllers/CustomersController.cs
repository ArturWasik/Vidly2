using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;
using Vidly2.ViewModels;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
	    List<Customer> customerList = new List<Customer>
	    {
		    new Customer{Id = 1, Name = "John Smith"},
		    new Customer{Id = 2, Name = "Mary Williams"}
	    };
	    // GET: Customers
	    public ActionResult Customers()
	    {
		    var rvm = new RandomMovieViewModel();

		    //{
		    //	new Customer{Id = 1, Name = "John Smith"},
		    //	new Customer{Id = 2, Name = "Mary Williams"}
		    //};

		    rvm.Customers = customerList;

		    return View(rvm);
	    }

	    [Route("Customers/Details/{id}")]
	    public ActionResult Details(int id)
	    {
		    Customer customer = customerList.FirstOrDefault(x => x.Id == id);

		    if (customer == null)
		    {
			    return HttpNotFound();
		    }

		    return View(customer);
	    }
    }
}