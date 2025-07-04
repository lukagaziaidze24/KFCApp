using KFCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


public class RestaurantController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index() 
    {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Restaurants.ToList(), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
        db.Restaurants.Add(restaurant);
        db.SaveChanges();
        return Json(restaurant);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;

        var restaurant = db.Restaurants.Find(id);
        if (restaurant == null)
        {
            return HttpNotFound();
        }

        try
        {
            db.Restaurants.Remove(restaurant);
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

}
