using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaquetteBotanic
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void butCreerCommande_Click(object sender, RoutedEventArgs e)
        {
            FaireCommande creerCommande = new FaireCommande();
            creerCommande.Show();
            this.Close();
        }

        private void butVoirCommandes_Click(object sender, RoutedEventArgs e)
        {
            VisualiserCommandes voirCommandes = new VisualiserCommandes();
            voirCommandes.Show();
            this.Close();
        }

        private void butDeconnexion_Click(object sender, RoutedEventArgs e)
        {
            PageConnexion pageConnexion = PageConnexion.Session;
            pageConnexion.Show();
            this.Close();
        }
    }
}
