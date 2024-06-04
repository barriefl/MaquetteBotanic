using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Categorie
    {
        private int num;
        private TypeProduit type;
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

        public TypeProduit Type
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

        public Categorie()
        {

        }

        public Categorie(int num)
        {
            this.Num = num;
        }

        public Categorie(int num, int numType, string libelle) : this(num)
        {
            this.Type = new TypeProduit(num);
            this.Libelle = libelle;
        }

        public override string ToString()
        {
            return Libelle;
        }

        public static ObservableCollection<Categorie> Read()
        {
            ObservableCollection<Categorie> lesCategories = new ObservableCollection<Categorie>();
            String sql = "SELECT num_categorie, num_type, libelle_categorie FROM categorie";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Categorie categorie = new Categorie(int.Parse(res["num_categorie"].ToString()),
                int.Parse(res["num_type"].ToString()), res["libelle_categorie"].ToString());
                lesCategories.Add(categorie);
            }
            return lesCategories;
        }
    }
}
