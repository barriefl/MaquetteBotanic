using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Couleur
    {
        private string nom;

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

        public Couleur()
        {

        }

        public Couleur(string nom)
        {
            this.Nom = nom;
        }
    }
}
