using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Vidly2.Models
{
	public class Genre
	{
		public byte Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}