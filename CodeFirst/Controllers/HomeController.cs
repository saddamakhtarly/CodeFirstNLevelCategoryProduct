using CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly MyContext context = new MyContext();
         
        public ActionResult Index()
        {
            // ViewBag.Customers = CustomersList;
            //var emp = context.Product;
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = context.Products.ToList();
            mymodel.Categories = context.Categories.ToList();

            ViewBag.Country = new SelectList(context.Categories, "Id", "Name");
            return View(mymodel);
        }
        public JsonResult GetStates(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            var stateList = this.Getstate(Convert.ToInt32(id));
            var stateData = stateList.Select(m => new SelectListItem()
            {
                Text = m.Name,
                Value = m.Name.ToString(),
            });
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }
        // Get State from DB by country ID  
        public IList<Product> Getstate(int CountryId)
        {
            return context.Products.Where(m => m.Categories.Id == CountryId).ToList();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}