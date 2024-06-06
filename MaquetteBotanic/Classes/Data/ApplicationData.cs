using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class ApplicationData
    {
        private static ObservableCollection<TypeProduit> lesTypes;
        private static ObservableCollection<Categorie> lesCategories;
        private static ObservableCollection<Couleur> lesCouleurs;
        private static ObservableCollection<Produit> lesProduits;
        private static ObservableCollection<ModeTransport> lesTransports;
        private static ObservableCollection<Produit> lesProduitsAjoutes = new ObservableCollection<Produit>();
        private static ObservableCollection<CommandeAchat> lesCommandes;

        public static ObservableCollection<TypeProduit> LesTypes
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

        public ApplicationData()
        {
            LesTypes = TypeProduit.Read();
            LesCategories = Categorie.Read();
            LesCouleurs = Couleur.Read();
            LesProduits = Produit.Read();
            LesTransports = ModeTransport.Read();
            //LesCommandes = CommandeAchat.Read();
        }
    }
}
