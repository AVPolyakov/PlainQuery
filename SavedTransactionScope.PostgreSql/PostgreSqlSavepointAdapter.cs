using System;
using System.Data;
using SavedTransactionScopes;

namespace SavedTransactionScope.PostgreSql
{
    public class PostgreSqlSavepointAdapter : ISavepointAdapter
    {
        public string SetSavepoint(IDbCommand command)
        {
            var savePointName = Guid.NewGuid().ToString("N");
            
            command.CommandText = $"SAVEPOINT _{savePointName}";
            
            command.ExecuteNonQuery();
            
            return savePointName;
        }

        public void RollbackToSavepoint(IDbCommand command, string savePointName)
        {
            command.CommandText = $"ROLLBACK TO SAVEPOINT _{savePointName}";
            
            command.ExecuteNonQuery();
        }
    }
}