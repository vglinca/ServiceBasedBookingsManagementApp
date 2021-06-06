using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace OnlineBookingAggregatorApp.Persistence.Extensions
{
    public static class DatabaseFacadeExtensions
    {
        public static Task<int> ExecuteSqlFromStringAsync(this DatabaseFacade databaseFacade, string query)
        {
            databaseFacade.BeginTransactionAsync(IsolationLevel.ReadUncommitted);
            var rows = databaseFacade.ExecuteSqlRawAsync(query);
            databaseFacade.CommitTransactionAsync();

            return rows;
        }
        public static int ExecuteSqlQueryFromFile(this DatabaseFacade databaseFacade, string filename)
        {
            filename = filename.Replace('/', '.')
                .Replace('\\', '.');

            var assembly = Assembly.GetExecutingAssembly();

            return databaseFacade.ExecuteSqlQueryFromResource($"{assembly.GetName().Name}.SQL.{filename}");
        }

        private static int ExecuteSqlQueryFromResource(this DatabaseFacade databaseFacade, string resourceName, params object[] parameters)
        {
            var fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            var buffer = new byte[fileStream.Length].AsSpan();

            fileStream.Read(buffer);

            var preamble = Encoding.UTF8.GetPreamble();
            if (preamble.Length > 0 && buffer.StartsWith(preamble.AsSpan()))
            {
                buffer = buffer.Slice(preamble.Length);
            }

            var sqlString = Encoding.Default.GetString(buffer);
            databaseFacade.BeginTransaction(IsolationLevel.ReadUncommitted);
            var rows = databaseFacade.ExecuteSqlRaw(sqlString, parameters);
            databaseFacade.CommitTransaction();

            return rows;
        }
    }
}