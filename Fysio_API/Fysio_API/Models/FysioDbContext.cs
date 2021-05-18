﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fysio_API.Models
{
    public class FysioDbContext : DbContext
    {
        public FysioDbContext(DbContextOptions<FysioDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientExercise> ClientExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
    }
}
