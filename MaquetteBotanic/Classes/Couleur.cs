using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

        public override string ToString()
        {
            return Nom;
        }

        public static ObservableCollection<Couleur> Read()
        {
            ObservableCollection<Couleur> lesCouleurs = new ObservableCollection<Couleur>();
            String sql = "SELECT nom_couleur FROM couleur";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Couleur couleur = new Couleur(res["nom_couleur"].ToString());
                lesCouleurs.Add(couleur);
            }
            return lesCouleurs;
        }
    }
}
