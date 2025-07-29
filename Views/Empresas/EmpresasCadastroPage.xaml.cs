using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RegistrosEntradaSaidaAPP.Views.Empresas
{
    public partial class EmpresasCadastroPage : Page
    {
        public EmpresasCadastroPage()
        {
            InitializeComponent();
        }

        private async void SalvarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeTextBox.Text) || string.IsNullOrWhiteSpace(CnpjTextBox.Text))
            {
                MessageBox.Show("Nome da Empresa e CNPJ são obrigatórios!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (NomeTextBox.Text.Length < 3)
            {
                MessageBox.Show("Nome da Empresa deve conter no mínimo 3 caracters!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string cnpjApenasDigitos = new string(CnpjTextBox.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(cnpjApenasDigitos) || cnpjApenasDigitos.Length != 14)
            {
                MessageBox.Show("CNPJ é obrigatório e deve conter 14 dígitos!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                EmpresaEntity novaEmpresa = new EmpresaEntity
                {
                    Nome = NomeTextBox.Text,
                    Cnpj = cnpjApenasDigitos,
                };

                EmpresaRepository repository = new EmpresaRepository();
                await repository.AddAsync(novaEmpresa);
                MessageBox.Show("Empresa cadastrada e adicionada à lista!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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

                MessageBox.Show($"Erro ao salvar empresa: {errorMessage}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                LimparCampos();
            }
        }

        private void CnpjTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(char.IsDigit);
        }

        private void CnpjTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is not TextBox textBox) return;

            int oldCaretIndex = textBox.CaretIndex;
            string oldText = textBox.Text; 

            string originalTextDigits = new string(oldText.Where(char.IsDigit).ToArray());

            if (originalTextDigits.Length > 14)
            {
                originalTextDigits = originalTextDigits.Substring(0, 14);
            }

            string formattedText = string.Empty;
            if (originalTextDigits.Length > 0)
            {
                if (originalTextDigits.Length > 0) formattedText += originalTextDigits.Substring(0, Math.Min(2, originalTextDigits.Length));
                if (originalTextDigits.Length > 2) formattedText += "." + originalTextDigits.Substring(2, Math.Min(3, originalTextDigits.Length - 2));
                if (originalTextDigits.Length > 5) formattedText += "." + originalTextDigits.Substring(5, Math.Min(3, originalTextDigits.Length - 5));
                if (originalTextDigits.Length > 8) formattedText += "/" + originalTextDigits.Substring(8, Math.Min(4, originalTextDigits.Length - 8));
                if (originalTextDigits.Length > 12) formattedText += "-" + originalTextDigits.Substring(12, Math.Min(2, originalTextDigits.Length - 12));
            }

            if (textBox.Text != formattedText)
            {
                textBox.Text = formattedText;

                int newCaretIndex = oldCaretIndex;

                if (newCaretIndex > formattedText.Length)
                {
                    newCaretIndex = formattedText.Length;
                }
                else if (newCaretIndex > 0 && newCaretIndex <= formattedText.Length)
                {
                    char charAtOldCaret = formattedText[newCaretIndex - 1];
                    if (charAtOldCaret == '.' || charAtOldCaret == '/' || charAtOldCaret == '-')
                    {
                        newCaretIndex++; 
                    }
                }

                if (newCaretIndex > formattedText.Length)
                {
                    newCaretIndex = formattedText.Length;
                }

                textBox.CaretIndex = newCaretIndex;
            }
        }

        private void LimparCampos()
        {
            NomeTextBox.Clear();
            CnpjTextBox.Clear();
        }
    }
}
