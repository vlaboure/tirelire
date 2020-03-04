using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace applicationTirelire.Controllers
{
    public class ProduitController : Controller
    {        

        IRepository<Produit> repProduits = new EFRepository<Produit>();

        private void ListeFournisseurs()
        {
            // remplissage d'un viewBag List avec les fournisseurs existants
            IRepository<Fournisseur> repFournisseurs = new EFRepository<Fournisseur>();
            ViewBag.IdFourn = repFournisseurs.Lister()
                .Select(f =>
                new SelectListItem { Value = f.IdFourn.ToString(), Text = f.nomFourn })
                .ToList<SelectListItem>();
        }

        private void ListeCategorie()
        {
            // remplissage d'un viewBag List avec les categories existantes
            IRepository<Categorie> repCategorie = new EFRepository<Categorie>();
            ViewBag.IdCategorie = repCategorie.Lister()
                .Select(c => new SelectListItem { Value = c.IdCategorie.ToString(), Text = c._Categorie })
                .ToList<SelectListItem>();

        }
        // GET: Produit
        public ActionResult Index()
        {
            return View(repProduits.Lister());
        }

        public ActionResult Galerie()
        {
            ViewBag.Provenance = "Prod";
            //ViewBag.col = 8;
            //ViewBag.Style = "Galerie";
            return View(repProduits.Lister().Where(p => p.statusProd == 1));
        }

        
        // GET: Produti/Details/5
        public ActionResult Details(int id)
        {
            var prod = repProduits.Trouver(id);
            ViewBag.countor = repProduits.Lister().Where(u => u.couleur == prod.couleur&&u.statusProd!=0).Count();
            ViewBag.Roles = Roles.GetRolesForUser(User.Identity.Name);
            return View(prod);
        }


        public ActionResult _DetailCouleur(string color,int id)
        {
            
            //IEnumerable<Produit> produits;
          //  produits = repProduits.Lister();
          //  produits = repProduits.Lister().Where(p => p.couleur == color);

            return PartialView("_DetailCouleur", repProduits.Lister().Where(p => p.couleur == color && p.statusProd!=0 && p.IdProd!=id).Take(4));
        }

        // GET: Produti/Create
        public ActionResult Create()
        {
            ListeFournisseurs();
            ListeCategorie();
            return View();
        }

        public ActionResult ListTop()
        {
            IRepository<DetailCommande> repCmd = new EFRepository<DetailCommande>();
            IRepository<Produit> repProd = new EFRepository<Produit>();

            return View();
           
            //var query = products.GroupBy(product => new { product.Date, product.Ref, product.Nom }, (group, products)
            //    => new Product { Date = group.Date, Ref = group.Ref, Nom = group.Nom, Quantite = products.Sum(p => p.Quantite) });

        }
        /// <summary>
        /// on enregistre produit avec photo
        /// 
        /// </summary>
        /// <param name="produit"></param>
        /// <param name="fichier"></param>
        /// <returns></returns>
        // POST: Produti/Create
        [HttpPost]
        public ActionResult Create(Produit produit,HttpPostedFileBase fichier)
        {
            try
            {
                produit.statusProd = 1;
                if (fichier != null)
                {
                    produit.UrlImage = Path.GetFileName(fichier.FileName);
                }

                Produit newProd = repProduits.Ajouter(produit);

                if (fichier != null)
                {
                    if (newProd.UrlImage != null)
                    {
                        string chemin = string.Format("{0}\\{1}_{2}", System.Web.Hosting.HostingEnvironment.MapPath("~/Images"), newProd.IdProd, newProd.UrlImage);
                        fichier.SaveAs(chemin);
                    }
                }
       
                return RedirectToAction("Index");
            }
            catch
            {
                ListeFournisseurs();
                ListeCategorie();
                return View();
            }
        }

        // GET: Produti/Edit/5DeleteConfirm
        public ActionResult Edit(int id)
        {
            ListeFournisseurs();
            ListeCategorie();
            return View(repProduits.Trouver(id));
        }

        // POST: Produti/Edit/5
        [HttpPost]
        public ActionResult Edit(Produit produit, HttpPostedFileBase fichier)
        {
            try
            {
                // nom photo de base
                string oldFileName = produit.UrlImage;
                if (fichier != null)
                {
                    //nouveau nom de photo
                    produit.UrlImage = Path.GetFileName(fichier.FileName);
                }
                Produit newProd = repProduits.Modifier(produit);
                if (fichier != null)
                {
                    if (newProd.UrlImage != null)
                    {
                        //on concatène le nom image et le chemin de stockage
                        string oldFile = string.Format("{0}\\{1}_{2}",
                            Server.MapPath("~/Images"), newProd.IdProd, oldFileName);
                        if (System.IO.File.Exists(oldFile))
                        {
                            //si le fichier existe on le delete
                            System.IO.File.Delete(oldFile);
                        }
                    }
                    //chemin + nom du nouveau fichier
                    string finalFile = string.Format("{0}\\{1}_{2}",
                        System.Web.Hosting.HostingEnvironment.MapPath("~/Images"),
                        newProd.IdProd, newProd.UrlImage);
                    fichier.SaveAs(finalFile);
                }

                return RedirectToAction("Index");

            }
            catch
            {
                ListeFournisseurs();
                ListeCategorie();
                return View();
            }
        }

        // GET: Produti/Delete/5
        public ActionResult Delete(int id)
        {

            return View(repProduits.Trouver(id));
        }

        // POST: Produti/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                // TODO: Add delete logic here
                if (repProduits.Supprimer(id))
                    return RedirectToAction("Index");
                return View();                
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ProdCateg(int idCateg) 
        {
            ViewBag.Provenance = "Cat";
            ViewBag.col = 12;
            ViewBag.Style = "Categ";
            var prodCateg = repProduits.Lister().Where(p => p.Idcategorie == idCateg && p.statusProd != 0);
            return View("_AffichProd",repProduits.Lister().Where(p => p.Idcategorie == idCateg && p.statusProd != 0));
        }

        /// <summary>
        /// afficher un menu avec des images pour les catégories 
        /// </summary>
        /// <returns></returns>
        public ActionResult Categorie()
        {
            IRepository<Categorie> repCateg = new EFRepository<Categorie>();
            var categ = repProduits.Lister().GroupBy(c => c.Idcategorie).
                Select(c => c.OrderBy(p => p.Idcategorie).FirstOrDefault()).ToList();
           
            //liste temporaire ?? ...
            List<ProdCat> listCategories = new List<ProdCat>();
            //on remplit les  le model ProdCat
            foreach (var liste in categ)
            {
                ProdCat item = new ProdCat();
                item.Idcategorie = (int)liste.Idcategorie;
                item._Categorie = liste.Categorie._Categorie;
                item.UrlImg = repCateg.Trouver(item.Idcategorie).UrlImage;
                //on ajoute à la liste temporaire
                listCategories.Add(item);
            }
            //on crée l'objet liste qui servira pour l'affichage
            ListProdCat model = new ListProdCat()
            {
                //la liste pointe sur la liste temporaire
                ListCategories = listCategories
            };
            return View(model);
        }

        public ActionResult _Topp()
        {
            IRepository<DetailCommande> repCmd = new EFRepository<DetailCommande>();
            var req = repCmd.Lister().GroupBy(i => i.IdProd).Select(g => new { idProd = g.Key, Total = g.Sum(x => x.quantite) }).ToList().OrderByDescending(g => g.Total);
            List<ProdTotalVM> listProd = new List<ProdTotalVM>();
            foreach (var list in req)
            {
                ProdTotalVM item = new ProdTotalVM();
                item.IdProd = (int)list.idProd;
                item.NomProd = repProduits.Trouver(list.idProd).nomProd;
                item.Url = repProduits.Trouver(list.idProd).UrlImage;
                item.Total = (int)list.Total;
                listProd.Add(item);
            };
            TotListVM model = new TotListVM()
            {
                ListIds = listProd
            };
            return PartialView(model);
        }
        //public FileContentResult GetImage(int id)
        //{
        //    Photo photo = context.FindPhotoById(id);
        //    if (photo != null)
        //        return File(photo.PhotoFile, photo.ImageMimeType);
        //    return null;
        //}
    }
}
