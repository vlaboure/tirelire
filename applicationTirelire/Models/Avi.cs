namespace applicationTirelire.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Avi
    {
        [Key]
        public int IdAvis { get; set; }

        public int IdUser { get; set; }

        public int IdProd { get; set; }

        public int? note { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(100)]
        public string texte { get; set; }

        public int statusAvis { get; set; }

        public virtual Produit Produit { get; set; }

        public virtual User User { get; set; }
    }
}
