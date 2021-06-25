namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RevenuesStatisticSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetRevenueStatistic",
                p => new
                {
                    fromDate = p.String(),
                    toDate = p.String()
                },
                    @"
                    select
                    datepart(mm,o.CreateDate) as Month,
                    sum(od.Quantity*od.Price) as Revenues 
                    from [dbo].[Order] o
                    inner join OrderDetail od
                    on o.ID = od.OrderID
                    where o.CreateDate <= cast(@toDate as date) and o.CreateDate >= cast(@fromDate as date)
                    group by datepart(mm,o.CreateDate)
                    "
                );
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.GetRevenueStatistic");
        }
    }
}
