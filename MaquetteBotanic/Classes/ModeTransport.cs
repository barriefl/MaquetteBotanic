using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class ModeTransport
    {
        private string mode;

        public string Mode
        {
            get
            {
                return this.mode;
            }

            set
            {
                this.mode = value;
            }
        }

        public ModeTransport()
        {

        }

        public ModeTransport(string mode)
        {
            this.Mode = mode;
        }

        public override string ToString()
        {
            return Mode;
        }

        public static ObservableCollection<ModeTransport> Read()
        {
            ObservableCollection<ModeTransport> lesTransports = new ObservableCollection<ModeTransport>();
            String sql = "SELECT mode_transport FROM mode_de_transport";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                ModeTransport transport = new ModeTransport(res["mode_transport"].ToString());
                lesTransports.Add(transport);
            }
            return lesTransports;
        }
    }
}
