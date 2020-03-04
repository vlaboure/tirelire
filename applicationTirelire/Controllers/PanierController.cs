using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace applicationTirelire.Controllers
{
   
    public class PanierController : Controller
    {

        Commande panier;
       
        float fraislivr=0;
        const int fraisBase= 3;
        public double pdsTot = 0;
        public PanierController()
        {
            panier = (Commande)System.Web.HttpContext.Current.Session["panier"];
            if (panier.User == null)
            {
                panier.User = (User)System.Web.HttpContext.Current.Session["User"];
                System.Web.HttpContext.Current.Session["panier"] = panier;
            }
            //Session["fraisLivr"] = 0;
        }


        public ActionResult Ajouter(int id)
        {
            IRepository<Produit> rep = new EFRepository<Produit>();
            DetailCommande detail;
            if (panier.DetailCommandes.Where(d => d.IdProd == id).Count()>0)
            {
                //Le produit est déjà ds le panier
                detail = panier.DetailCommandes.Where(d => d.IdProd == id).First();
                detail.quantite++;
            }
            else
            {
                detail = new DetailCommande { Produit = rep.Trouver(id), IdProd = id, quantite = 1 };
                panier.DetailCommandes.Add(detail);
            }
            Session["Panier"] = panier;
            return RedirectToAction("Index");
        }

        // GET: Panier
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Roles = Roles.GetRolesForUser(User.Identity.Name);
            return View(panier);
        }

        // GET: Panier/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //// POST: Panier/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Panier/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Panier/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Panier/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Panier/Delete/5

        public ActionResult Delete(int id)
        {
            panier.DetailCommandes.Remove(panier.DetailCommandes.Where(d => d.IdProd == id).First());
            return new ContentResult();
        }



        //public ContentResult Decrementer(int id)
        //{
        //    DetailCommande detailActif = Panier.DetailCommandes.Where(d => d.IDProduit == id).First();

        //    if (detailActif.Quantite > 1)
        //    {
        //        detailActif.Quantite--;


        //    }

        //    return new ContentResult()
        //    {
        //        Content = string.Format("<span>{0}</span>"
        //        , detailActif.Quantite * detailActif.Produit.PrixUnitaire
        //        )
        //    };

        //}
        //public ContentResult DecrementPx(DetailCommande detailActif)
        //{
        //    return new ContentResult()
        //    {
        //        Content = string.Format("<span>{0}</span>"
        //     , detailActif.Quantite * detailActif.Produit.PrixUnitaire
        //     )
        //    };
        //}

        public ContentResult Incrementer(int id)
        {
            DetailCommande detLigne = panier.DetailCommandes.Where(d => d.IdProd == id).First();
            detLigne.quantite++;
            var tp= new ContentResult()
            {
                Content = string.Format("<span class='col-md-4'>{0} </span>   <span class='col-md-6'>  {1}</span>",
                detLigne.quantite.ToString(), detLigne.quantite * detLigne.Produit.PrixProd)
            };
            return tp;
        }

        public ContentResult Decrementer(int id)
        {
            DetailCommande detLigne = panier.DetailCommandes.Where(d => d.IdProd == id).First();
            if (detLigne.quantite > 1)
            {
                detLigne.quantite--;
            }
            return new ContentResult()
            {
                Content = string.Format("<span class='col-md-4'>{0} </span>   <span class='col-md-6'>  {1}</span>",
                detLigne.quantite.ToString(), detLigne.quantite*detLigne.Produit.PrixProd)
            };
        }
        public ContentResult CalculerTot()
        {
            return new ContentResult()
            {
                Content = panier.DetailCommandes
                .Select(d => new { montant = d.Produit.PrixProd * d.quantite })
                .Sum(m => m.montant).ToString()
            };
        }
        public ContentResult CalculLivraison()
        {
            // calcul de poids de toutes les lignes
            double? pdsTot = panier.DetailCommandes.Select(d => new { pdsTot = d.quantite * d.Produit.poids })
                .Sum(p => p.pdsTot);
            //calcul des frais de livraison
            fraislivr= (int)(pdsTot / 1.5) * fraisBase;


            return new ContentResult()
            {
                Content = fraislivr.ToString()
            };
        }
        public ContentResult TotAvecLivraison()
        {
            double? tot = panier.DetailCommandes.Select(d => new { tot = d.Produit.PrixProd * d.quantite }).Sum(m => m.tot);
            double? pdsTot = panier.DetailCommandes.Select(d => new { pdsTot = d.Produit.poids * d.quantite }).Sum(m => m.pdsTot);
            fraislivr = (int)(pdsTot / 1.5) * fraisBase;      
            return new ContentResult()
            {
                Content = (fraislivr + tot).ToString()
            };
        }
    }
}
