using KFCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


public class OrderController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index() {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Orders.ToList(), JsonRequestBehavior.AllowGet);
    } 

    [HttpPost]
    public ActionResult MakeOrder(Order order)
    {
        order.Status = "Pending";
        db.Orders.Add(order);
        db.SaveChanges();
        return Json(order);
    }

    [HttpPost]
    public ActionResult CancelOrder(int id)
    {
        var order = db.Orders.Find(id);
        if (order == null) return HttpNotFound();
        order.Status = "Canceled";
        db.SaveChanges();
        return Json(new { success = true });
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;

        var order = db.Orders.Find(id);
        if (order == null)
        {
            return HttpNotFound();
        }

        try
        {
            db.Orders.Remove(order);
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
