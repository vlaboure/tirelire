using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationTirelire.Models
{
    public class ProdTotalVM
    {
        public int IdProd { get; set; }
        public int Total { get; set; }
        public string NomProd { get; set; }
        public string Url { get; set; }

    }

    //classe pour contenir des objets pour l'affichage des données du top 5 des meilleurs ventes
    public class TotListVM
    {
        public List<ProdTotalVM> ListIds { get; set; }
    }
}