using System.Runtime.CompilerServices;
using Dapper;

namespace PlainQueryExtensions.PostgreSqlTests
{
    public static class Initializer
    {
        [ModuleInitializer]
        public static void Init()
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
        }        
    }
}