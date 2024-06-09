using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaquetteBotanic
{
    public class DataAccess
    {
        private static DataAccess instance;

        public DataAccess()
        {
            
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }

        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }

        public bool ConnexionBD(string strConnexion)
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
                Console.WriteLine("Connexion réussie.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb de connexion : " + e);
                MessageBox.Show("Password / Login incorrect");
                return false;
            }
        }

        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
                Console.WriteLine("Déconnexion réussie.");
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                Console.WriteLine(selectSQL);
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, Connexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }

        public int SetData(string setSQL)
        {
            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
    }
}
