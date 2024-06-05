using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
        bool modif = false;
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
            /*
            CommandeAchat nouvelleCommande = new CommandeAchat();
            VisualiserCommandes voirCommandes = new VisualiserCommandes(); // A voir après la refonte de la structure.
            voirCommandes.DataContext = nouvelleCommande;
            */
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

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (dgListeProduit.SelectedItem != null)
            {
                Produit produitSelectionne = (Produit)dgListeProduit.SelectedItem;
                VoirArticle ajouteProduit = new VoirArticle();
                ajouteProduit.DataContext = (Produit)dgListeProduit.SelectedItem;
                ajouteProduit.ShowDialog();
                if (ajouteProduit.DialogResult == true)
                {
                    produitSelectionne.CalculePrixTotal();
                    ApplicationData.LesProduitsAjoutes.Add((Produit)ajouteProduit.DataContext);
                    int index = ApplicationData.LesProduitsAjoutes.IndexOf(produitSelectionne);
                    dgProduitCommande.SelectedIndex = index;
                    modif = true;
                }
                if (modif)
                {
                    double montantTotal = 0;
                    foreach (Produit produitAjoute in ApplicationData.LesProduitsAjoutes)
                    {
                        montantTotal += produitAjoute.PrixTotal;
                    }
                    labMontantTotal.Content = $"Montant total : {montantTotal} €";
                    modif = false;
                }
            }
            else
                MessageBox.Show(this, "Veuillez sélectionner un produit.");
        }
    }
}
