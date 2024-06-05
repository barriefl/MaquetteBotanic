using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Caracteristique
    {
        private int num;
        private string nom;

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

        public Caracteristique()
        {

        }

        public Caracteristique(string nom)
        {
            this.Nom = nom;
        }

        public Caracteristique(int num, string nom) : this(nom)
        {
            this.Num = num;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}
