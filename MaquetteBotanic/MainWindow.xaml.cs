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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataAccess connexion = new DataAccess();
        bool modif = false;
        bool creerCommande = false;

        public MainWindow()
        {
            InitializeComponent();
            tcMenu.Visibility = Visibility.Hidden;
        }

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            tcMenu.Visibility = Visibility.Visible;
            spPageConnexion.Visibility = Visibility.Hidden;

            creerCommande = true;
            if (creerCommande)
            {
                dgListeProduit.Items.Filter = ContientMotClef;

                dpCreationCommande.SelectedDate = DateTime.Today;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataAccess.Instance.DeconnexionBD();
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

        private void butValider_Click(object sender, RoutedEventArgs e)
        {

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
