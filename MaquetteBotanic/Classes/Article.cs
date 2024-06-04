using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquetteBotanic
{
    public class Article : INotifyPropertyChanged
    {
        private Produit produit;
        private string exposition;
        private string floraison;
        private string tailleAdulte;

        public Produit Produit
        {
            get
            {
                return this.produit;
            }

            set
            {
                this.produit = value;
                OnPropertyChanged(nameof(Produit));
                OnPropertyChanged(nameof(Exposition));
                OnPropertyChanged(nameof(Floraison));
                OnPropertyChanged(nameof(TailleAdulte));
            }
        }

        public string Exposition
        {
            get
            {
                var exposition = Produit?.Caracteristiques.FirstOrDefault(c => c.NumCaracteristique == 1);
                return exposition?.Valeur ?? "N/A";
            }
        }

        public string Floraison
        {
            get
            {
                var floraison = Produit?.Caracteristiques.FirstOrDefault(c => c.NumCaracteristique == 2);
                return floraison?.Valeur ?? "N/A";
            }
        }

        public string TailleAdulte
        {
            get
            {
                var tailleAdulte = Produit?.Caracteristiques.FirstOrDefault(c => c.NumCaracteristique == 3);
                return tailleAdulte?.Valeur ?? "N/A";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
