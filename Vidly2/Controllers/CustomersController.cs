﻿using System;
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
	    private ApplicationDbContext _context;

	    public CustomersController()
	    {
		    _context = new ApplicationDbContext();
	    }

	    protected override void Dispose(bool disposing)
	    {
		    _context = new ApplicationDbContext();
	    }

	    // GET: Customers
	    public ActionResult Customers()
	    {
		    var customers = _context.Customers;

		    return View(customers);
	    }

	    [Route("Customers/Details/{id}")]
	    public ActionResult Details(int id)
	    {
		    Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);

		    if (customer == null)
		    {
			    return HttpNotFound();
		    }

		    return View(customer);
	    }
    }
}