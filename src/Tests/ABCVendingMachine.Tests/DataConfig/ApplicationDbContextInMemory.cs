using ABCVendingMachine.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABCVendingMachine.Tests.DataConfig
{
    public static class ApplicationDbContextInMemory
    {
        public static ApplicationDBContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: $"Test.Db")
                .Options;

            return new ApplicationDBContext(options);
        }
    }
}
