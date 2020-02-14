using applicationTirelire.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType (typeof(MetaProduit))]
    public partial class Produit { }

    public partial class Produit { }
    public class MetaProduit
    {
        public ICollection<Avi> Avis { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Currency)]
        public int? Capacite { get; set; }
        [Display(Name ="Image")]
        public string UrlImage { get; set; }

        [Display(Name = "Couleur de l'article")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string couleur { get; set; }
        [Display(Name = "Description produit")]
        public string descriptionProd { get; set; }
        public ICollection<DetailCommande> DetailCommandes { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public Fournisseur Fournisseur { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public double? Hauteur { get; set; }
        public int? IdFourn { get; set; }
        public int IdProd { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public double? Largeur { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public double? Longeur { get; set; }
        [Display(Name = "Nom du produit")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string NomProd { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Currency)]
        public double? Poids { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.Currency)]
        [Display(Name = "Prix HT")]
        public double? PrixProd { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public int StatusProd { get; set; }

        public int IdCategorie { get; set; }
    }
}