using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationTirelire.Models
{
    public class ProdCat
    {
        public int Idcategorie { get; set; }
        public string _Categorie { get; set; }
        public string UrlImg { get; set; }

    }
    public class ListProdCat
    {
        public List<ProdCat> ListCategories { get; set; }
    }
}