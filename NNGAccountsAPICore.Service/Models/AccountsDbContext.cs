using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NNGAccountsAPICore.Service.Models
{
    public partial class AccountsDbContext : DbContext
    {
        private readonly string _connectionString;

        public AccountsDbContext()
        {
           // _connectionString = cnString;
        }

        public AccountsDbContext(DbContextOptions<AccountsDbContext> options)
            : base(options)
        {
        }        

        public virtual DbSet<MenuAssign> MenuAssigns { get; set; } = null!;
        public virtual DbSet<MenuMaster> MenuMasters { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProject> UserProjects { get; set; } = null!;
        public virtual DbSet<ZoneMst> ZoneMsts { get; set; } = null!;
        public virtual DbSet<GLMst> GLMsts { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.

                //optionsBuilder.UseSqlServer("Data Source=172.20.3.152\\MSSQL2017;Initial Catalog=NNGAccounts;Uid = sa; Password = aA@01737918236;");
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GLMst>().ToTable("tblGLMst");
            modelBuilder.HasDefaultSchema("webappsbd");

            modelBuilder.Entity<MenuAssign>(entity =>
            {
                entity.ToTable("MenuAssign", "dbo");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Permission)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");
            });

            modelBuilder.Entity<MenuMaster>(entity =>
            {
                entity.ToTable("MenuMaster", "dbo");

                entity.Property(e => e.ArrowIcon)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDt).HasColumnType("datetime");

                entity.Property(e => e.MenuIcon)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ParentName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sorting)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDt).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Projects", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DatabaseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCompanyAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCompanyPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayCompanyRemark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrjUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PrjURL");

                entity.Property(e => e.ProgramName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sqlpassword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SQLPassword");

                entity.Property(e => e.SqlserverName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SQLServerName");

                entity.Property(e => e.SqluserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SQLUserName");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "dbo");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CompId).HasColumnName("CompID");

                entity.Property(e => e.ComputerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeptId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DeptID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmailUserId).HasColumnName("EmailUserID");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ipaddress)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("IPAddress");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogin)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ZoneId).HasColumnName("ZoneID");
            });

            modelBuilder.Entity<UserProject>(entity =>
            {
                entity.ToTable("UserProject", "dbo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<ZoneMst>(entity =>
            {
                entity.HasKey(e => e.Zid)
                    .HasName("PK_tblZoneMst");

                entity.ToTable("ZoneMst", "dbo");

                entity.Property(e => e.Zid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZID");

                entity.Property(e => e.CsuperId).HasColumnName("CSuperID");

                entity.Property(e => e.SuperId).HasColumnName("SuperID");

                entity.Property(e => e.SzdPass)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zname)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ZName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
