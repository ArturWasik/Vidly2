﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Vidly2.Models
{
	public class MembershipType
	{
		public byte Id { get; set; }
		public short SignUpFree { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }
		[StringLength(255)]
		public string Name { get; set; }

		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
}