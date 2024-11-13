using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RedesSociaisApp.Infrastructure.Persistence
{
    public class RedesSociaisDesignTimeDbContextFactory : IDesignTimeDbContextFactory<RedesSociaisDbContext>
    {
        public RedesSociaisDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Port=3306;DataBase=RedesSociaisDb;Uid=root;Pwd=gpxpst;";

            var optionsBuilder = new DbContextOptionsBuilder<RedesSociaisDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new RedesSociaisDbContext(optionsBuilder.Options);
        }
    }
}