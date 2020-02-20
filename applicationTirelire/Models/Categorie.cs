namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Categorie")]
    public partial class Categorie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Categorie()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategorie { get; set; }

        [Column("Categorie")]
        [StringLength(35)]
        [Display(Name ="Categorie")]
        public string _Categorie { get; set; }
        public string UrlImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
