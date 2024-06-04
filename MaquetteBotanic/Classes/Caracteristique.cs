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

        public Caracteristique(int num)
        {
            this.Num = num;
        }

        public Caracteristique(int num, string nom) : this(num)
        {
            this.Nom = nom;
        }
    }
}
