using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Vidly2.Models;

namespace Vidly2.ViewModels
{
	public class CustomerFormViewModel
	{
		public CustomerFormViewModel()
		{
			Id = 0;
		}

		public CustomerFormViewModel(Customer customer)
		{
			Id = customer.Id;
			Name = customer.Name;
			IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
			MembershipTypeId = customer.MembershipTypeId;
			Birthdate = customer.Birthdate;
		}

		public string Title
		{
			get
			{
				return Id != 0 ? "Edit Customer" : "New Customer";
			}
		}

		public int? Id { get; set; }

		[Required(ErrorMessage = "Please enter customer's name.")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18YearsIfAMember]
		public DateTime? Birthdate { get; set; }

		public IEnumerable<MembershipType> MembershipTypes { get; set; }
	}
}