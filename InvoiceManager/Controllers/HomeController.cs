using InvoiceManager.Models.Domains;
using InvoiceManager.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InvoiceManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = 1,
                    Title = "Fa/01/2020",
                    CratedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 999,
                    Client = new Client { Name = "Klient 1" }
                },
                new Invoice
                {
                    Id = 2,
                    Title = "Fa/02/2020",
                    CratedDate = DateTime.Now,
                    PaymentDate = DateTime.Now,
                    Value = 123.97m,
                    Client = new Client { Name = "Klient 2" }
                }
            };

            return View(invoices);
        }

        public ActionResult Invoice(int id = 0)
        {
            EditInvoiceViewModel vm = null;

            if (id == 0)
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient 1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Dodawanie faktury",
                    Invoice = new Invoice()
                };
            }
            else
            {
                vm = new EditInvoiceViewModel
                {
                    Clients = new List<Client> { new Client { Id = 1, Name = "Klient 1" } },
                    MethodOfPayments = new List<MethodOfPayment> { new MethodOfPayment { Id = 1, Name = "Przelew" } },
                    Heading = "Edycja faktury",
                    Invoice = new Invoice
                    {
                        ClientId = 1,
                        Comments = "-- UWAGI --",
                        CratedDate = DateTime.Now,
                        PaymentDate = DateTime.Now,
                        MethodOfPaymentId = 1,
                        Id = 1,
                        Value = 100,
                        Title = "FA/10/2020",
                        InvoicePositions = new List<InvoicePosition>
                        {
                            new InvoicePosition
                            {
                                Id = 1,
                                Lp = 1,
                                Product = new Product { Name = "Produkt" },
                                Quantity = 2,
                                Value = 50
                            },
                            new InvoicePosition
                            {
                                Id = 2,
                                Lp = 2,
                                Product = new Product { Name = "Produkt 222" },
                                Quantity = 3,
                                Value = 520
                            }
                        }
                    }
                };
            }
            return View(vm);
        }

        public ActionResult InvoicePosition(int invoiceId, int invoicePositionId = 0)
        {
            EditInvoicePositionViewModel vm = null;

            if (invoicePositionId == 0)
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition(),
                    Heading = "Dodawanie nowej pozycji",
                    Products = new List<Product>
                    {
                        new Product { Id = 1, Name = "Produkt 1" },
                        new Product { Id = 2, Name = "Produkt 2" }
                    }
                };
            }
            else
            {
                vm = new EditInvoicePositionViewModel
                {
                    InvoicePosition = new InvoicePosition
                    {
                        Lp = 1,
                        Value = 100,
                        Quantity = 2,
                        ProductId = 1
                    },
                    Heading = "Edycja pozycji",
                    Products = new List<Product>
                    {
                        new Product { Id = 1, Name = "Produkt 1" },
                        new Product { Id = 2, Name = "Produkt 2" }
                    }
                };
            }

            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}