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
        private string nom;
        private ModeTransport mode;
        private Magasin magasin;
        private DateTime dateCommande;
        private DateTime dateLivraison;
        private string modeLivraison;

        private static int numAuto = 0;

        private ObservableCollection<Produit> sesProduits;

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

        public string Nom
        {
            get
            {
                return this.nom;
            }

            set
            {
                this.nom = value;
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

        public static int NumAuto
        {
            get
            {
                return numAuto;
            }

            set
            {
                numAuto = value;
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

        public CommandeAchat()
        {
            CommandeAchat.NumAuto++;
            this.Num = CommandeAchat.NumAuto;
            this.SesProduits = new ObservableCollection<Produit>();
            this.DateCommande = DateTime.Today;
            this.NomAJour();
        }

        public CommandeAchat(int num, string modeTransport, int numMagasin, string dateCommande, string dateLivraison,string modeLivraison) : this()
        {
            this.Num = num;
            this.Mode = new ModeTransport(modeTransport);
            this.Magasin = new Magasin(numMagasin);
            this.DateCommande = DateTime.Parse(dateCommande);
            this.DateLivraison = DateTime.Parse(dateLivraison);
            this.ModeLivraison = modeLivraison;
        }

        public void NomAJour()
        {
            this.Nom = $"Commande n°{this.Num}";
        }

        public static ObservableCollection<CommandeAchat> Read()
        {
            ObservableCollection<CommandeAchat> lesCommandes = new ObservableCollection<CommandeAchat>();

            String sql = "SELECT com.num_commande, com.mode_transport, com.num_magasin, date_commande, " +
                         "date_livraison, mode_livraison " +
                         "FROM commande_achat com";

            DataTable dt = DataAccess.Instance.GetData(sql);

            foreach (DataRow res in dt.Rows)
            {
                int numCommande = int.Parse(res["num_commande"].ToString());
                CommandeAchat commande = lesCommandes.FirstOrDefault(c => c.Num == numCommande);

                if (commande == null)
                {
                    commande = new CommandeAchat
                    (
                        int.Parse(res["num_commande"].ToString()),
                        res["mode_transport"].ToString(),
                        int.Parse(res["num_magasin"].ToString()),
                        res["date_commande"].ToString(),
                        res["date_livraison"].ToString(),
                        res["mode_livraison"].ToString()
                    );
                    lesCommandes.Add(commande);
                }
            }
            return lesCommandes;
        }

        public ObservableCollection<Produit> AjouteListe(ObservableCollection<Produit> lesProduits)
        {
            foreach(Produit produit in lesProduits)
            {
                this.SesProduits.Add(produit);
            }
            return this.SesProduits;
        }

        public double CalculePrixTotal()
        {
            foreach(Produit produit in this.SesProduits)
            {
                this.PrixTotal += produit.PrixTotal;
            }
            Math.Round(this.PrixTotal, 2);
            return this.PrixTotal;
        }
    }
}
