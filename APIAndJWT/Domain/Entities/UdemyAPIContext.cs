﻿using System;
using System.Collections.Generic;
using APIAndJWT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIAndJWT.Domain.Entities
{
    public partial class UdemyAPIContext : DbContext
    {
        public UdemyAPIContext()
        {
        }

        public UdemyAPIContext(DbContextOptions<UdemyAPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RUQVHMV\\SQLEXPRESS;Initial Catalog=UdemyAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.ToTable("Product");

            //    entity.Property(e => e.Category).HasMaxLength(50);

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.Property(e => e.Price).HasColumnType("money");
            //});

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.ToTable("User");

            //    entity.Property(e => e.Email).HasMaxLength(100);

            //    entity.Property(e => e.Name).HasMaxLength(50);

            //    entity.Property(e => e.Password).HasMaxLength(50);

            //    entity.Property(e => e.RefreshToken).HasMaxLength(500);

            //    entity.Property(e => e.RefreshTokenEndDate).HasColumnType("datetime");

            //    entity.Property(e => e.SurName).HasMaxLength(50);
            //});

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
