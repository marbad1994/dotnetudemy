using System;
using System.Data.Entity;
using APIudemy.Models;
namespace APIudemy.Data
{
    public class QuotesDbContext : DbContext
    {
       public DbSet<Quote> Quotes { get; set; }
    }
}
