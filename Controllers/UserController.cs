using KFCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


public class UserController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index() {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Users.ToList(), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        db.Users.Add(user);
        db.SaveChanges();
        return Json(user);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;

        var user = db.Users.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }

        try
        {
            db.Users.Remove(user);
            db.SaveChanges();
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            return Json(new
            {
                success = false,
                message = ex.Message,
                inner = ex.InnerException?.Message
            });
        }
    }



    [HttpPost]
    public ActionResult OrderProduct(int userId, int productId, int quantity, int restaurantId)
    {
        var order = new Order
        {
            UserId = userId,
            ProductId = productId,
            Quantity = quantity,
            RestaurantId = restaurantId
        };
        db.Orders.Add(order);
        db.SaveChanges();
        return Json(order);
    }
}
