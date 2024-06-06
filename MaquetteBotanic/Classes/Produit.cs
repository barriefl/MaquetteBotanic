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

        private List<DetailCaracteristique> valeurCaracteristiques;
        private List<Caracteristique> nomCaracteristiques;

        private int quantiteCommandee;
        private double prixTotal;

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

        public List<DetailCaracteristique> ValeurCaracteristiques
        {
            get
            {
                return valeurCaracteristiques;
            }

            set
            {
                valeurCaracteristiques = value;
            }
        }

        public List<Caracteristique> NomCaracteristiques
        {
            get
            {
                return this.nomCaracteristiques;
            }

            set
            {
                this.nomCaracteristiques = value;
            }
        }

        public int QuantiteCommandee
        {
            get
            {
                return quantiteCommandee;
            }

            set
            {
                quantiteCommandee = value;
            }
        }

        public double PrixTotal
        {
            get
            {
                return this.prixTotal;
            }

            set
            {
                this.prixTotal = value;
            }
        }

        public Produit()
        {
            this.NomCaracteristiques = new List<Caracteristique>();
            this.ValeurCaracteristiques = new List<DetailCaracteristique>();
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

            String sql = "SELECT pro.num_produit, nom_couleur, num_fournisseur, num_categorie, " +
                         "nom_produit, taille_produit, description_produit, prix_vente, prix_achat, de.num_caracteristique, " +
                         "car.nom_caracteristique, de.valeur_caracteristique " + 
                         "FROM produit pro " +
                         "JOIN detail_caracteristique de ON de.num_produit = pro.num_produit " +
                         "JOIN caracteristique car ON car.num_caracteristique = de.num_caracteristique";

            DataTable dt = DataAccess.Instance.GetData(sql);

            foreach (DataRow res in dt.Rows)
            {
                int numProduit = int.Parse(res["num_produit"].ToString());
                Produit produit = lesProduits.FirstOrDefault(p => p.Num == numProduit);

                if (produit == null)
                {
                    produit = new Produit
                    (
                        int.Parse(res["num_produit"].ToString()),
                        res["nom_couleur"].ToString(),
                        int.Parse(res["num_fournisseur"].ToString()),
                        int.Parse(res["num_categorie"].ToString()),
                        res["nom_produit"].ToString(),
                        res["taille_produit"].ToString(),
                        res["description_produit"].ToString(),
                        double.Parse(res["prix_vente"].ToString()),
                        double.Parse(res["prix_achat"].ToString())
                    );
                    lesProduits.Add(produit);
                }

                DetailCaracteristique valeur = new DetailCaracteristique
                (
                    int.Parse(res["num_produit"].ToString()),
                    int.Parse(res["num_caracteristique"].ToString()),
                    res["valeur_caracteristique"].ToString()
                );
                produit.ValeurCaracteristiques.Add(valeur);

                Caracteristique nom = new Caracteristique
                (
                    int.Parse(res["num_caracteristique"].ToString()),
                    res["nom_caracteristique"].ToString()
                );
                produit.NomCaracteristiques.Add(nom);
            }
            return lesProduits;
        }

        public double CalculePrixTotal()
        {
            return this.PrixTotal = this.QuantiteCommandee * this.PrixVente;
        }
    }
}