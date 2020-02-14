using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using applicationTirelire.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace applicationTirelire.Controllers
{
    public class CommandeController : Controller
    {
        // pas la meme instanciation car le repository CommandeRepository a été créé
        CommandeRepository repCommande = new CommandeRepository();

        // GET: commande
        public ActionResult Confirmation()
        {         
            ViewBag.Total = float.Parse(new PanierController().TotAvecLivraison().Content);
            return View((Commande)System.Web.HttpContext.Current.Session["Panier"]);
            
        }
        public ActionResult Detail(int id)
        {   
             return View(repCommande.Trouver(id));
        }

        // GET: commande/Details/5
        public ActionResult Validation()
        {
            CommandeRepository rep = new CommandeRepository();
            Commande panier = (Commande)System.Web.HttpContext.Current.Session["Panier"];
            panier.dateCommande = DateTime.Now;
            panier.PrixTotal = float.Parse(new PanierController().TotAvecLivraison().Content);
          //  panier.PrixTotal = float.Parse(new PanierController().CalculerTot().Content);
            try
            {
                //on met le panier dans la commande

                Commande comd = rep.Ajouter(panier);
                System.Web.HttpContext.Current.Session["Panier"] = new Commande(); 
                return View("Validation",panier);
            }
            catch(Exception e)
            {
                throw (e);
            }
          
        }

        public void Supprimer(int id)
        {
            Commande CommandeASupp = repCommande.Trouver(id);
            CommandeASupp.statusCommande = (int)EtatCmd.Inactive;
            repCommande.Modifier(CommandeASupp);
            ViewBag.Id = id;
            //return new ContentResult() { Content = null };
        }
        public ActionResult Lister()
        {
            return View(repCommande.Lister().Where(c => c.statusCommande > 0));
        }

        public ContentResult Traiter(int id)
        {
            Commande CommandeAtraiter = repCommande.Trouver(id);
            if (CommandeAtraiter.statusCommande < (int)EtatCmd.Receptionnee)
            {
                CommandeAtraiter.statusCommande++;
                //on sauve
                repCommande.Modifier(CommandeAtraiter);
            }else if(CommandeAtraiter.statusCommande == (int)EtatCmd.Suspendue)
            {
                ///PK ACTIVE ???
                CommandeAtraiter.statusCommande = (int)EtatCmd.Active;
                //on sauve
                repCommande.Modifier(CommandeAtraiter);
            }
            // Là c'est du lourd... on reourne dans Content 
            return new ContentResult() { Content = ((EtatCmd)CommandeAtraiter.statusCommande).ToString() };
        }
        // GET: commande/Create
        public ActionResult Create()
        {
            return View();
        }
  
        public ContentResult Suspendre(int id)
        {

            Commande commandeASuspendre = repCommande.Trouver(id);
            commandeASuspendre.statusCommande = (int)EtatCmd.Suspendue;
            repCommande.Modifier(commandeASuspendre);
            return new ContentResult { Content = ((EtatCmd)commandeASuspendre.statusCommande).ToString() };
        }


        // POST: commande/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: commande/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: commande/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }      
    }
}
