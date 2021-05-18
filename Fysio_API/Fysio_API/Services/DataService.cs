using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fysio_API.Models;

namespace Fysio_API.Services
{
    public interface IDataService
    {
        Task PutData(Data data);
    }

    public class DataService : IDataService
    {
        private readonly FysioDbContext _context;
        public DataService(FysioDbContext context)
        {
            _context = context;
        }

        public async Task PutData(Data data)
        {
            await _context.Datas.AddAsync(data);
            await _context.SaveChangesAsync();
        }
    }
}
