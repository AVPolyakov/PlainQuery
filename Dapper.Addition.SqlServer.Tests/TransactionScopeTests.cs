﻿using System;
using System.Threading.Tasks;
using SavedTransactionScopes;
using Xunit;

namespace Dapper.Addition.SqlServer.Tests
{
    [Collection(nameof(FixtureCollection))]
    public class TransactionScopeTests: IClassFixture<TransactionScopeFixture>, IDisposable
    {
        private readonly IDbExecutor _db;
        private readonly LocalTransactionScope _transactionScope;
        
        public TransactionScopeTests(TransactionScopeFixture fixture,
            DatabaseFixture databaseFixture)
        {
            _db = databaseFixture.Db;

            TransactionAmbientData.Current = fixture.TransactionAmbientData;
            
            _transactionScope = LocalTransactionScope.CreateSaved(databaseFixture.SavepointExecutor);
        }
        
        public void Dispose() => _transactionScope.Dispose();

        [Fact]
        public async Task UpdateToV2_Success()
        {
            {
                var name = await _db.QuerySingleAsync<string>("SELECT Name FROM Clients WHERE Id = @id", new { id = 2 });
                Assert.Equal("Client", name);
            }

            await _db.ExecuteAsync("UPDATE Clients SET Name = @Name WHERE Id = @Id", new { Name = "Client.v2", Id = 2 });

            {
                var name = await _db.QuerySingleAsync<string>("SELECT Name FROM Clients WHERE Id = @id", new { id = 2 });
                Assert.Equal("Client.v2", name);
            }
        }

        [Fact]
        public async Task UpdateToV3_Success()
        {
            {
                var name = await _db.QuerySingleAsync<string>("SELECT Name FROM Clients WHERE Id = @id", new { id = 2 });
                Assert.Equal("Client", name);
            }

            await _db.ExecuteAsync("UPDATE Clients SET Name = @Name WHERE Id = @Id", new { Name = "Client.v3", Id = 2 });

            {
                var name = await _db.QuerySingleAsync<string>("SELECT Name FROM Clients WHERE Id = @id", new { id = 2 });
                Assert.Equal("Client.v3", name);
            }
        }
    }
}