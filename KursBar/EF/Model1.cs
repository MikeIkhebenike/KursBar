namespace KursBar.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Autorization> Autorization { get; set; }
        public virtual DbSet<Categorical> Categorical { get; set; }
        public virtual DbSet<Hardware> Hardware { get; set; }
        public virtual DbSet<IT_Employees> IT_Employees { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<Quest> Quest { get; set; }
        public virtual DbSet<Repair> Repair { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypeOfProblem> TypeOfProblem { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorical>()
                .HasMany(e => e.Quest)
                .WithOptional(e => e.Categorical)
                .HasForeignKey(e => e.ID_Категоричность);

            modelBuilder.Entity<Hardware>()
                .HasMany(e => e.Quest)
                .WithOptional(e => e.Hardware)
                .HasForeignKey(e => e.ID_Оборудования);

            modelBuilder.Entity<IT_Employees>()
                .HasMany(e => e.Repair)
                .WithOptional(e => e.IT_Employees)
                .HasForeignKey(e => e.ID_Сотрудники_ИТ);

            modelBuilder.Entity<Office>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Office)
                .HasForeignKey(e => e.ID_Office)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Repair>()
                .HasMany(e => e.Hardware)
                .WithOptional(e => e.Repair)
                .HasForeignKey(e => e.ID_Ремонт);

            modelBuilder.Entity<TypeOfProblem>()
                .HasMany(e => e.Quest)
                .WithOptional(e => e.TypeOfProblem)
                .HasForeignKey(e => e.ID_ТипПроблемы);

            modelBuilder.Entity<User>()
                .Property(e => e.Пол)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Autorization)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Quest)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.ID_User);
        }
    }
}
