using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CGIBack.Models
{
	public class Category
	{
		[Required]
		public int Id { get; set; }
		[Required]
		[StringLength(20, MinimumLength = 3)]
		public string Name { get; set; }
	}
}
