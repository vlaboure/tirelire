
using applicationTirelire.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType(typeof(MetaAvi))]
    public partial class Avi { }
    public class MetaAvi
    {
        public int IdAvis { get; set; }
        public int IdProd { get; set; }
        public int IdUser { get; set; }
        [Required]
        public int? note { get; set; }
        public Produit Produit { get; set; }
        public int statusAvis { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string texte { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; }
    }
}