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
            Connexion();
            creerCommande = true;
            if (creerCommande)
            {
                dgListeProduit.Items.Filter = ProduitContientMotClef;
                dgListeCommande.Items.Filter = CommandeContientMotClef;
                labDateCreation.Content = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataAccess.Instance.DeconnexionBD();
        }

        private bool ProduitContientMotClef(object obj)
        {
            Produit unProduit = obj as Produit;
            if (String.IsNullOrEmpty(tbRechercheProduit.Text))
                return true;
            else
                return (unProduit.Nom.StartsWith(tbRechercheProduit.Text, StringComparison.OrdinalIgnoreCase));
        }

        private bool CommandeContientMotClef(object obj)
        {
            CommandeAchat uneCommande = obj as CommandeAchat;
            if (String.IsNullOrEmpty(tbRechercheCommande.Text))
                return true;
            else
                return (uneCommande.Nom.StartsWith(tbRechercheCommande.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void tbRechercheProduit_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeProduit.ItemsSource).Refresh();
        }

        private void tbRechercheCommande_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgListeCommande.ItemsSource).Refresh();
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            NouvelleCommande();
        }

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterProduit();
        }

        private void butSupprimer_Click(object sender, RoutedEventArgs e)
        {
            SupprimerProduit();
        }

        private void butValiderCommande_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Il ne se passe rien.");
        }

        private void Connexion()
        {
            string identifiantSaisie = tbLogin.Text;
            string passwordSaisie = tbPassword.Password;

            
            string strConnexion = "Server=srv-peda-new;" +
                                  "port=5433;" +
                                  "Database=botanicTP12;" +
                                  $"Search Path=botanic; uid={identifiantSaisie};password={passwordSaisie};";
            /*
            string strConnexion = "Server=localhost;" +
                                  "port=5432;" +
                                  "Database=botanic;" +
                                  $"uid={identifiantSaisie};" +
                                  $"password={passwordSaisie};";
            */

            if (DataAccess.Instance.ConnexionBD(strConnexion))
            {
                mainWindow.DataContext = ApplicationData.Instance;
                tcMenu.Visibility = Visibility.Visible;
                spPageConnexion.Visibility = Visibility.Hidden;
            }
        }

        private void NouvelleCommande()
        {
            CommandeAchat nouvelleCommande = new CommandeAchat();
            nouvelleCommande.AjouteListe(ApplicationData.LesProduitsAjoutes);
            nouvelleCommande.CalculePrixTotal();
            nouvelleCommande.ModeLivraison = cbModeTransport.Text;
            ApplicationData.LesCommandes.Add(nouvelleCommande);
            Console.WriteLine("Commande ajoutée.");
            creerCommande = false;
        }

        private void AjouterProduit()
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
                    Math.Round(montantTotal, 2);
                    labMontantTotal.Content = $"Montant total : {montantTotal} €";
                    ajouter = false;
                }
            }
            else
                MessageBox.Show(this, "Veuillez sélectionner un produit.");
        }

        private void SupprimerProduit()
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
                    Math.Round(montantTotal, 2);
                    labMontantTotal.Content = $"Montant total : {montantTotal} €";
                    supprimer = false;
                }
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un client");
        }
    }
}
