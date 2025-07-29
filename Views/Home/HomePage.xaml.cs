using Newtonsoft.Json;
using RegistrosEntradaSaidaAPP.Responses;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using RegistrosEntradaSaidaAPP.Database.Repositories;

namespace RegistrosEntradaSaidaAPP.Views.Home
{
    public partial class HomePage : Page
    {
        public ObservableCollection<string> SearchResults { get; set; }
        private readonly HttpClient _httpClient = new HttpClient();
        private const string BaseUrl = "https://localhost:7122";

        public HomePage()
        {
            InitializeComponent();
            SearchResults = new ObservableCollection<string>();
        }

        private async void Pesquisar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VeiculoRepository repository = new VeiculoRepository();
                var veiculo = await repository.GetByPlacaAsync(SearchTextBox.Text);

                // Altere "posts" para o endpoint correto da sua API, por exemplo, "api/registros"
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/api/v1/Registros/{veiculo.Id}");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                // **Ajuste principal aqui:** Desserializa para ResponseWrapper
                ResponseWrapper apiResponse = JsonConvert.DeserializeObject<ResponseWrapper>(responseBody);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Status Code: {apiResponse.StatusCode}");
                sb.AppendLine($"Mensagem: {apiResponse.Message}");
                sb.AppendLine("--- Registros Encontrados ---");

                if (apiResponse.Data != null && apiResponse.Data.Any()) // Verifica se há dados na lista
                {
                    foreach (var registro in apiResponse.Data)
                    {
                        sb.AppendLine($"ID: {registro.Id}, Veículo: {registro.VeiculoId}, Motorista: {registro.MotoristaId}");
                        sb.AppendLine($"  Entrada: {registro.DataEntrada} às {registro.HoraEntrada}");
                        sb.AppendLine($"  Saída: {(string.IsNullOrEmpty(registro.DataSaida) ? "Pendente" : $"{registro.DataSaida} às {registro.HoraSaida}")}");
                        sb.AppendLine("--------------------");
                    }
                }
                else
                {
                    sb.AppendLine("Nenhum registro encontrado.");
                }

                RegistrosApiDataGrid.ItemsSource = apiResponse.Data;
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

                MessageBox.Show($"Erro ao salvar empresa: {errorMessage}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
