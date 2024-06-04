using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class TypeProduit
    {
        private int num;
        private string designation;

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

        public string Designation
        {
            get
            {
                return this.designation;
            }

            set
            {
                this.designation = value;
            }
        }

        public TypeProduit()
        {

        }

        public TypeProduit(int num)
        {
            this.Num = num;
        }

        public TypeProduit(int num, string designation) : this(num)
        {
            this.Designation = designation;
        }

        public override string ToString()
        {
            return Designation;
        }

        public static ObservableCollection<TypeProduit> Read()
        {
            ObservableCollection<TypeProduit> lesTypes = new ObservableCollection<TypeProduit>();
            String sql = "SELECT num_type, designation_type FROM type_produit";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                TypeProduit type = new TypeProduit(int.Parse(res["num_type"].ToString()), res["designation_type"].ToString());
                lesTypes.Add(type);
            }
            return lesTypes;
        }
    }
}
