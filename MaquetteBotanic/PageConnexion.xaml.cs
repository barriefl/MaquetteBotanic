using MaquetteBotanic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaquetteBotanic
{
    /// <summary>
    /// Interaction logic for PageConnexion.xaml
    /// </summary>
    public partial class PageConnexion : Window
    {
        private static PageConnexion session;
        private DataAccess data = new DataAccess();

        public PageConnexion()
        {
            InitializeComponent();
        }

        public static PageConnexion Session
        {
            get
            {
                if (session == null)
                {
                    session = new PageConnexion();
                }
                return session;
            }
        }

        private void butConnexion_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataAccess.Instance.DeconnexionBD();
            session = null;
        }
    }
}