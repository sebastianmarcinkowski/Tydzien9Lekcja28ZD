using System;
using InvoiceManager.Models.Domains;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace InvoiceManager.Models.Repositories
{
    public class ProductRepository
    {
        public List<Product> GetProducts()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Products.Single(x => x.Id == productId);
            }
        }

        public void Add(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Products.Add(product);

                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (var context = new ApplicationDbContext())
            {
                var productToUpdate = context.Products
                    .Single(x => x.Id == product.Id);

                productToUpdate.Name = product.Name;
                productToUpdate.Value = product.Value;

                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var product = GetProduct(id);

                    var productToDelete = context.Products
                        .Single(x => x.Id == id);

                    context.Products.Remove(productToDelete);

                    context.SaveChanges();
            }
        }
    }
}