using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RegistrosEntradaSaidaAPP.Views.Motoristas
{
    public partial class MotoristasListPage : Page
    {
        public ObservableCollection<MotoristaEntity> MotoristasListados { get; set; }

        public MotoristasListPage()
        {
            InitializeComponent();
            MotoristasListados = new ObservableCollection<MotoristaEntity>();
            MotoristasDataGrid.ItemsSource = MotoristasListados;

            Loaded += MotoristasListPage_Loaded;
        }

        private async void MotoristasListPage_Loaded(object sender, RoutedEventArgs e)
        {
            await CarregarMotoristasDoBanco();
        }

        private async Task CarregarMotoristasDoBanco()
        {
            MotoristasListados.Clear();

            try
            {
                MotoristaRepository repository = new MotoristaRepository();
                var motoristas = await repository.GetAllAsync();
                foreach (var motorista in motoristas)
                {
                    MotoristasListados.Add(motorista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar motoristas: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
