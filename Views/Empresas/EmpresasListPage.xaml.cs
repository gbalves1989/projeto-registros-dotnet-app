using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RegistrosEntradaSaidaAPP.Views.Empresas
{
    public partial class EmpresasListPage : Page
    {
        public ObservableCollection<EmpresaEntity> EmpresasListadas { get; set; }

        public EmpresasListPage()
        {
            InitializeComponent();
            EmpresasListadas = new ObservableCollection<EmpresaEntity>();
            EmpresasDataGrid.ItemsSource = EmpresasListadas;

            Loaded += EmpresasListPage_Loaded;
        }

        private async void EmpresasListPage_Loaded(object sender, RoutedEventArgs e)
        {
            await CarregarEmpresasDoBanco();
        }

        private async Task CarregarEmpresasDoBanco()
        {
            EmpresasListadas.Clear(); 

            try
            {
                EmpresaRepository repository = new EmpresaRepository();
                var empresas = await repository.GetAllAsync();
                foreach (var empresa in empresas)
                {
                    EmpresasListadas.Add(empresa);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar empresas: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
