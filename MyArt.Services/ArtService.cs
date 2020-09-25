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
    public class ArtService
    {
        private readonly Guid _userId;

        public ArtService(Guid userId)
        {
            _userId = userId;
        }

    public bool CreateArt(ArtCreate model)
    {
        var entity =
            new Art()
            {
                OwnerID = _userId,
                Title = model.Title,
                DateOfCreation = model.DateOfCreation,
                Style = model.Style,
                Medium = model.Medium,
                Surface = model.Surface,
                Size = model.Size,
                Price = model.Price,
                Location = model.Location,
                Sold = model.Sold,
                Note = model.Note,
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Arts.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }

        public IEnumerable<ArtListItem> GetArt()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Arts
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ArtListItem
                                {
                                    ArtID = e.ArtID,
                                    Title = e.Title,
                                    DateOfCreation = e.DateOfCreation,
                                
                                }
                        );

                return query.ToArray();
            }
        }

        public ArtDetail GetArtById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Arts
                        .Single(e => e.ArtID == id && e.OwnerID == _userId);
                return
                    new ArtDetail
                    {
                       Title = entity.Title,
                       DateOfCreation = entity.DateOfCreation,
                       Style = entity.Style,
                       Medium = entity.Medium,
                       Surface = entity.Surface,
                       Size = entity.Size,
                       Price = entity.Price,
                       Location = entity.Location,
                       Sold = entity.Sold,
                    };
            }
        }

        public bool UpdateArt(ArtEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Arts
                        .Single(e => e.ArtID == model.ArtID && e.OwnerID == _userId);

                entity.Title = model.Title;
                entity.DateOfCreation = model.DateOfCreation;
                entity.Style = model.Style;
                entity.Medium = model.Medium;
                entity.Surface = model.Surface;
                entity.Size = model.Size;
                entity.Price = model.Price;
                entity.Location = model.Location;
                entity.Sold = model.Sold;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteArt(int artId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Arts
                        .Single(e => e.ArtID == artId && e.OwnerID == _userId);

                ctx.Arts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }



    }
}
