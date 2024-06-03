using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
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
    }
}
