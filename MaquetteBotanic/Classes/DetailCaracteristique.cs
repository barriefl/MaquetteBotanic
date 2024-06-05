using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class DetailCaracteristique
    {
        private int numProduit;
        private int numCaracteristique;
        private string valeur;
        private Caracteristique nomCaracteristique;

        public int NumProduit
        {
            get
            {
                return numProduit;
            }

            set
            {
                numProduit = value;
            }
        }

        public int NumCaracteristique
        {
            get
            {
                return numCaracteristique;
            }

            set
            {
                numCaracteristique = value;
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

        public Caracteristique NomCaracteristique
        {
            get
            {
                return this.nomCaracteristique;
            }

            set
            {
                this.nomCaracteristique = value;
            }
        }

        public DetailCaracteristique()
        {

        }

        public DetailCaracteristique(int numProduit, int numCaracteristique, string caracteristique)
        {
            this.NumProduit = numProduit;
            this.NumCaracteristique = numCaracteristique;
            this.Valeur = caracteristique;
        }

        public DetailCaracteristique(int numProduit, int numCaracteristique, string valeurCaracteristique, string nomCaracteristique) : this(numProduit, numCaracteristique, valeurCaracteristique)
        {
            this.NomCaracteristique = new Caracteristique(nomCaracteristique);
        }

        public override string ToString()
        {
            return this.Valeur;
        }
    }
}
