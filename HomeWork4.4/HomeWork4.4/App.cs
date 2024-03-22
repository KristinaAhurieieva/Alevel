using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using HomeWork4._4.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeWork4._4
{
    public class App
    {
        private readonly ApplicationDbContext _dbContext;

        public App(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Start()
        {
            var data = await _dbContext.Pets.ToListAsync();
        }
    }
}

