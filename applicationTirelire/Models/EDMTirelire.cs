namespace applicationTirelire.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EDMTirelire : DbContext
    {
        public EDMTirelire()
            : base("name=EDMTirelire")
        {
        }

        public virtual DbSet<Avi> Avis { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Commande> Commandes { get; set; }
        public virtual DbSet<DetailCommande> DetailCommandes { get; set; }
        public virtual DbSet<Facture> Factures { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Produit> Produits { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>()
                .HasMany(e => e.Produits)
                .WithOptional(e => e.Categorie)
                .HasForeignKey(e => e.Idcategorie);

            modelBuilder.Entity<Commande>()
                .HasMany(e => e.Factures)
                .WithRequired(e => e.Commande)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fournisseur>()
                .Property(e => e.telephoneFourn)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.sexe)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Commandes)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Role>()
               .Property(e => e.RoleAttribut)
               .IsFixedLength();
        }
    }
}
