using System;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType(typeof(MetaFacture))]
    public partial class Facture { }
    public class MetaFacture
    {
        public Commande Commande { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateFacture { get; set; }
        public int IdCommande { get; set; }
        public int IdFacture { get; set; }
        [DataType(DataType.Currency)]
        public double? PrixHT { get; set; }
        public double? PrixLivraison { get; set; }
        [DataType(DataType.Currency)]
        public double? PrixTTC { get; set; }
        public double? PrixTVA { get; set; }
    }
}