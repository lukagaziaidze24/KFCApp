using System.Linq;
using System.Web.Mvc;
using KFCApp.Models;
using System.Data.Entity;


public class ProductController : Controller
{
    private readonly KfcDbContext db = new KfcDbContext();

    public ActionResult Index()
    {
        db.Configuration.ProxyCreationEnabled = false;
        return Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
    }

    //[HttpPost]
    //public ActionResult Add(Product product)
    //{
    //    db.Products.Add(product);
    //    db.SaveChanges();
    //    return Json(product);
    //}

    //[HttpDelete]
    //public ActionResult Delete(int id)
    //{
    //    var product = db.Products.Find(id);
    //    if (product == null) return HttpNotFound();
    //    db.Products.Remove(product);
    //    db.SaveChanges();
    //    return Json(new { success = true });
    //}
}
