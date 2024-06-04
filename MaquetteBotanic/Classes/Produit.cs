using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Produit
    {
        private int num;
        private Couleur couleur;
        private Fournisseur fournisseur;
        private Categorie categorie;
        private string nom;
        private string taille;
        private string description;
        private double prixVente;
        private double prixAchat;
        private List<Caracteristique> caracteristiques;

        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                num = value;
            }
        }

        public Couleur Couleur
        {
            get
            {
                return couleur;
            }

            set
            {
                couleur = value;
            }
        }

        public Fournisseur Fournisseur
        {
            get
            {
                return fournisseur;
            }

            set
            {
                fournisseur = value;
            }
        }

        public Categorie Categorie
        {
            get
            {
                return categorie;
            }

            set
            {
                categorie = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Taille
        {
            get
            {
                return taille;
            }

            set
            {
                taille = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public double PrixVente
        {
            get
            {
                return prixVente;
            }

            set
            {
                prixVente = value;
            }
        }

        public double PrixAchat
        {
            get
            {
                return this.prixAchat;
            }

            set
            {
                this.prixAchat = value;
            }
        }

        public List<Caracteristique> Caracteristiques
        {
            get
            {
                return this.caracteristiques;
            }

            set
            {
                this.caracteristiques = value;
            }
        }

        public Produit()
        {
            Caracteristiques = new List<Caracteristique>();
        }

        public Produit(int numProduit) : this()
        {
            this.Num = numProduit;
        }

        public Produit(int numProduit, string nomCouleur, int numFournisseur, int numCategorie, string nomProduit, string taille, string description, double prixVente, double prixAchat) : this(numProduit)
        {
            this.Couleur = new Couleur(nomCouleur);
            this.Fournisseur = new Fournisseur(numFournisseur);
            this.Categorie = new Categorie(numCategorie);
            this.Nom = nomProduit;
            this.Taille = taille;
            this.Description = description;
            this.PrixVente = prixVente;
            this.PrixAchat = prixAchat;
        }

        public static ObservableCollection<Produit> Read()
        {
            ObservableCollection<Produit> lesProduits = new ObservableCollection<Produit>();
            String sqlProduits = "SELECT num_produit, nom_couleur, num_fournisseur, num_categorie," +
                         "nom_produit, taille_produit, description_produit, prix_vente, prix_achat FROM produit";
            DataTable dtProduits = DataAccess.Instance.GetData(sqlProduits);

            /*
            string sqlCaracteristiques = $"SELECT num_produit, num_caracteristique, valeur_caracteristique FROM detail_caracteristique WHERE num_produit = {produitSelectionne.Num}";
            DataTable dtCaracteristiques = DataAccess.Instance.GetData(sqlCaracteristiques);
            */
            foreach (DataRow res in dtProduits.Rows)
            {
                Produit produit = new Produit(int.Parse(res["num_produit"].ToString()),
                res["nom_couleur"].ToString(), 
                int.Parse(res["num_fournisseur"].ToString()),
                int.Parse(res["num_categorie"].ToString()), 
                res["nom_produit"].ToString(),
                res["taille_produit"].ToString(), 
                res["description_produit"].ToString(),
                double.Parse(res["prix_vente"].ToString()), 
                double.Parse(res["prix_achat"].ToString()));

                /*
                List<Caracteristique> caracteristiques = new List<Caracteristique>(res["nom_produit"].ToString()),
                res["nom_caracteristique"].ToString());
                */

                /*
                var caracteristiques = dtCaracteristiques.AsEnumerable().Where(res => 
                int.Parse(res["num_produit"].ToString()) == produit.Num).Select(res => 
                new DetailCaracteristique(int.Parse(res["num_produit"].ToString()), 
                int.Parse(res["num_caracteristique"].ToString()), res["valeur_caracteristique"].ToString()));
                */

                /*
                foreach (var caracteristique in caracteristiques)
                {
                    produit.Caracteristiques.Add(caracteristique);
                }
                */
                lesProduits.Add(produit);
            }
            return lesProduits;
        }    
    }
}