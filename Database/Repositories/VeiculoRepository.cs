using Microsoft.EntityFrameworkCore;
using RegistrosEntradaSaidaAPP.Database.Entities;
using RegistrosEntradaSaidaAPP.Database.Repositories.Interfaces;

namespace RegistrosEntradaSaidaAPP.Database.Repositories
{
    public class VeiculoRepository : VeiculoRepInterface
    {
        private readonly DatabaseConnection _context;

        public VeiculoRepository()
        {
            _context = new DatabaseConnection();
        }

        public async Task AddAsync(VeiculoEntity veiculo)
        {
            await _context.Veiculos.AddAsync(veiculo);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<VeiculoEntity>> GetAllAsync()
        {
            return await _context.Veiculos.Include(v => v.Empresa).ToListAsync();
        }

        public async Task<VeiculoEntity> GetByPlacaAsync(string placa)
        {
            string placaParaPesquisar = placa.ToUpper();

            return await _context.Veiculos
                                 .Include(v => v.Empresa) 
                                 .FirstOrDefaultAsync(v => v.Placa == placaParaPesquisar);
        }
    }
}
