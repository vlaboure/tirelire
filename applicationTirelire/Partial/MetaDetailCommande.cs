
using System.ComponentModel.DataAnnotations;

namespace applicationTirelire.Partial
{
    [MetadataType(typeof(MetaDetailCommande))]
    public partial class DetailCommande { }
    public class MetaDetailCommande
    {
        public Commande Commande { get; set; }
        public int IdCommande { get; set; }
        public int IdDetCom { get; set; }
        public int IdProd { get; set; }
        public Produit Produit { get; set; }
        public int Quantite { get; set; }
    }
}