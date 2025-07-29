namespace RegistrosEntradaSaidaAPP.Database.Entities
{
    public class VeiculoEntity
    {
        public int Id { get; set; } 
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }

        public int EmpresaId { get; set; }
        public EmpresaEntity Empresa { get; set; }
    }
}
