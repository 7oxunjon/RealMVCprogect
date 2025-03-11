using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreat
{
	public class Student
	{
		public int Id { get; set; }
		public string FirtName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string Country { get; set; } = null!;
		public string Email { get; set; } = null!;
	}
}
