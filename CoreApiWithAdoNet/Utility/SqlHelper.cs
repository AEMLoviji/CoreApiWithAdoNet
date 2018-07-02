using System;
using System.Data;
using System.Data.SqlClient;

namespace CoreApiWithAdoNet.Utility
{
    public static class SqlHelper
    {
        public static string ExecuteProcedure(string connectionString, string procedureName, params SqlParameter[] commandParameters)
        {
            var result = string.Empty;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var command = sqlConnection.CreateCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = procedureName;
                    if (commandParameters != null)
                    {
                        command.Parameters.AddRange(commandParameters);
                    }
                    sqlConnection.Open();
                    var commandResult = command.ExecuteScalar();
                    if (commandResult != null)
                        result = Convert.ToString(commandResult);
                }
            }
            return result;
        }

        public static TData ExtecuteProcedure<TData>(string connectionString, string procedureName,
            Func<SqlDataReader, TData> translator,
            params SqlParameter[] commandParameters)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                using (var sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.CommandText = procedureName;
                    if (commandParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(commandParameters);
                    }
                    sqlConnection.Open();
                    using (var reader = sqlCommand.ExecuteReader())
                    {
                        TData elements;
                        try
                        {
                            elements = translator(reader);
                        }
                        finally
                        {
                            while (reader.NextResult())
                            { }
                        }
                        return elements;
                    }
                }
            }
        }

        #region Get Values from Sql Data Reader  
        public static string GetString(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? null : (string)reader[column];
        }

        public static int GetInt(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? 0 : (int)reader[column];
        }

        public static bool GetBoolean(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? false : (bool)reader[column];
        }

        public static DateTime GetDate(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(reader.GetOrdinal(column)) ? DateTime.MinValue : (DateTime)reader[column];
        }

        public static bool IsColumnExist(this IDataRecord dr, string column)
        {
            try
            {
                return (dr.GetOrdinal(column) >= 0);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
