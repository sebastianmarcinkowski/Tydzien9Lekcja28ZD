using System;
using InvoiceManager.Models.Domains;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoiceManager.Models.Repositories
{
    public class ClientRepository
    {
        public List<Client> GetClients(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients
                    .Include(x => x.Address)
                    .Where(x => x.UserId == userId)
                    .ToList();
            }
        }

        public Client GetClient(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Clients
                    .Include(x => x.Address)
                    .Include(x => x.Invoices)
                    .Single(x => x.UserId == userId && x.Id == id);
            }
        }

        public void Add(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Clients.Add(client);

                context.SaveChanges();
            }
        }

        public void Update(Client client)
        {
            using (var context = new ApplicationDbContext())
            {
                var clientToUpdate = context.Clients
                    .Single(x =>
                        x.Id == client.Id
                        && x.UserId == client.UserId);

                clientToUpdate.Name = client.Name;
                clientToUpdate.Email = client.Email;
                clientToUpdate.Nip = client.Nip;
                clientToUpdate.Address = client.Address;

                context.SaveChanges();
            }
        }

        public void Delete(int id, string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var client = GetClient(id, userId);

                if (!client.Invoices.Any())
                {
                    var clientToDelete = context.Clients
                        .Single(x =>
                            x.Id == id
                            && x.UserId == userId);

                    context.Clients.Remove(clientToDelete);

                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Usuwanie nie powiodło się, klient posiada faktury!");
                }

            }
        }
    }
}