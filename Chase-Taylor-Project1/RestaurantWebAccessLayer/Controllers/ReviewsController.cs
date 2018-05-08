using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantWebAccessLayer.Models;

namespace RestaurantWebAccessLayer.Controllers
{
    public class ReviewsController : Controller
    {

        static int IDTemp;
        // GET: Reviews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReviewPage(BusinessLayer.RestaurantComp.Restaurant restaurant)
        {
            ViewBag.Title = restaurant.name;
            IDTemp = restaurant.RestaurantID;
            BusinessLayer.RestaurantComp.Restaurant temp = BusinessLayer.BusinessLayer.GetDataRestaurants().ToList().Find(x => x.name == restaurant.name);
            return View("ReviewsPage", temp);
        }

        public ActionResult AddReview()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        public ActionResult AddingReview([Bind(Include = "rating,written")] Review rev)
        {
            rev.RestaurantID = IDTemp;
            if (ModelState.IsValid)
            {
                BusinessLayer.BusinessLayer.AddReview(WebToBusConverter.RevWebToLibConversion(rev));

                return RedirectToAction("ReviewPage", BusinessLayer.BusinessLayer.GetDataRestaurants().ToList().Find(x => x.RestaurantID == rev.RestaurantID));
            }
            
                return View("AddReview");
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
    }
}
