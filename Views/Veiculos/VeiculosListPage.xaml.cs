using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RegistrosEntradaSaidaAPP.Views.Veiculos
{
    public partial class VeiculosListPage : Page
    {
        public ObservableCollection<VeiculoEntity> VeiculosListados { get; set; }

        public VeiculosListPage()
        {
            InitializeComponent();
            VeiculosListados = new ObservableCollection<VeiculoEntity>();
            VeiculosDataGrid.ItemsSource = VeiculosListados;

            Loaded += VeiculosListPage_Loaded;
        }

        private async void VeiculosListPage_Loaded(object sender, RoutedEventArgs e)
        {
            await CarregarVeiculosDoBanco();
        }

        private async Task CarregarVeiculosDoBanco()
        {
            VeiculosListados.Clear();

            try
            {
                VeiculoRepository repository = new VeiculoRepository();
                var veiculos = await repository.GetAllAsync();
                foreach (var veiculo in veiculos)
                {
                    VeiculosListados.Add(veiculo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar veículos: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
