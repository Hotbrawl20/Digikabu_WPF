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

namespace DigikabuWPF
{
    /// <summary>
    /// Interaktionslogik für MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
            this.Hide();
            GetSK();
            this.Show();
        }
        private async void GetSK()
        {
            var tosplit = await WebsiteCon.GetUNKL();
            var splittxt = tosplit.Split(';');
            User.Text = splittxt[0];
            Klasse.Text = splittxt[1];
        }
        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonPopUpLogout_Click_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ExitApp(object sender, RoutedEventArgs e)
        {
            // TO DO Logout
            this.Close();
        }

        private void ShowTermine(object sender, MouseButtonEventArgs e)
        {

        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            switch ((sender as ListView).SelectedIndex) 
            {
                case 0:
                    TAB.SelectedIndex = 0;
                    Fenster.Text = "Digikabu - Termine";
                    break;
                case 1:
                    TAB.SelectedIndex = 1;
                    Fenster.Text = "Digikabu - Wochenstundenplan";
                    break;
                case 2:
                    TAB.SelectedIndex = 2;
                    Fenster.Text = "Digikabu - Schulaufgabenplan";
                    break;
                case 3:
                    TAB.SelectedIndex = 3;
                    Fenster.Text = "Digikabu - Speiseplan";
                    break;
                case 4:
                    TAB.SelectedIndex = 4;
                    Fenster.Text = "Digikabu - Entschuldigung";
                    break;
                case 5:
                    TAB.SelectedIndex = 5;
                    Fenster.Text = "Digikabu - Fehlzeiten";
                    break;
                case 6:
                    TAB.SelectedIndex = 6;
                    Fenster.Text = "Digikabu - Einstellungen";
                    break;
            }
            
        }

        private void MinimizeApp(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
