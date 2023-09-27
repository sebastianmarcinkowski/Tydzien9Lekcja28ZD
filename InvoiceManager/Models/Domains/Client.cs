using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace InvoiceManager.Models.Domains
{
    public class Client
    {
        public Client()
        {
            Invoices = new Collection<Invoice>();
        }

        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        [Required(ErrorMessage = "Pole E-mail jest wymagane.")]
        public string Email { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        [Display(Name = "NIP")]
        public string Nip { get; set; }

        public Address Address { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}