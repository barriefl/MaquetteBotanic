using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic.Classes
{
    public class CommandeAchat
    {
        private int num;
        private ModeTransport mode;
        private Magasin magasin;
        private DateTime dateCommande;
        private DateTime dateLivraison;
        private string modeLivraison;

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

        public ModeTransport Mode
        {
            get
            {
                return mode;
            }

            set
            {
                mode = value;
            }
        }

        public Magasin Magasin
        {
            get
            {
                return magasin;
            }

            set
            {
                magasin = value;
            }
        }

        public DateTime DateCommande
        {
            get
            {
                return dateCommande;
            }

            set
            {
                dateCommande = value;
            }
        }

        public DateTime DateLivraison
        {
            get
            {
                return dateLivraison;
            }

            set
            {
                dateLivraison = value;
            }
        }

        public string ModeLivraison
        {
            get
            {
                return this.modeLivraison;
            }

            set
            {
                this.modeLivraison = value;
            }
        }
    }
}
