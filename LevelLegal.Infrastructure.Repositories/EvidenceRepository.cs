using LevelLegal.Domain.Entities.Data;
using LevelLegal.Domain.Entities.Models;
using LevelLegal.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelLegal.Infrastructure.Repositories
{
    public class EvidenceRepository : Repository<Evidence>, IEvidenceRepository
    {

        public EvidenceRepository(DataAccess db) : base(db)
        {
        }

        public async Task<List<Evidence>> GetAllAsync(int matterId = 0)
        {
            var model = await DbSet
                .Include(m => m.Matter)
                .Where(m => matterId == 0 || m.MatterId == matterId)
                .ToListAsync();

            return model;
        }

    }
}
