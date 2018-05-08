using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace RestaurantWebAccessLayer.Controllers
{
    public class RestaurantsController : Controller
    {

        // GET: Restaurants
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Top3()
        {
            ViewBag.Title = "Top3";
            return View("RestaurantList", BusinessLayer.BusinessLayer.GetTop3());
        }

        // GET: Restaurants/Create
        public ActionResult Restaurants()
        {
            ViewBag.Title = "All Restaurants";
            return View("RestaurantList", BusinessLayer.BusinessLayer.GetDataRestaurants());
        }

        public ActionResult Search(string id)
        {
            string search = "Search results for: ";
            ViewBag.Title = String.Concat(search, id);
            return View("RestaurantList", BusinessLayer.BusinessLayer.SearchRestaurants(id));
        }
        public ActionResult BuildRestaurant()
        {
            return View();
        }

        // POST: Restaurants/Create
        [HttpPost]
        public ActionResult Top3(FormCollection collection)
        {
            try
            {
                return View("RestaurantList", BusinessLayer.BusinessLayer.GetTop3());
                
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurants/Edit/5
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

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurants/Delete/5
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
    }
}
