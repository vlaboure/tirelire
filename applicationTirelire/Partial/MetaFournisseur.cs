using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType(typeof(MetaFournisseur))]
    public partial class Fournisseur { }
    public class MetaFournisseur
    {
        [Display(Name = "Adresse")]
        public string adresseFourn { get; set; }
        [Display(Name = "Code postal")]
        [DataType(DataType.PostalCode, ErrorMessage = "Format non valide")]
        public int? codePostal { get; set; }
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Email Fournisseur")]
        public string descriptionFourn { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Format non valide")]
        public string emailFourn { get; set; }
        public int IdFourn { get; set; }
  
        [Display(Name = "Nom Fournisseur")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string nomFourn { get; set; }
        public string paysFourn { get; set; }
        public ICollection<Produit> Produits { get; set; }
        public int Statut { get; set; }
        [Display(Name = "Téléphone Fournisseur")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Format non valide")]


        public string telephoneFourn { get; set; }
        public string villeFourn { get; set; }
    }
}