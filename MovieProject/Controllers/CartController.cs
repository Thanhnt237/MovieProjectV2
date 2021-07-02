using Models.Dao;
using Models.EF;
using MovieProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MovieProject.Controllers
{
    public class CartController : Controller
    {
        private const string CartSession = "CartSession";
        [HttpGet]
        public ActionResult Payment()
        {
            var cartSession = Session[CartSession];
            var list = new List<CartItem>();
            if (CartSession != null)
            {
                list = (List<CartItem>)cartSession;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult Payment(string customerName,string customerPhone, string customerEmail)
        {
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.CustomerName = customerName;
            order.CustomerPhone = customerPhone;
            order.CustomerEmail = customerEmail;
            try
            {
                var id = new OrderDao().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailDao = new OrderDetailsDao();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.OrderID = id;
                    orderDetail.Price = 75000;
                    orderDetail.Quantity = item.Quantity;
                    detailDao.Insert(orderDetail);
                }
                Session[Common.CommonContants.CART_SESSION] = null;
            }
            catch (Exception ex)
            {
                throw;
            }
            return Redirect("/hoan-thanh");
        }

        // GET: Cart
        public ActionResult Index()
        {
            var cartSession = Session[CartSession];
            var list = new List<CartItem>();
            if (CartSession != null)
            {
                list = (List<CartItem>)cartSession;
            }
            return View(list);
        }
        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Movie.MovieID == id);
            Session[CartSession] = sessionCart;

            return Json(new
            {
                status = true
            });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach(var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.Movie.MovieID == item.Movie.MovieID);
                if(jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;

            return Json(new
            {
                status = true
            });
        }

        public ActionResult AddItem(int movieID, int quantity)
        {
            var movie = new MovieDao().ViewDetail(movieID);
            var cartSession = Session[CartSession];

            if (cartSession != null)
            {
                var list = (List<CartItem>)cartSession;
                if (list.Exists(x => x.Movie.MovieID == movieID))
                    {
                    foreach (var item in list)
                    {
                        if (item.Movie.MovieID == movieID)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //Create new CartItem Object
                    var item = new CartItem();
                    item.Movie = movie;
                    item.Quantity = quantity;
                    list.Add(item);
                }


            }
            else
            {
                //Create new CartItem Object
                var item = new CartItem();
                item.Movie = movie;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Made as a session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult CheckCoupon(CouponModel model)
        {
            var couponCheck = new CouponDao().CouponValidation(model.CouponCode);
            var cartSession = Session[CartSession];

            if (couponCheck == 1)
            {
                var coupon = new CouponDao().GetCoupon(model.CouponCode);
                model.CouponName = coupon.CouponsName;
                model.CouponId = coupon.CouponsID;
                model.CouponDiscount = coupon.Discount;
                RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Mã giảm giá không đúng");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}