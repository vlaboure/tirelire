using applicationTirelire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace applicationTirelire.DataAccess
{
    public class CommandeRepository:EFRepository<Commande>
    {
        public override Commande Ajouter(Commande entite)
        {
            //on supprime le user existant pour éviter les doublons
            //à la création de la commande
            int iduser = entite.User.IdUser;
            entite.User = null;
            entite.IdUser = iduser;
            foreach (DetailCommande d in entite.DetailCommandes)
            {
                int idprod = d.IdProd;
                d.Produit = null;
                d.IdProd = idprod;
            }
            entite.statusCommande = 1;
            return base.Ajouter(entite);

        }
    }
}
