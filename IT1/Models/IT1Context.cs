﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT1.Models
{
    public class IT1Context : DbContext
    {
        private IConfigurationRoot _config;
        public DbSet<Experience> Experiences { get; set; }

        public IT1Context(IConfigurationRoot config, DbContextOptions<IT1Context> options)
            : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:SqlConnection"]);
        }
    }
}
