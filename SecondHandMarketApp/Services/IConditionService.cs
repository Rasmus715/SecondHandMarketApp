using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SecondHandMarketApp.Data;
using SecondHandMarketApp.Models;

namespace SecondHandMarketApp.Services
{
    public interface IConditionService
    {
        Task<IEnumerable<Condition>> GetAllIConditions();
    }

    public class ConditionService : IConditionService
    {
        private readonly AppDbContext _db;

        public ConditionService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Condition>> GetAllIConditions()
        { 
            return await _db.Conditions.AsNoTracking().ToListAsync();
        }
    }
}
