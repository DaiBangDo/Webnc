using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class ProductsOfCategoryController : Controller
    {
        SanPham sp = new SanPham();
        // GET: ProductsOfCategory
        public ActionResult Index(string id)
        {
            List<SanPham> listSp;
            if (id == null)
            {
                listSp = sp.getAllSP();
            }
            else
            {
                listSp = sp.getSanPhambyLoai(id);
            }
            return View(listSp);
        }
    }
}