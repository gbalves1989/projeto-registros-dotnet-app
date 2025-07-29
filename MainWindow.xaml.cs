using RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces;
using RegistrosEntradaSaidaAPP.Views.Empresas;
using RegistrosEntradaSaidaAPP.Views.Home;
using RegistrosEntradaSaidaAPP.Views.Motoristas;
using RegistrosEntradaSaidaAPP.Views.Veiculos;
using System.Windows;

namespace RegistrosEntradaSaidaAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new HomePage();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HomePage();
        }

        // Métodos para Empresas
        private void EmpresasCadastro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EmpresasCadastroPage();
        }

        private void EmpresasListar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EmpresasListPage();
        }


        // Métodos para Veículos
        private void VeiculosCadastro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VeiculosCadastroPage();
        }

        private void VeiculosListar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VeiculosListPage();
        }

        // Métodos para Motoristas
        private void MotoristasCadastro_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MotoristasCadastroPage();
        }

        private void MotoristasListar_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MotoristasListPage();
        }
    }
}