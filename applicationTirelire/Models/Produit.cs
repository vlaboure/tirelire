namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Produit")]
    public partial class Produit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produit()
        {
            Avis = new HashSet<Avi>();
            DetailCommandes = new HashSet<DetailCommande>();
        }

        [Key]
        public int IdProd { get; set; }

        public string nomProd { get; set; }

        public double? PrixProd { get; set; }

        public int statusProd { get; set; }

        public string UrlImage { get; set; }

        public string couleur { get; set; }

        public int? capacite { get; set; }

        public double poids { get; set; }

        public double? longeur { get; set; }

        public double? largeur { get; set; }

        public double? hauteur { get; set; }

        public int? IdFourn { get; set; }

        public int? Idcategorie { get; set; }

        [StringLength(200)]
        public string descriptionProd { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        public virtual Categorie Categorie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetailCommande> DetailCommandes { get; set; }

        public virtual Fournisseur Fournisseur { get; set; }
    }
}
