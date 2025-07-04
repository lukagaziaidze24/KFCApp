using KFCApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


public class ManagerController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index()
    {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Managers.ToList(), JsonRequestBehavior.AllowGet);
    }


    [HttpPost]
    public ActionResult Create(Manager manager)
    {
        db.Managers.Add(manager);
        db.SaveChanges();
        return Json(manager);
    }

    [HttpPost]
    public ActionResult Delete(int id)
    {
        db.Configuration.ProxyCreationEnabled = false;

        var manager = db.Managers.Find(id);
        if (manager == null)
        {
            return HttpNotFound();
        }

        try
        {
            db.Managers.Remove(manager);
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
    public ActionResult AddProduct(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
        return Json(product);
    }

    private string GetInnermostExceptionMessage(Exception ex)
    {
        while (ex.InnerException != null) ex = ex.InnerException;
        return ex.Message;
    }

    [HttpPost]
    public ActionResult DeleteProduct(int productId)
    {
        db.Configuration.ProxyCreationEnabled = false;
        var product = db.Products.Find(productId);
        if (product == null) return HttpNotFound();

        try
        {
            db.Products.Remove(product);
            db.SaveChanges();
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            var detailedMessage = GetInnermostExceptionMessage(ex);
            return Json(new { success = false, message = ex.Message, inner = detailedMessage });
        }
    }


}
