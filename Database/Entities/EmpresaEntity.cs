using System.ComponentModel.DataAnnotations.Schema;

namespace RegistrosEntradaSaidaAPP.Database.Entities
{
    public class EmpresaEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public ICollection<VeiculoEntity> Veiculos { get; set; }

        [NotMapped]
        public string CnpjFormatado
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Cnpj) || Cnpj.Length != 14)
                {
                    return Cnpj;
                }

                return $"{Cnpj.Substring(0, 2)}.{Cnpj.Substring(2, 3)}.{Cnpj.Substring(5, 3)}/{Cnpj.Substring(8, 4)}-{Cnpj.Substring(12, 2)}";
            }
        }
    }
}
