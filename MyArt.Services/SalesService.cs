using MyArt.Data;
using MyArt.Model;
using MyArtInventoryMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArt.Services
{
    public class SalesService
    {


        private readonly Guid _userId;

        public SalesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSale(SaleCreate model)
        {


            var entity =
                new Sale()
                {
                    OwnerID = _userId,

                    ArtID = model.ArtID,
                    ClientID = model.ClientID,
                    Price = model.Price,
                    Location = model.Location,
                    SellingPrice = model.SellingPrice,
                    VenderCommission = model.VenderCommission,
                    DateOfTransaction = model.DateOfTransaction,

                };

            using (var ctx = new ApplicationDbContext())
            {

                ctx.Sales.Add(entity);
                var id = entity.ArtID;
                SoldArtTrue(id);
                return ctx.SaveChanges() == 1;

            }

        }
            public bool SoldArtTrue(int id)
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Arts
                            .Single(e => e.ArtID == id && e.OwnerID == _userId);
                    entity.Sold = true;

                return ctx.SaveChanges() == 1;

                }
            }

            //REFACTOR I TRIED... 
            //using (var ctx = new ApplicationDbContext())
            //{
            //    ctx.Sales.Add(entity);
            //    //   entity.Art.Sold = true;
            //    _ = ctx.SaveChanges() == 1;
            //    entity.Art.Sold = true;
            //    return ctx.SaveChanges() == 1;
            //}

        //ANOTHER ATTEMPT AT SOLD = TRUE
        //public bool MarkArtAsSold()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            new ArtEdit()
        //            {
        //                Sold = true,
        //            };

        //        ctx.Arts.Add();
        //        return ctx.SaveChanges() == 1;

        //    }
        //}

        //public bool CreateSale(SaleCreate model)
        //{

        //                .Where(e => e.OwnerID == _userId && e.Art.Sold == false)
        //                .Select(
        //                     e =>
        //        new Sale()
        //        {
        //            OwnerID = _userId,
        //            ArtID = model.ArtID,
        //            ClientID = model.ClientID,
        //            Location = model.Location,
        //            ValuedAt = model.ValuedAt,
        //            SellingPrice = model.SellingPrice,
        //            VenderCommission = model.VenderCommission,
        //            DateOfTransaction = model.DateOfTransaction,

        //        };



        //            ctx.Sales.Add(e);
        //            return ctx.SaveChanges() == 1;
        //        }
        //    }
        //    }

        public IEnumerable<SaleListItem> GetSale()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sales
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new SaleListItem
                                {
                                    SaleID = e.SaleID,
                                    ArtID = e.ArtID,
                                    ClientID = e.ClientID,
                                    Location = e.Location,
                                    Price = e.Price,
                                    SellingPrice = e.SellingPrice,
                                    VenderCommission = e.VenderCommission,
                                    DateOfTansaction = e.DateOfTransaction,
                                    Size = e.Art.Size,
                                }
                        );

                return query.ToArray();
            }
        }

        public SaleDetail GetSaleByID(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sales
                    .Single(e => e.SaleID == id && e.OwnerID == _userId);

                return
                    new SaleDetail
                    {
                        SaleID = entity.SaleID,
                        ArtID = entity.ArtID,
                        ClientID = entity.ClientID,
                        FullName = entity.Client.FullName,
                        Title = entity.Art.Title,
                        Location = entity.Location,
                        Price = entity.Price,
                        SellingPrice = entity.SellingPrice,
                        VenderCommission = entity.VenderCommission,
                        DateOfTransaction = entity.DateOfTransaction,

                    };
            }
        }

        public bool UpdateSale(SaleEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Sales
                        .Single(e => e.SaleID == model.SaleID && e.OwnerID == _userId);
                //entity.ArtID = model.ArtID;
                //entity.ClientID = model.ClientID;
                entity.Location = model.Location;
                entity.Price = model.Price;
                entity.SellingPrice = model.SellingPrice;
                entity.VenderCommission = model.VenderCommission;
                entity.DateOfTransaction = model.DateOfTransaction;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteSale(int saleId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                      ctx
                      .Sales
                      .Single(e => e.SaleID == saleId && e.OwnerID == _userId);

                ctx.Sales.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
