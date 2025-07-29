using RegistrosEntradaSaidaAPP.Database.Entities;

namespace RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces
{
    public interface EmpresaRepInterface
    {
        Task<IEnumerable<EmpresaEntity>> GetAllAsync();

        Task AddAsync(EmpresaEntity empresa);
    }
}
