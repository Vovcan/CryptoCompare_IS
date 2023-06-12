using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binance_0._1
{
    
    internal class CryptoDbContext : DbContext
    {
        private string connectionString;

        public CryptoDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<TokenData> token_data { get; set; }
        public DbSet<News> news { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
