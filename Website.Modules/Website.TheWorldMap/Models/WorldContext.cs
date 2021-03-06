﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.TheWorldMap.Models
{
    public class WorldContext:DbContext
    {
        private IConfigurationRoot _config;

        public WorldContext(IConfigurationRoot configure, DbContextOptions options) 
            : base(options)
        {
            _config = configure;
        }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
        }

    }
}
