using applicationTirelire.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType(typeof(MetaCommande))]
    public partial class Commande { }
    public class MetaCommande
    {
        [Display(Name = "Date de la commande")]

        public DateTime? DateCommande { get; set; }
        public ICollection<DetailCommande> DetailCommandes { get; set; }
        public ICollection<Facture> Factures { get; set; }
        public int IdCommande { get; set; }
        public int IdUser { get; set; }

        [DataType(DataType.Currency)]
        public double PrixTotal { get; set; }
        [Display(Name ="Statut de la commande")]
        public int StatusCommande { get; set; }
        public User User { get; set; }
    }
}