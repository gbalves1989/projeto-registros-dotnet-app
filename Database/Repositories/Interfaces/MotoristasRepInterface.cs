using RegistrosEntradaSaidaAPP.Database.Entities;

namespace RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces
{
    internal interface MotoristasRepInterface
    {
        Task<IEnumerable<MotoristaEntity>> GetAllAsync();
        Task AddAsync(MotoristaEntity motorista);
    }
}
