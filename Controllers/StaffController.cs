using KFCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


public class StaffController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index() {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Staff.ToList(), JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult Create(Staff staff)
    {
        db.Staff.Add(staff);
        db.SaveChanges();
        return Json(staff);
    }


    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;

        var staff = db.Staff.Find(id);
        if (staff == null)
        {
            return HttpNotFound();
        }

        try
        {
            db.Staff.Remove(staff);
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
    public ActionResult PrepareOrder(int orderId)
    {
        var order = db.Orders.Find(orderId);
        if (order == null) return HttpNotFound();
        order.Status = "Prepared";
        db.SaveChanges();
        return Json(new { prepared = true });
    }


    [HttpPost]
    public ActionResult DeleteOrder(int orderId)
    {
        var order = db.Orders.Find(orderId);
        if (order == null) return HttpNotFound();
        db.Orders.Remove(order);
        db.SaveChanges();
        return Json(new { deleted = true });
    }
}
