using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SpaceTests
{
    public abstract class TestDatabase : IDisposable // Mock database using memory as source and SQLite as provider
    {
        private const string InMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;
        protected readonly SpaceContext DbContext;

        protected TestDatabase()
        {
            _connection = new SqliteConnection(InMemoryConnectionString);
            _connection.Open();
            var options = new DbContextOptionsBuilder<SpaceContext>()
                .UseSqlite(_connection)
                .Options;
            DbContext = new SpaceContext();
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
