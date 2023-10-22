﻿using BookEcommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace BookEcommerce.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Translator> Translators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(b => b.Author).WithMany(a => a.Books)
                         .HasForeignKey(b => b.AuthorId);
            modelBuilder.Entity<Book>().HasOne(b => b.Publisher).WithMany(a => a.Books)
                         .HasForeignKey(b => b.PublisherId);
            modelBuilder.Entity<Book>().HasOne(b => b.Translator).WithMany(a => a.Books)
                         .HasForeignKey(b => b.TranslatorId);

            modelBuilder.Entity<Book>().ToTable(nameof(Book));
            modelBuilder.Entity<Author>().ToTable(nameof(Author));
            modelBuilder.Entity<Publisher>().ToTable(nameof(Publisher));
            modelBuilder.Entity<Translator>().ToTable(nameof(Translator));

        }
    }
}
