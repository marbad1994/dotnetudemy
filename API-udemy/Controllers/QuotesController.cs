using System;
using System.Collections.Generic;
using System.Web.Http;
using APIudemy.Models;
using APIudemy.Data;
using System.Linq;

namespace APIudemy.Controllers
{
    public class QuotesController : ApiController
     {
        QuotesDbContext quotesDbContext = new QuotesDbContext();
        static List<Quote> _quotes = new List<Quote>()
        {
        new Quote(){Id = 0, Author = "Einstein", Description = "Imagination Desc", Title = "Imagination"},
        new Quote(){Id = 1, Author = "Einstein2", Description = "Imagination Des2c", Title = "Imagination2"},

        };

        public IHttpActionResult Get()
        {
            var quotes = quotesDbContext.Quotes;
            return Ok(quotes);
        }
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote==null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        public IHttpActionResult Post([FromBody]Quote quote)
        {
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(System.Net.HttpStatusCode.Created);
        }

        public IHttpActionResult Put(int id, [FromBody]Quote quote)
        {
            var entity = quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if (entity==null)
            {
                return BadRequest("No reqord found against this id");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            quotesDbContext.SaveChanges();
            return Ok("Record updated successfully...");

        }
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote==null)
            {
                return BadRequest("No record found against this id");
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Quote deleted");
        }
    }


}
