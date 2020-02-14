using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationTirelire.Models
{
    public class CliTotVm
    {
        public int IdCli { get; set; }
        public string NomCli { get; set; }
        public string Adresse { get; set; }
        public string Mail { get; set; }
        public int TotCommande { get; set; }
    }
    public class ToListCliVm
    {
        public List<CliTotVm> ListIds { get; set; }
    }
}