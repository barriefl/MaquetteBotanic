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
        bool ajouter = false;
        bool supprimer = false;
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
            //FicheClient fiche = new FicheClient(Mode.Creation);
            //fiche.DataContext = nouvelleCommande;
            //fiche.ShowDialog();

            ApplicationData.LesCommandes.Add((CommandeAchat)gCreerCommande.DataContext);


            /*
            if (fiche.DialogResult == true)
            {
                data.LesClients.Add(nouveauClient);
                dgClients.SelectedItem = nouveauClient;
                data.Create(nouveauClient);
            }
            */
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
                    ajouter = true;
                }
                if (ajouter)
                {
                    double montantTotal = 0;
                    foreach (Produit produitAjoute in ApplicationData.LesProduitsAjoutes)
                    {
                        montantTotal += produitAjoute.PrixTotal;
                    }
                    labMontantTotal.Content = $"Montant total : {montantTotal} €";
                    ajouter = false;
                }
            }
            else
                MessageBox.Show(this, "Veuillez sélectionner un produit.");
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            if (dgProduitCommande.SelectedItem != null)
            {
                Produit produitSelectionne = (Produit)dgProduitCommande.SelectedItem;
                MessageBoxResult res = MessageBox.Show(this, $"Êtes vous sur de vouloir supprimer {produitSelectionne.Nom} ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    ApplicationData.LesProduitsAjoutes.Remove(produitSelectionne);
                    supprimer = true;
                }
                if (supprimer)
                {
                    double montantTotal = 0;
                    foreach (Produit produitAjoute in ApplicationData.LesProduitsAjoutes)
                    {
                        montantTotal += produitAjoute.PrixTotal;
                    }
                    labMontantTotal.Content = $"Montant total : {montantTotal} €";
                    supprimer = false;
                }
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un client");
        }
    }
}
