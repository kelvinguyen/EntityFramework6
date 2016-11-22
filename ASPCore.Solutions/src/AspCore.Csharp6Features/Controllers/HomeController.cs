using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspCore.Csharp6Features.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspCore.Csharp6Features.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public ViewResult Index()
        {
            List<string> results = new List<string>();
            foreach (var p in Product.GetProduct())
            {
                // null operator and coalescing operator
                string name = p?.Name ?? "<NoName>";
                decimal? price = p?.Price ?? 0;
                //chaining null operator
                string relateProduct = p?.RelateProduct?.Name ?? "<No relating product>";
                results.Add(string.Format($"{nameof(p.Name)} : {name}, {nameof(p.Price)} : {price}, {nameof(p.RelateProduct)} : {relateProduct}"));


            }
            //return View(new string[] { "C#", "Language","Feature"});
            return View(results);
        }
    }
}
