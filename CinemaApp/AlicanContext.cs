using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using CinemaApp.Models;


namespace CinemaApp
{
    public class AlicanContext : DbContext
    {
        public AlicanContext() : base("AlicanConnection") { }


        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<EmailFormModel> EmailFormModels { get; set; }
        public DbSet<ReservedSeat> ReservedSeats { get; set; }
        public DbSet<Screen1> Screen1 { get; set; }
        public DbSet<Screen12> Screen12 { get; set; }
        public DbSet<Screen13> Screen13 { get; set; }
        public DbSet<Screen2> Screen2 { get; set; }
        public DbSet<Screen22> Screen22 { get; set; }
        public DbSet<Screen23> Screen23 { get; set; }
        public DbSet<Screen3> Screen3 { get; set; }
        public DbSet<Screen32> Screen32 { get; set; }
        public DbSet<Screen33> Screen33 { get; set; }


    }

}