namespace DB_Exaample.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Astronaut> Astronauts { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Astronaut>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Astronaut)
                .HasForeignKey(e => e.AID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.Astronauts)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.NID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mission>()
                .HasMany(e => e.Crews)
                .WithRequired(e => e.Mission)
                .HasForeignKey(e => e.MID)
                .WillCascadeOnDelete(false);
        }
    }
}
