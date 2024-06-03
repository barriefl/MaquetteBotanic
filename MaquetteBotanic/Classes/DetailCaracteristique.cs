using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class DetailCaracteristique
    {
        private Produit produit;
        private Caracteristique caracteristique;
        private string valeur;

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

        public Caracteristique Caracteristique
        {
            get
            {
                return caracteristique;
            }

            set
            {
                caracteristique = value;
            }
        }

        public string Valeur
        {
            get
            {
                return this.valeur;
            }

            set
            {
                this.valeur = value;
            }
        }
    }
}
