using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationTirelire.Outil
{
    public enum EtatCmd
    {
        Inactive = 0,// supprimé
        Active = 1,
        Preparee = 2,
        Expediee = 3,
        Receptionnee = 4,
        Suspendue=5//désactivée mais non supprimé
    }
    public enum EtatsAvis
    {
        Rejete = 0,
        NonApprouve = 1,
        Approuve = 2
    }
}