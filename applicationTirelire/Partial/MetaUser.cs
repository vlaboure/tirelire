using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Models
{
    [MetadataType(typeof(MetaUser))]
    public partial class User { }
    public class MetaUser
    {
           
        public int IdUser { get; set; }
        [Required]
        [Display(Name = "Nom")]
        public string nomUser { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string PrenomUser { get; set; }
        [Required]
        public string sexe { get; set; }
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Format non valide")]
        public string emailUser { get; set; }
        [Required]
        [Display(Name = "Adresse")]
        public string adresseUser { get; set; }
        [Required]
        [Display(Name = "Ville")]
        public string villeUser { get; set; }
        [Required]
        [Display(Name = "Code postal")]
        [DataType(DataType.PostalCode, ErrorMessage = "Format non valide")]
        public int? codePostal { get; set; }
        [Required]
        [Display(Name = "Pays")]
        public string paysUser { get; set; }
        public int statusUser { get; set; }
        [Required]
        [Display(Name = "Télephone")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Format non valide")]
        public string telephoneUser { get; set; }       
        public ICollection<Avi> Avis { get; set; }
        public ICollection<Commande> Commandes { get; set; }

    }
}