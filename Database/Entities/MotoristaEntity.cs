using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrosEntradaSaidaAPP.Database.Entities
{
    public class MotoristaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        [NotMapped] 
        public string CpfFormatado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Cpf) || Cpf.Length != 11)
                {
                    return Cpf; 
                }
                
                return $"{Cpf.Substring(0, 3)}.{Cpf.Substring(3, 3)}.{Cpf.Substring(6, 3)}-{Cpf.Substring(9, 2)}";
            }
        }
    }
}
