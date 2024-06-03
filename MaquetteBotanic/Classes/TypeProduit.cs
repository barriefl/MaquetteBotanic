using System;
using System.Collections.Generic;
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
    }
}
