using InvoiceManager.Models.Domains;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Invoices = new Collection<Invoice>();
            Clients = new Collection<Client>();
        }

        public string Name { get; set; }
        public int AddressId { get; set; }
        public string Nip { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Address Address { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Client> Clients { get; set; }
    }
}