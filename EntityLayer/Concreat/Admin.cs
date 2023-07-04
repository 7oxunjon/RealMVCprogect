
using System.ComponentModel.DataAnnotations;


namespace EntityLayer.Concreat
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }

		[StringLength(50)]
		public string? AdminName { get; set; }

		[StringLength(50)]
		public string? AdminPassword { get; set; }

		[StringLength(1)]
		public string? AdminRole { get; set; }
	}
}
