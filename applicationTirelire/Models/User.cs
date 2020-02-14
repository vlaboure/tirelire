namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Avis = new HashSet<Avi>();
            Commandes = new HashSet<Commande>();
        }

     
        [Key]
        public int IdUser { get; set; }

        [Required]
        [StringLength(30)]
        public string nomUser { get; set; }

        [StringLength(20)]
        public string PrenomUser { get; set; }

        [StringLength(1)]
        public string sexe { get; set; }

        [Required]
        [StringLength(30)]
        public string emailUser { get; set; }

        [StringLength(15)]
        public string telephoneUser { get; set; }

        [StringLength(15)]
        public string paysUser { get; set; }

        [StringLength(20)]
        public string villeUser { get; set; }

        [StringLength(50)]
        public string adresseUser { get; set; }

        public int? codePostal { get; set; }

        public int statusUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Avi> Avis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
