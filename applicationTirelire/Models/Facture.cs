namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Facture")]
    public partial class Facture
    {
        [Key]
        public int idFacture { get; set; }

        public int IdCommande { get; set; }

        public double? prixHT { get; set; }

        public double? prixTVA { get; set; }

        public double? prixLivraison { get; set; }

        public DateTime? dateFacture { get; set; }

        public double? prixTotal { get; set; }

        public virtual Commande Commande { get; set; }
    }
}
