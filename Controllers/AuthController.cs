using System.Linq;
using System.Web.Mvc;
using KFCApp.Models;
using System.Data.Entity;

public class AuthController : Controller
{
	private KfcDbContext db = new KfcDbContext();

	[HttpPost]
	public ActionResult Register(User user)
	{
		if (db.Users.Any(u => u.Email == user.Email))
			return Json(new { success = false, message = "Email already registered." });

		db.Users.Add(user); // 🔒 For production: hash the password
		db.SaveChanges();
		return Json(new { success = true, user });
	}

	[HttpPost]
	public ActionResult Login(string email, string password)
	{
		var user = db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
		if (user == null)
			return Json(new { success = false, message = "Invalid credentials" });

		return Json(new { success = true, user });
	}
}
