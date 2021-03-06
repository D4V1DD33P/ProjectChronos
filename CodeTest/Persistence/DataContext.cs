﻿using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Style> Styles { get; set; }

        public DbSet<StyleOption> StyleOptions { get; set; }

    }
}
