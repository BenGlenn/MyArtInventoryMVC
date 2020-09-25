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
    public class ClientService
    {
        private readonly Guid _userId;

        public ClientService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateClient(ClientCreate model)
        {
            var entity =
                new Client()
                {
                    OwnerID = _userId,
                    Collector = model.Collector,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ClientListItem> GetArt()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Clients
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new ClientListItem
                                {
                                    ClientID = e.ClientID,
                                    Collector = e.Collector,
                                    FistName = e.FirstName,
                                    LastName = e.LastName,
                                

                                }
                        );

                return query.ToArray();
            }
        }

        public ClientDetail GetClientByID(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == id && e.OwnerID == _userId);
                return
                    new ClientDetail
                    {
                        ClientID = entity.ClientID,
                        Collector = entity.Collector,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,

                    };
            }
        }

        public bool UpdateClient(ClientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == model.ClientID && e.OwnerID == _userId);
                entity.ClientID = model.ClientID;
                entity.Collector = model.Collector;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteClient(int clientId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Clients
                        .Single(e => e.ClientID == clientId && e.OwnerID == _userId);

                ctx.Clients.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
