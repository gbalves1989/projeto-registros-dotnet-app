namespace RegistrosEntradaSaidaAPP.Responses
{
    public class Registro
    {
        public int Id { get; set; }
        public int VeiculoId { get; set; }
        public int MotoristaId { get; set; }
        public string DataEntrada { get; set; }
        public string HoraEntrada { get; set; }
        public string DataSaida { get; set; }
        public string HoraSaida { get; set; }
    }
}
