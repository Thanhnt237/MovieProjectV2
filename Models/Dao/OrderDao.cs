using Common.ViewModels;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class OrderDao
    {
        MovieProjectDbcontext db = null;

        public OrderDao()
        {
            db = new MovieProjectDbcontext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }

        public IEnumerable<RevenuesStatisticViewModel> GetRevenuesStatistic(string fromDate, string toDate)
        {
            var parameters = new object[]
            {
                new SqlParameter("@fromDate", fromDate),
                new SqlParameter("@toDate", toDate)
            };
            return db.Database.SqlQuery<RevenuesStatisticViewModel>("GetRevenueStatistic @fromDate,@toDate", parameters);
            /*
            var model = from o in db.Orders
                        join od in db.OrderDetails on o.ID equals od.OrderID
                        select
                        new RevenuesStatisticViewModel()
                        {
                            Date = (DateTime)o.CreateDate,
                            Revenues = (decimal)(od.Quantity * od.Price)
                        };

            model.GroupBy(x => x.Date).Select(x => x);

            return model.ToList();
            */
        }

    }
}
