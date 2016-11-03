using MVC4.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC4.Web.Controllers
{
    public class ReviewsController : Controller
    {
        WebsiteDB repo = new WebsiteDB();
        // GET: Reviews
        public ActionResult Index()
        {
            
            using (var repo = new WebsiteDB())
            {
               var  model = repo.Restaurants ;
                //var model = _review.OrderBy(r => r.Country);
                return View(model);
            }
               
        }

        // GET: Reviews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reviews/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reviews/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reviews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reviews/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //static List<RestaurantReview> _review = new List<RestaurantReview>
        //{
        //    new RestaurantReview { Id = 1,Name = "Cinamin Club",City = "London", Country="UK", Rating = 10},
        //    new RestaurantReview { Id = 1,Name = "MarshMellow Club",City = "west valley", Country="USA", Rating = 4}

        //};
    }
}
