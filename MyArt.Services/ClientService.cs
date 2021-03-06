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
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    ZipCode = model.ZipCode,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Clients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ClientListItem> GetClient()
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
                                    FirstName = e.FirstName,
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
                        Email = entity.Email,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,

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
                entity.Email = model.Email;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;

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
