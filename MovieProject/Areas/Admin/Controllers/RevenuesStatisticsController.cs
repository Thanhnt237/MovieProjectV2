using Common.ViewModels;
using Models.Dao;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProject.Areas.Admin.Controllers
{
    public class RevenuesStatisticsController : Controller
    {
        MovieProjectDbcontext db = new MovieProjectDbcontext();

        // GET: Admin/RevenuesStatistics
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new OrderDao();
            var model = dao.GetRevenuesStatistic("01/01/2021","01/01/2023");
            return View(model);
        }

    }
}