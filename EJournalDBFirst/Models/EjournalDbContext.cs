using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EJournalDBFirst.Models;

public partial class EjournalDbContext : DbContext
{
    public EjournalDbContext()
    {
    }

    public EjournalDbContext(DbContextOptions<EjournalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountSpecialization> AccountSpecializations { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Issue> Issues { get; set; }

    public virtual DbSet<Major> Majors { get; set; }

    public virtual DbSet<RequestDetail> RequestDetails { get; set; }

    public virtual DbSet<RequestReview> RequestReviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLExpress;user id=sa;password=123;Database=EJournalDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasIndex(e => e.Email, "IX_Accounts_Email").IsUnique();

            entity.HasIndex(e => e.RoleId, "IX_Accounts_RoleId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AccountSpecialization>(entity =>
        {
            entity.HasKey(e => new { e.AccountId, e.SpecializationId });

            entity.HasIndex(e => e.SpecializationId, "IX_AccountSpecializations_SpecializationId");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountSpecializations).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.Specialization).WithMany(p => p.AccountSpecializations).HasForeignKey(d => d.SpecializationId);
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasIndex(e => e.IssueId, "IX_Articles_IssueId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Issue).WithMany(p => p.Articles).HasForeignKey(d => d.IssueId);
        });

        modelBuilder.Entity<Issue>(entity =>
        {
            entity.ToTable("Issue");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<Major>(entity =>
        {
            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
        });

        modelBuilder.Entity<RequestDetail>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_RequestDetails_AccountId");

            entity.HasIndex(e => e.RequestReviewId, "IX_RequestDetails_RequestReviewId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Account).WithMany(p => p.RequestDetails).HasForeignKey(d => d.AccountId);

            entity.HasOne(d => d.RequestReview).WithMany(p => p.RequestDetails).HasForeignKey(d => d.RequestReviewId);
        });

        modelBuilder.Entity<RequestReview>(entity =>
        {
            entity.HasIndex(e => e.ArticleId, "IX_RequestReviews_ArticleId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Article).WithMany(p => p.RequestReviews).HasForeignKey(d => d.ArticleId);
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.HasIndex(e => e.MajorId, "IX_Specializations_MajorId");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Major).WithMany(p => p.Specializations).HasForeignKey(d => d.MajorId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
