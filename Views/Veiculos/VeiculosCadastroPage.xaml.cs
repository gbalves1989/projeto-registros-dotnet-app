using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Windows;
using System.Windows.Controls;

namespace RegistrosEntradaSaidaAPP.Views.Veiculos
{
    public partial class VeiculosCadastroPage : Page
    {
        public VeiculosCadastroPage()
        {
            InitializeComponent();
        }

        private async void SalvarVeiculo_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(MarcaTextBox.Text) ||
                string.IsNullOrWhiteSpace(ModeloTextBox.Text) ||
                string.IsNullOrWhiteSpace(PlacaTextBox.Text) ||
                string.IsNullOrWhiteSpace(AnoTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmpresaTextBox.Text))
            {
                MessageBox.Show("Todos os campos de veículo são obrigatórios!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(AnoTextBox.Text, out int ano))
            {
                MessageBox.Show("Ano inválido. Por favor, insira um número válido para o ano.", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                VeiculoEntity novoVeiculo = new VeiculoEntity
                {
                    Marca = MarcaTextBox.Text,
                    Modelo = ModeloTextBox.Text,
                    Ano = ano,
                    Placa = PlacaTextBox.Text.ToUpper(),
                    EmpresaId = int.Parse(EmpresaTextBox.Text)
                };

                VeiculoRepository repository = new VeiculoRepository();
                await repository.AddAsync(novoVeiculo);
                MessageBox.Show("Veículo cadastrado e adicionado à lista!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                LimparCampos();
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nDetalhes: " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null)
                    {
                        errorMessage += "\nMais Detalhes: " + ex.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show($"Erro ao salvar veículo: {errorMessage}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparCampos();
            }
        }
        
        private void LimparCampos()
        {
            MarcaTextBox.Clear();
            ModeloTextBox.Clear();
            AnoTextBox.Clear();
            PlacaTextBox.Clear();
            EmpresaTextBox.Clear();
        }
    }
}
