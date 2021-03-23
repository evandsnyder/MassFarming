﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Farm> Farms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<FarmCategory> FarmCategories { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
