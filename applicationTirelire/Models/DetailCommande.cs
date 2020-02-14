namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetailCommande")]
    public partial class DetailCommande
    {
        [Key]
        public int IdDetCom { get; set; }

        public int IdCommande { get; set; }

        public int IdProd { get; set; }

        public int quantite { get; set; }

        public virtual Commande Commande { get; set; }

        public virtual Produit Produit { get; set; }
    }
}
