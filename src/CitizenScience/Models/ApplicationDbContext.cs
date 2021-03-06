﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CitizenScience.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Fauna> Faunas {get;set;}


        public ApplicationDbContext()
        {
 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=tcp:citizenscience4dbserver.database.windows.net,1433;Initial Catalog=CitizenScience4_db;User Id=brianpritt@citizenscience4dbserver;Password=!Selfdestruct1");
            //Server = (localdb)\mssqllocaldb; Database = CitizenScience; integrated security = True
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}