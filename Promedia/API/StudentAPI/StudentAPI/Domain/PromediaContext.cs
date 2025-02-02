using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentAPI.Domain.Entities;

namespace StudentAPI.Domain;

public partial class PromediaContext : DbContext
{
	public PromediaContext()
	{
	}

	public PromediaContext(DbContextOptions<PromediaContext> options)
		: base(options)
	{
	}

	public virtual DbSet<Student> Students { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
		=> optionsBuilder.UseSqlServer("Server=.; Database=Promedia; Trusted_Connection=True; TrustServerCertificate=True");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Student>(entity =>
		{
			entity.HasKey(e => e.Id).HasName("PK__Student__3214EC075452EAD4");

			entity.ToTable("Student");

			entity.Property(e => e.Address).HasMaxLength(50);
			entity.Property(e => e.FirstName).HasMaxLength(20);
			entity.Property(e => e.Gender)
				.HasMaxLength(1)
				.IsUnicode(false)
				.IsFixedLength();
			entity.Property(e => e.LastName).HasMaxLength(20);
			entity.Property(e => e.NationalId)
				.HasMaxLength(14)
				.IsUnicode(false)
				.IsFixedLength();
		});

		OnModelCreatingPartial(modelBuilder);
	}

	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
