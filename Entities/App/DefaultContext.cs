using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace MVC.Data.Entities.App
{
    public partial class DefaultContext : DbContext
    {
        public DefaultContext()
        {
        }

        public DefaultContext(DbContextOptions<DefaultContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<AppApplication> AppApplications { get; set; }
        public virtual DbSet<AppApplicationsPerson> AppApplicationsPersons { get; set; }
        public virtual DbSet<AppDepartment> AppDepartments { get; set; }
        public virtual DbSet<AppHistory> AppHistories { get; set; }
        public virtual DbSet<AppLog> AppLogs { get; set; }
        public virtual DbSet<AppModule> AppModules { get; set; }
        public virtual DbSet<AppPerson> AppPersons { get; set; }
        public virtual DbSet<AppPosition> AppPositions { get; set; }
        public virtual DbSet<AppPrivilege> AppPrivileges { get; set; }
        public virtual DbSet<AppPrivilegesRule> AppPrivilegesRules { get; set; }
        public virtual DbSet<AppResetAccount> AppResetAccounts { get; set; }
        public virtual DbSet<AppRule> AppRules { get; set; }
        public virtual DbSet<AppRulesPerson> AppRulesPersons { get; set; }
        public virtual DbSet<VtDependency> VtDependencies { get; set; }
        public virtual DbSet<VtPerson> VtPersons { get; set; }
        public virtual DbSet<VtPrivilegesPerson> VtPrivilegesPersons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile(path, optional: false)
                 .Build();
            
            
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                 /*.AddJsonFile("appsettings.{envName}.json", optional: false)
                 .AddJsonFile($"appsettings.{envName}.json", optional: false)
                 .Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SAMConnection"));
            }
            */
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = $"appsettings.{envName}.json";
            filename = filename.Replace("..", ".");
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                 .AddJsonFile(filename, optional: false)
                 .Build();

            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SAMConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AppApplication>(entity =>
            {
                entity.HasKey(e => e.IdApplication);

                entity.ToTable("App_Applications");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("Descripción de la Aplicación");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Imagen o Icono de la Aplicación");

                entity.Property(e => e.NumOrder).HasComment("Orden en que será mostrada en la interface");

                entity.Property(e => e.OfflineMessage).HasMaxLength(500);

                entity.Property(e => e.Status).HasComment("Estatus del registro");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Título o Nombre principal de la Aplicación");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("URL")
                    .HasComment("URL de acceso a la Aplicación");
            });

            modelBuilder.Entity<AppApplicationsPerson>(entity =>
            {
                entity.HasKey(e => new { e.IdApplication, e.IdPerson });

                entity.ToTable("App_ApplicationsPersons");

                entity.Property(e => e.IdApplication).HasComment("Id de la Aplicación");

                entity.Property(e => e.IdPerson).HasComment("Id de la Persona");

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany(p => p.AppApplicationsPeople)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_ApplicationsPersons_App_Applications");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.AppApplicationsPeople)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_ApplicationsPersons_App_Persons");
            });

            modelBuilder.Entity<AppDepartment>(entity =>
            {
                entity.HasKey(e => e.IdDepartment);

                entity.ToTable("App_Department");

                entity.Property(e => e.IdDepartment).HasComment("Id autonumérico de cada departamento");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComment("Descripción del departamento");

                entity.Property(e => e.IdDependency).HasComment("Id de la Dependencia relacionada al departamento");

                entity.Property(e => e.Status).HasComment("Status del registro");
            });

            modelBuilder.Entity<AppHistory>(entity =>
            {
                entity.HasKey(e => e.IdHistory);

                entity.ToTable("App_History");

                entity.Property(e => e.IdHistory).HasComment("Id autonumérico del Historial de eventos");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasComment("Fecha de creación del historial");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasComment("Descripcion detallada del Historial");

                entity.Property(e => e.HostName)
                    .HasMaxLength(100)
                    .HasComment("Nombre del equipo que registra el evento");

                entity.Property(e => e.IdLog).HasComment("Id relacionado al evento del histórico");

                entity.Property(e => e.IdPerson).HasComment("Id relacionado a la Persona que registra el Historial");

                entity.Property(e => e.Ipclient)
                    .HasMaxLength(20)
                    .HasColumnName("IPClient")
                    .HasComment("Dirección IP del equipo donde se registra el evento");

                entity.HasOne(d => d.IdLogNavigation)
                    .WithMany(p => p.AppHistories)
                    .HasForeignKey(d => d.IdLog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_History_App_Logs");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.AppHistories)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_History_App_Persons");
            });

            modelBuilder.Entity<AppLog>(entity =>
            {
                entity.HasKey(e => e.IdLog);

                entity.ToTable("App_Logs");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<AppModule>(entity =>
            {
                entity.HasKey(e => e.IdModule);

                entity.ToTable("App_Modules");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany(p => p.AppModules)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_Modules_App_Applications");
            });

            modelBuilder.Entity<AppPerson>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                entity.ToTable("App_Persons");

                entity.Property(e => e.IdPerson).HasComment("Id Principal que identifica a cada Persona");

                entity.Property(e => e.Celphone).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.IdDepartment).HasComment("Departamento de la Persona");

                entity.Property(e => e.IdPosition).HasComment("Puesto de la Persona");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .HasComment("Imagen de la Persona");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("Nombre completo");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasComment("Contraseña encriptada");

                entity.Property(e => e.PwdTemp)
                    .HasMaxLength(100)
                    .HasComment("Password temporal desencriptado");

                entity.Property(e => e.Surnames)
                    .HasMaxLength(200)
                    .HasComment("Apellidos");

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(70)
                    .HasComment("Cuenta de usuario");

                entity.HasOne(d => d.IdDepartmentNavigation)
                    .WithMany(p => p.AppPeople)
                    .HasForeignKey(d => d.IdDepartment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_Persons_App_Department");

                entity.HasOne(d => d.IdPositionNavigation)
                    .WithMany(p => p.AppPeople)
                    .HasForeignKey(d => d.IdPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_Persons_App_Positions");
            });

            modelBuilder.Entity<AppPosition>(entity =>
            {
                entity.HasKey(e => e.IdPosition);

                entity.ToTable("App_Positions");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<AppPrivilege>(entity =>
            {
                entity.HasKey(e => e.IdPrivilege);

                entity.ToTable("App_Privileges");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Divider).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Rules)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.AppPrivileges)
                    .HasForeignKey(d => d.IdModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_Privileges_App_Modules");
            });

            modelBuilder.Entity<AppPrivilegesRule>(entity =>
            {
                entity.HasKey(e => new { e.IdRule, e.IdPrivilege });

                entity.ToTable("App_PrivilegesRules");

                entity.HasOne(d => d.IdPrivilegeNavigation)
                    .WithMany(p => p.AppPrivilegesRules)
                    .HasForeignKey(d => d.IdPrivilege)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_PrivilegesRules_App_Privileges");

                entity.HasOne(d => d.IdRuleNavigation)
                    .WithMany(p => p.AppPrivilegesRules)
                    .HasForeignKey(d => d.IdRule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_PrivilegesRules_App_Rules");
            });

            modelBuilder.Entity<AppResetAccount>(entity =>
            {
                entity.HasKey(e => e.IdResetAccount);

                entity.ToTable("App_ResetAccount");

                entity.Property(e => e.Deadline).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.ResetDate).HasColumnType("datetime");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.AppResetAccounts)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_ResetAccount_App_Persons");
            });

            modelBuilder.Entity<AppRule>(entity =>
            {
                entity.HasKey(e => e.IdRule);

                entity.ToTable("App_Rules");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdApplicationNavigation)
                    .WithMany(p => p.AppRules)
                    .HasForeignKey(d => d.IdApplication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_Rules_App_Applications");
            });

            modelBuilder.Entity<AppRulesPerson>(entity =>
            {
                entity.HasKey(e => new { e.IdRule, e.IdPerson })
                    .HasName("PK_App_RulesPerson");

                entity.ToTable("App_RulesPersons");

                entity.HasOne(d => d.IdPersonNavigation)
                    .WithMany(p => p.AppRulesPeople)
                    .HasForeignKey(d => d.IdPerson)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_RulesPersons_App_Persons");

                entity.HasOne(d => d.IdRuleNavigation)
                    .WithMany(p => p.AppRulesPeople)
                    .HasForeignKey(d => d.IdRule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_App_RulesPersons_App_Rules");
            });

            modelBuilder.Entity<VtDependency>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vt_Dependencies");

                entity.Property(e => e.Cargo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CARGO");

                entity.Property(e => e.ClvDependencia)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLV_DEPENDENCIA");

                entity.Property(e => e.ClvUniadm)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CLV_UNIADM");

                entity.Property(e => e.Dependencia)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("DEPENDENCIA");

                entity.Property(e => e.Funcionario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FUNCIONARIO");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Status).HasColumnName("STATUS");
            });

            modelBuilder.Entity<VtPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vt_Persons");

                entity.Property(e => e.Celphone).HasMaxLength(50);

                entity.Property(e => e.ClvDependency)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("Clv_Dependency");

                entity.Property(e => e.DepartmentName).HasMaxLength(150);

                entity.Property(e => e.DependencyName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.PositionName).HasMaxLength(250);

                entity.Property(e => e.Surnames).HasMaxLength(200);

                entity.Property(e => e.Telephone).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(70);
            });

            modelBuilder.Entity<VtPrivilegesPerson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Vt_PrivilegesPersons");

                entity.Property(e => e.ApplicationName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Divider).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.ImageModule).HasMaxLength(50);

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RuleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Rules)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Surnames).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .HasColumnName("URL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
