using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class CommandeAchat
    {
        private int num;
        private ModeTransport mode;
        private Magasin magasin;
        private DateTime dateCommande;
        private DateTime dateLivraison;
        private string modeLivraison;

        private ObservableCollection<Produit> sesProduits;

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

        public ModeTransport Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
            }
        }

        public Magasin Magasin
        {
            get
            {
                return magasin;
            }

            set
            {
                magasin = value;
            }
        }

        public DateTime DateCommande
        {
            get
            {
                return dateCommande;
            }

            set
            {
                dateCommande = value;
            }
        }

        public DateTime DateLivraison
        {
            get
            {
                return dateLivraison;
            }

            set
            {
                dateLivraison = value;
            }
        }

        public string ModeLivraison
        {
            get
            {
                return this.modeLivraison;
            }

            set
            {
                this.modeLivraison = value;
            }
        }

        public ObservableCollection<Produit> SesProduits
        {
            get
            {
                return sesProduits;
            }

            set
            {
                sesProduits = value;
            }
        }

        public CommandeAchat()
        {
            this.SesProduits = new ObservableCollection<Produit>();
        }

        public CommandeAchat(int num, string modeTransport, int numMagasin, string dateCommande, string modeLivraison) : this()
        {
            this.Num = num;
            this.Mode = new ModeTransport(modeTransport);
            this.Magasin = new Magasin(numMagasin);
            this.DateCommande = DateTime.Parse(dateCommande);
            this.ModeLivraison = modeLivraison;
        }

        public static ObservableCollection<CommandeAchat> Read()
        {
            ObservableCollection<Produit> lesCommandes = new ObservableCollection<Produit>();

            String sql = "SELECT num_commande, mode_transport, num_magasin, date_commande, " +
                         "date_livraison, mode_livraison, num_produit, nom_produit, prix_vente, quantite_commandee " +
                         "FROM commande_achat com " +
                         "JOIN mode_de_transport mode ON mode.mode_transport = com.mode_transport " +
                         "JOIN magasin mag ON mag.num_magasin = com.num_magasin " +
                         "JOIN detail_commande de ON de.num_commande = com.num_commande";

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
    }
}
