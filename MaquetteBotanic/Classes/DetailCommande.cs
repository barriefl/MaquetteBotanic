using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class DetailCommande
    {
        private CommandeAchat commande;
        private Produit produit;
        private int quantiteCommandee;

        public CommandeAchat Commande
        {
            get
            {
                return commande;
            }

            set
            {
                commande = value;
            }
        }

        public Produit Produit
        {
            get
            {
                return produit;
            }

            set
            {
                produit = value;
            }
        }

        public int QuantiteCommandee
        {
            get
            {
                return this.quantiteCommandee;
            }

            set
            {
                this.quantiteCommandee = value;
            }
        }
    }
}
