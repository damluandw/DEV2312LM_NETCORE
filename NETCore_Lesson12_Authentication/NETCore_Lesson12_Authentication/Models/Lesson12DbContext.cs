﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NETCore_Lesson12_Authentication.Models;

public partial class Lesson12DbContext : DbContext
{
    public Lesson12DbContext()
    {
    }

    public Lesson12DbContext(DbContextOptions<Lesson12DbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQL2014;Database=Lesson12Db;Trusted_Connection=True;MultipleActiveResultSets=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
