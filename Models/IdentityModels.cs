using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AvengersUnityIdentity.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ICollection<Incident> Incidents { get; set; }
        public ICollection<Satisfaction> Satisfactions { get; set; }
        public ICollection<Rapport> Rapports { get; set; }

        public virtual Civil Civil { get; set; }

        public virtual Organisation Organisation { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Civil> Civils { get; set; }

        public DbSet<Organisation> Organisations { get; set; }

        public DbSet<Pays> Pays { get; set; }

        public DbSet<Heros> Heros { get; set; }

        public DbSet<Vilain> Vilains { get; set; }

        public DbSet<Incident> Incidents { get; set; }

        public DbSet<Mission> Missions { get; set; }

        public DbSet<Satisfaction> Satisfactions { get; set; }

        public DbSet<Rapport> Rapports { get; set; }

        public DbSet<Crise> Crises { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Configure Asp Net Identity Tables

            modelBuilder.Entity<Incident>()
              .HasRequired<ApplicationUser>(incident => incident.User)
              .WithMany(utilisateur => utilisateur.Incidents)
              .HasForeignKey<int>(utilisateur => utilisateur.UserId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rapport>()
              .HasRequired<ApplicationUser>(rapport => rapport.User)
              .WithMany(utilisateur => utilisateur.Rapports)
              .HasForeignKey<int>(utilisateur => utilisateur.UserId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Satisfaction>()
              .HasRequired<ApplicationUser>(satisfaction => satisfaction.User)
              .WithMany(utilisateur => utilisateur.Satisfactions)
              .HasForeignKey<int>(utilisateur => utilisateur.UserId)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mission>()
                .HasRequired(m => m.Satisfaction)
                .WithRequiredPrincipal(s => s.Mission);

        }

        public DbSet<CustomUserRole> CustomUserRoles { get; set; }

    }

    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}