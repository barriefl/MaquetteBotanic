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
    /// Logique d'interaction pour VoirArticle.xaml
    /// </summary>
    public partial class VoirArticle : Window
    {
        public VoirArticle()
        {
            InitializeComponent();
        }

        private void butAjouterQuantite_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
