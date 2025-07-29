using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Views.Veiculos;

namespace RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces
{
    internal interface VeiculoRepInterface
    {
        Task<IEnumerable<VeiculoEntity>> GetAllAsync();
        Task AddAsync(VeiculoEntity veiculo);
        Task<VeiculoEntity> GetByPlacaAsync(string placa);
    }
}
