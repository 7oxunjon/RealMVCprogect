using DataAsseccLayer.Concreat;
using EntityLayer.Concreat;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RealMVCprogect.Controllers
{
	[AllowAnonymous]
	public class StudentController : Controller
	{
		private readonly AppDbContext _context;

		public StudentController(AppDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		//[HttpGet]
		//public IActionResult GetStudentList()
		//{
		//	var st = _context.students.ToList();
		//	var student = st.Select(p => new Student
		//	{
		//		Id = p.Id,
		//		FirtName = p.FirtName,
		//		LastName = p.LastName,
		//		Country = p.Country,
		//		Email = p.Email,
		//	}).ToList();
		//	return Json(student);
		//}
	}
}
