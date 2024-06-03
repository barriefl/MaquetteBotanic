using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class Categorie
    {
        private int num;
        private Type type;
        private string libelle;

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

        public Type Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        public string Libelle
        {
            get
            {
                return this.libelle;
            }

            set
            {
                this.libelle = value;
            }
        }
    }
}
