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
    /// Logique d'interaction pour VisualiserCommandes.xaml
    /// </summary>
    public partial class VisualiserCommandes : Window
    {
        public VisualiserCommandes()
        {
            InitializeComponent();
        }

        private void butRetourMenu_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Close();
            menu.Show();
        }
    }
}
