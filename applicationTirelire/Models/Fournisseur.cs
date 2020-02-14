namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fournisseur")]
    public partial class Fournisseur 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fournisseur()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        public int IdFourn { get; set; }

        [Required]
        [StringLength(30)]
        public string nomFourn { get; set; }

        public string descriptionFourn { get; set; }

        [Required]
        [StringLength(15)]
        public string telephoneFourn { get; set; }

        [StringLength(15)]
        public string paysFourn { get; set; }

        [StringLength(20)]
        public string villeFourn { get; set; }

        [StringLength(50)]
        public string adresseFourn { get; set; }

        public int? codePostal { get; set; }

        [StringLength(30)]
        public string emailFourn { get; set; }

        public int Statut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
