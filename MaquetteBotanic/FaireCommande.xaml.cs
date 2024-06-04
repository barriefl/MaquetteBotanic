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

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (dgListeProduit.SelectedItem != null)
            {
                Produit produitSelectionne = (Produit)dgListeProduit.SelectedItem;

                // On récupère les caractéristiques du produit.

                /*
                string sqlCaracteristiques = $"SELECT num_produit, num_caracteristique, valeur_caracteristique FROM detail_caracteristique WHERE num_produit = {produitSelectionne.Num}";
                DataTable dtCaracteristiques = DataAccess.Instance.GetData(sqlCaracteristiques);

                var caracteristiques = dtCaracteristiques.AsEnumerable().Select(res => new DetailCaracteristique(int.Parse(res["num_produit"].ToString()), int.Parse(res["num_caracteristique"].ToString()), res["valeur_caracteristique"].ToString())).ToList();

                produitSelectionne.Caracteristiques = new ObservableCollection<DetailCaracteristique>(caracteristiques);
                
                Article produit = new Article
                {
                    Produit = produitSelectionne
                };

                VoirArticle article = new VoirArticle
                {
                    DataContext = produit
                };
                */
                VoirArticle article = new VoirArticle();
                article.Panel.DataContext = (Produit)dgListeProduit.SelectedItem;
                article.ShowDialog();
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un produit.");
        }
    }
}
