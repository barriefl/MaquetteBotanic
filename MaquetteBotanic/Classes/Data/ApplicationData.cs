using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaquetteBotanic
{

    public class ApplicationData : INotifyPropertyChanged
    {
        private static ApplicationData instance;

        private static ObservableCollection<TypeProduit> lesTypes;
        private TypeProduit typeSelectionne;
        private static ObservableCollection<Categorie> lesCategories;
        private Categorie categorieSelectionnee;
        private static ObservableCollection<Couleur> lesCouleurs;
        private Couleur couleurSelectionnee;
        private static ObservableCollection<Produit> lesProduits;
        private ObservableCollection<Produit> lesProduitsFiltres;
        private static ObservableCollection<ModeTransport> lesTransports;
        private static ObservableCollection<Produit> lesProduitsAjoutes = new ObservableCollection<Produit>();
        private static ObservableCollection<CommandeAchat> lesCommandes;
        private CommandeAchat commandeSelectionnee;

        public event PropertyChangedEventHandler PropertyChanged;

        public static ApplicationData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ApplicationData();
                }
                return instance;
            }
        }

        public ObservableCollection<TypeProduit> LesTypes
        {
            get
            {
                return lesTypes;
            }

            set
            {
                lesTypes = value;
            }
        }

        public TypeProduit TypeSelectionne
        {
            get
            {
                return this.typeSelectionne;
            }

            set
            {
                this.typeSelectionne = value;
                OnPropertyChanged(nameof(TypeSelectionne));
                FiltrerProduits();
            }
        }

        public static ObservableCollection<Categorie> LesCategories
        {
            get
            {
                return lesCategories;
            }

            set
            {
                lesCategories = value;
            }
        }

        public Categorie CategorieSelectionnee
        {
            get
            {
                return this.categorieSelectionnee;
            }

            set
            {
                this.categorieSelectionnee = value;
                OnPropertyChanged(nameof(CategorieSelectionnee));
                FiltrerProduits();
            }
        }

        public static ObservableCollection<Couleur> LesCouleurs
        {
            get
            {
                return lesCouleurs;
            }

            set
            {
                lesCouleurs = value;
            }
        }

        public Couleur CouleurSelectionnee
        {
            get
            {
                return this.couleurSelectionnee;
            }

            set
            {
                this.couleurSelectionnee = value;
                OnPropertyChanged(nameof(CouleurSelectionnee));
            }
        }

        public static ObservableCollection<Produit> LesProduits
        {
            get
            {
                return lesProduits;
            }

            set
            {
                lesProduits = value;
            }
        }

        public ObservableCollection<Produit> LesProduitsFiltres
        {
            get
            {
                return lesProduitsFiltres;
            }

            set
            {
                lesProduitsFiltres = value;
                OnPropertyChanged(nameof(LesProduitsFiltres));
            }
        }

        public static ObservableCollection<ModeTransport> LesTransports
        {
            get
            {
                return lesTransports;
            }

            set
            {
                lesTransports = value;
            }
        }

        public static ObservableCollection<Produit> LesProduitsAjoutes
        {
            get
            {
                return lesProduitsAjoutes;
            }

            set
            {
                lesProduitsAjoutes = value;
            }
        }

        public static ObservableCollection<CommandeAchat> LesCommandes
        {
            get
            {
                return lesCommandes;
            }

            set
            {
                lesCommandes = value;
            }
        }

        public CommandeAchat CommandeSelectionnee
        {
            get
            {
                return commandeSelectionnee;
            }

            set
            {
                commandeSelectionnee = value;
                OnPropertyChanged(nameof(CommandeSelectionnee));
            }
        }

        public ApplicationData()
        {
            LesTypes = TypeProduit.Read();
            LesCategories = Categorie.Read();
            LesCouleurs = Couleur.Read();
            LesProduits = Produit.Read();
            LesProduitsFiltres = new ObservableCollection<Produit>(LesProduits);
            LesTransports = ModeTransport.Read();
            LesCommandes = CommandeAchat.Read();
        }

        protected virtual void OnPropertyChanged(string proprietee)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proprietee));
        }

        public void FiltrerProduits()
        {
            var produitsFiltres = LesProduits.Where(produit => produit.Categorie != null && produit.Categorie.Type != null && produit.Categorie.Type.Num == TypeSelectionne.Num && produit.Categorie.Num == CategorieSelectionnee.Num);
            LesProduitsFiltres = new ObservableCollection<Produit>(produitsFiltres);
        }
    }
}
