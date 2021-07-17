﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace WebCoreDbContext
{

 public  static class GetCount
    {
        public static int CountByRawSql(this DbContext dbContext, string sql)
        {
            int result = -1;
            SqlConnection connection = dbContext.Database.GetDbConnection() as SqlConnection;

            try
            {
                connection.Open();

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = sql;

                    //foreach (KeyValuePair<string, object> parameter in parameters)
                    //    command.Parameters.AddWithValue(parameter.Key, parameter.Value);

                    using (DbDataReader dataReader = command.ExecuteReader())
                        if (dataReader.HasRows)
                            while (dataReader.Read())
                            {
                                result = dataReader.GetInt32(0);  
                            }
                                
                }
            }

            // We should have better error handling here
            catch (System.Exception e) { }

            finally { connection.Close(); }

            return result;
        }

    }
}
