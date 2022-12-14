using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ProductDetailsController : Controller
    {
        SanPham sp = new SanPham();
        
        // GET: ProductDetails
        public ActionResult Index(string id)
        {
            sp = sp.GetSanPham(id);
            return View(sp);
        }
    }
}