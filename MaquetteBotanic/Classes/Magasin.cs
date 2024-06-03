using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Magasin
    {
        private int num;
        private string nom;
        private string adresseRue;
        private string adresseCP;
        private string adresseVille;
        private string horaire;

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
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string AdresseRue
        {
            get
            {
                return adresseRue;
            }

            set
            {
                adresseRue = value;
            }
        }

        public string AdresseCP
        {
            get
            {
                return adresseCP;
            }

            set
            {
                adresseCP = value;
            }
        }

        public string AdresseVille
        {
            get
            {
                return adresseVille;
            }

            set
            {
                adresseVille = value;
            }
        }

        public string Horaire
        {
            get
            {
                return this.horaire;
            }

            set
            {
                this.horaire = value;
            }
        }
    }
}
