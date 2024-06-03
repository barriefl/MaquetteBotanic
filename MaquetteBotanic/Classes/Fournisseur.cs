using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class Fournisseur
    {
        private int num;
        private string nom;
        private bool codeLocal;

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

        public bool CodeLocal
        {
            get
            {
                return this.codeLocal;
            }

            set
            {
                this.codeLocal = value;
            }
        }
    }
}
