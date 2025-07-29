using Microsoft.EntityFrameworkCore;
using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces;

namespace RegistrosEntradaSaidaAPP.Database.Repositories
{
    internal class MotoristaRepository : MotoristasRepInterface
    {
        private readonly DatabaseConnection _context;

        public MotoristaRepository()
        {
            _context = new DatabaseConnection();
        }

        public async Task AddAsync(MotoristaEntity motorista)
        {
            await _context.Motoristas.AddAsync(motorista);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MotoristaEntity>> GetAllAsync()
        {
            return await _context.Motoristas.ToListAsync();
        }
    }
}
