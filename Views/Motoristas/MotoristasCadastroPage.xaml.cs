using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RegistrosEntradaSaidaAPP.Views.Motoristas
{
    public partial class MotoristasCadastroPage : Page
    {
        public MotoristasCadastroPage()
        {
            InitializeComponent();
        }

        private async void SalvarMotorista_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeMotoristaTextBox.Text))
            {
                MessageBox.Show("Nome é obrigatório!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string cpfApenasDigitos = new string(CpfTextBox.Text.Where(char.IsDigit).ToArray());
            if (string.IsNullOrWhiteSpace(cpfApenasDigitos) || cpfApenasDigitos.Length != 11)
            {
                MessageBox.Show("CPF é obrigatório e deve conter 11 dígitos!", "Erro de Validação", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                MotoristaEntity novoMotorista = new MotoristaEntity
                {
                    Nome = NomeMotoristaTextBox.Text,
                    Cpf = cpfApenasDigitos,
                };

                MotoristaRepository repository = new MotoristaRepository();
                await repository.AddAsync(novoMotorista);
                MessageBox.Show("Motorista cadastrado e adicionado à lista!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void CpfTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.Any(char.IsDigit);
        }

        private void CpfTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is not TextBox textBox) return;

            int oldCaretIndex = textBox.CaretIndex;
            string oldText = textBox.Text; 

            string originalTextDigits = new string(oldText.Where(char.IsDigit).ToArray());

            if (originalTextDigits.Length > 11)
            {
                originalTextDigits = originalTextDigits.Substring(0, 11);
            }

            string formattedText = string.Empty;
            if (originalTextDigits.Length > 0)
            {
                if (originalTextDigits.Length > 0) formattedText += originalTextDigits.Substring(0, Math.Min(3, originalTextDigits.Length));
                if (originalTextDigits.Length > 3) formattedText += "." + originalTextDigits.Substring(3, Math.Min(3, originalTextDigits.Length - 3));
                if (originalTextDigits.Length > 6) formattedText += "." + originalTextDigits.Substring(6, Math.Min(3, originalTextDigits.Length - 6));
                if (originalTextDigits.Length > 9) formattedText += "-" + originalTextDigits.Substring(9, Math.Min(2, originalTextDigits.Length - 9));
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
                    if (charAtOldCaret == '.' || charAtOldCaret == '-')
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

        public void LimparCampos()
        {
            NomeMotoristaTextBox.Clear();
            CpfTextBox.Clear();
        }
    }
}
