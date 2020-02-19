namespace Esempio1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MegaDb : DbContext
    {
        public MegaDb()
            : base("name=Mega")
        {
        }

        public virtual DbSet<utenti> utenti { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<utenti>()
                .Property(pippo => pippo.nome)
                .IsUnicode(false);

            modelBuilder.Entity<utenti>()
                .Property(e => e.cognome)
                .IsUnicode(false);

            modelBuilder.Entity<utenti>()
                .Property(e => e.indirizzo)
                .IsUnicode(false);
        }
    }
}
