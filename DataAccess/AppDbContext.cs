﻿using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
	public class AppDbContext : IdentityDbContext<Person, AppRole, Guid>
	{
		public AppDbContext() : base()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				IConfigurationRoot configuration = new ConfigurationBuilder()
				   .SetBasePath(Directory.GetCurrentDirectory())
				   .AddJsonFile("appsettings.json")
				   .Build();
				var connectionString = configuration.GetConnectionString("SqlConnection");
				optionsBuilder.UseNpgsql(connectionString);
			}
		}

        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			SeedData(builder);
		}

        private void SeedData(ModelBuilder modelBuilder)
		{
			// Seed data 
			modelBuilder.Entity<Person>().HasData(
				new Person
				{
					Id = Guid.NewGuid(),
					AccessFailedCount = 0,
					BirthDate = DateTime.UtcNow,
					ConcurrencyStamp = Guid.NewGuid().ToString(),
					UserName = "example@example.com",
					Grade = 12,
					Branch = "B",
					NormalizedUserName = "EXAMPLE@EXAMPLE.COM",
					Email = "example@example.com",
					NormalizedEmail = "EXAMPLE@EXAMPLE.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<Person>().HashPassword(null, "123456789"),
					LockoutEnd = DateTime.MaxValue,
					LockoutEnabled = false,
					SecurityStamp = Guid.NewGuid().ToString(),
					TwoFactorEnabled = false,
					Name = "Sabit",
					Surname = "Ünsür",
					PhoneNumber = "+905423849022",
					PhoneNumberConfirmed = true,
					StudentNumber = 653,
					TermId = 1,
				}
			); ;

			modelBuilder.Entity<Term>().HasData(
				new Term
				{
					Id = 1,
					EndDate = DateTime.MaxValue,
					StartDate = DateTime.UtcNow,
				}
			);
        }


		public DbSet<Person> Persons { get; set; }
		public DbSet<Attendance> Attendances { get; set; }
		public DbSet<Term> Terms { get; set; }
	}
}
