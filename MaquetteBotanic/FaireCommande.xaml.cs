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
    /// Logique d'interaction pour FaireCommande.xaml
    /// </summary>
    public partial class FaireCommande : Window
    {
        public FaireCommande()
        {
            InitializeComponent();

            dgListeProduit.Items.Filter = ContientMotClef;

            // DatePicker (date de la commande) automatique sur la date d'aujourd'hui.
            dpCreationCommande.SelectedDate = DateTime.Today;
            dpCreationCommande.IsEnabled = false;
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void butAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }

        private void butDebug_Click(object sender, RoutedEventArgs e)
        {
            VoirArticle article = new VoirArticle();
            article.ShowDialog();
        }

        private bool ContientMotClef(object obj)
        {
            Produit unProduit = obj as Produit;
            if (String.IsNullOrEmpty(tbRechercheProduit.Text))
                return true;
            else
                return (unProduit.Nom.StartsWith(tbRechercheProduit.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void tbRechercheProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeProduit.ItemsSource).Refresh();
        }
    }
}
