using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4_MVC.Models
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBook> CustomerBooks { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerBook>()
               .HasOne(c => c.Customer)
               .WithMany(cb => cb.CustomerBooks)
               .HasForeignKey(ci => ci.CustomerId);

            modelBuilder.Entity<CustomerBook>()
              .HasOne(c => c.Book)
               .WithMany(cb => cb.CustomerBooks)
               .HasForeignKey(ci => ci.BookId);

            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 1, FirstName = "Fredrik", LastName = "Efternamnsson", Email = "Fredrik.Efternamnsson@gmail.com", PhoneNumber = "076-111-22-33"});
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 2, FirstName = "Jonas", LastName = "Johansson", Email = "Jonas.Johansson@gmail.com", PhoneNumber = "076-222-33-44" });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 3, FirstName = "Per", LastName = "Persson", Email = "Per.Persson@gmail.com", PhoneNumber = "076-333-44-55" });
            modelBuilder.Entity<Customer>().HasData(new Customer { CustomerId = 4, FirstName = "Erika", LastName = "Eriksson", Email = "Erika.Eriksson@gmail.com", PhoneNumber = "076-444-55-66" });

            modelBuilder.Entity<Book>().HasData(new Book { BookId = 1, Title = "ATerribleBook", Description = "Do not read this terrible book", Author = "Hans Hansson", Pages = 452});
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 2, Title = "ASlightlyBetterBook", Description = "A bad book, read if you´re bored", Author = "Bertil Jonsson", Pages = 321 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 3, Title = "APrettyDecentBook", Description = "A pretty good book, read if you have time", Author = "Daniel Danielsson", Pages = 494 });
            modelBuilder.Entity<Book>().HasData(new Book { BookId = 4, Title = "AGreatBook", Description = "A great book, read it now", Author = "Gabriel Gabrielsson", Pages = 678 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
