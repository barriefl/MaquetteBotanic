using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class Salarie
    {
        private int num;
        private Magasin magasin;
        private string login;
        private string mdp;

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

        public Magasin Magasin
        {
            get
            {
                return this.magasin;
            }

            set
            {
                this.magasin = value;
            }
        }

        public string Login
        {
            get
            {
                return login;
            }

            set
            {
                login = value;
            }
        }

        public string Mdp
        {
            get
            {
                return this.mdp;
            }

            set
            {
                this.mdp = value;
            }
        }
    }
}
