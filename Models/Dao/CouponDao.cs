using System;
using System.Collections.Generic;
using System.Linq;
using Models.EF;
using PagedList;
using Common;

namespace Models.Dao
{
    public class CouponDao
    {
        MovieProjectDbcontext db = null;
        public CouponDao()
        {
            db = new MovieProjectDbcontext();
        }

        public int CouponValidation(string code)
        {
            var result = db.Coupons.SingleOrDefault(x => x.CouponsCode == code);
            if(result == null)
            {
                return 0;
            }
            else { return 1; }
        }
        public Coupon GetCoupon(string code)
        {
            return db.Coupons.SingleOrDefault(x => x.CouponsCode == code);
        }
    }
}
