using Microsoft.EntityFrameworkCore;

namespace WebApplication1
{
    // this is representing the database
    public class WhateverYouWantToCallDB : DbContext
    {
        //constructor
        public WhateverYouWantToCallDB(DbContextOptions options) 
            : base(options) {

        }
        // we have to set it
        public DbSet<Customers> Customer { get; set; }
    }
}