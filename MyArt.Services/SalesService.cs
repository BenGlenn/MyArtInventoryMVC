﻿using MyArt.Data;
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
        private ApplicationDbContext _db = new ApplicationDbContext();

        private readonly Guid _userId;

        public SalesService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSale(SaleCreate model)
        {
           // Art art = _db.Arts.Find(model.ArtID);
           // Client client = _db.Clients.Find(model.ClientID);
           //while art !== null && client !== null 
            var entity =
                new Sale()
                {
                    OwnerID = _userId,
                    ArtID = model.ArtID,
                    ClientID = model.ClientID,
                    Location = model.Loccation,
                    ValuedAt = model.ValuedAt,
                    SellingPrice = model.SellingPrice,
                    VenderCommission = model.VenderCommission,
                    DateOfTransaction = model.DateOfTransaction,
                 
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sales.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

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
                                   SaleID = e.SaleId,
                                   ArtID = e.ArtID,
                                   ClientID = e.ClientID,
                                   Location = e.Location,
                                   ValuedAt = e.ValuedAt,
                                   SellingPrice = e.SellingPrice,
                                   VenderCommission = e.VenderCommission,
                                   DateOfTansaction = e.DateOfTransaction,
                                   Size = e.Art.Size,
                                }
                        );

                return query.ToArray();
            }
        }


    }
}
