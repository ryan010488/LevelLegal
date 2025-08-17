using LevelLegal.Domain.Entities.Data;
using LevelLegal.Domain.Entities.Models;
using LevelLegal.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LevelLegal.Infrastructure.Repositories
{
    public class MatterRepository : Repository<Matter>, IMatterRepository
    {

        public MatterRepository(DataAccess db) : base(db)
        {
        }

        public async Task<List<Matter>> GetAllAsync()
        {
            var model = await DbSet.ToListAsync();

            return model;
        }

    }
}
