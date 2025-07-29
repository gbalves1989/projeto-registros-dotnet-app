using Microsoft.EntityFrameworkCore;
using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces;

namespace RegistrosEntradaSaidaAPP.Database.Repositories
{
    public class EmpresaRepository : EmpresaRepInterface
    {
        private readonly DatabaseConnection _context;

        public EmpresaRepository()
        {
            _context = new DatabaseConnection(); 
        }

        public async Task AddAsync(EmpresaEntity empresa)
        {
            await _context.Empresas.AddAsync(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmpresaEntity>> GetAllAsync()
        {
            return await _context.Empresas.ToListAsync();
        }
    }
}
