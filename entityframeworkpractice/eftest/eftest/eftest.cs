namespace eftest
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class eftestContext : DbContext
    {
        public eftestContext()
            : base("name=eftest")
        {
        }

        public virtual DbSet<Student1> Student1 { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student1>()
                .Property(e => e.ID)
                .IsFixedLength();

            modelBuilder.Entity<Student1>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Student1>()
                .Property(e => e.Course)
                .IsFixedLength();

            modelBuilder.Entity<Student1>()
                .Property(e => e.Score)
                .IsFixedLength();

            modelBuilder.Entity<User>()
            .Property(u => u.DisplayName)
            .HasColumnName("display_name");
        }
    }
    
}
