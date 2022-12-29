using LibrarySystem.Shared;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace LibrarySystem.Data
{
    public abstract class BaseDataManager
    {

        public static async Task<DataResult<int>> ExecuteScalar(string spName, params object[] parameters)
        {
            try
            {
                int lastAddedID = 0;
                using (SqlConnection sqlConnection = new SqlConnection(GlobalConstantsSingleton.GetInstance().ConnectionString))
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand(spName, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlCommandBuilder.DeriveParameters(command);
                    if (parameters.Length > 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters[i + 1].Value = parameters[i];
                        }
                    }
                    lastAddedID = Convert.ToInt32(await command.ExecuteScalarAsync());
                    await sqlConnection.CloseAsync();
                    DataResult<int> result = new DataResult<int>()
                    {
                        Data = lastAddedID,
                        DidFail = false,
                        Reason = $"Inserted Item With Id {lastAddedID} ",
                    };
                    return result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {spName}: {e.Message}");
                DataResult<int> result = new DataResult<int>()
                {
                    DidFail = true,
                    Reason = $"An Error Occurred, Please Try Again",
                };
                return result;
            }
        }
        public static async Task<DataResult<int>> ExecuteNonQuery(string spName, params object[] parameters)
        {
            try
            {
                int affectedRowsCount = 0;
                using (SqlConnection sqlConnection = new SqlConnection(GlobalConstantsSingleton.GetInstance().ConnectionString))
                {
                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand(spName, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlCommandBuilder.DeriveParameters(command);
                    if (parameters.Length > 0)
                    {
                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters[i + 1].Value = parameters[i];
                        }
                    }
                    affectedRowsCount = await command.ExecuteNonQueryAsync();
                    await sqlConnection.CloseAsync();
                    DataResult<int> result = new DataResult<int>()
                    {
                        Data = affectedRowsCount,
                        DidFail = false,
                        Reason = $"Affected {affectedRowsCount} items",
                    };
                    return result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {spName}: {e.Message}");
                DataResult<int> result = new DataResult<int>()
                {
                    DidFail = true,
                    Reason = $"An Error Occurred, Please Try Again",
                };
                return result;
            }
        }
        public static async Task<DataResult<List<T>>> GetSPItems<T>(string spName,
                                      Func<SqlDataReader, T> mapper,
                                      params object[] parameters)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(GlobalConstantsSingleton.GetInstance().ConnectionString))
                {

                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand(spName, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlCommandBuilder.DeriveParameters(command);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters[i + 1].Value = parameters[i];
                    }
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    List<T> items = new List<T>();
                    while (await reader.ReadAsync())
                    {
                        items.Add(mapper(reader));
                    }
                    await reader.CloseAsync();
                    await sqlConnection.CloseAsync();
                    DataResult<List<T>> result = new DataResult<List<T>>()
                    {
                        Data = items,
                        DidFail = false,
                        Reason = $"Returned {items.Count} items",
                    };
                    return result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occurred While Executing {spName}: {e.Message}");
                DataResult<List<T>> result = new DataResult<List<T>>()
                {
                    DidFail = true,
                    Reason = $"An Error Occurred, Please Try Again",
                };
                return result;
            }

        }
        public static async Task<DataResult<T>> GetSPItem<T>(string spName,
                                     Func<SqlDataReader, T> mapper,
                                     params object[] parameters)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(GlobalConstantsSingleton.GetInstance().ConnectionString))
                {

                    await sqlConnection.OpenAsync();
                    SqlCommand command = new SqlCommand(spName, sqlConnection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    SqlCommandBuilder.DeriveParameters(command);
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        command.Parameters[i + 1].Value = parameters[i];
                    }
                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    await reader.ReadAsync();
                    DataResult<T> result = new DataResult<T>()
                    {
                        Data = mapper(reader),
                        DidFail = false,
                        Reason = $"Returned item",
                    };
                    await reader.CloseAsync();
                    await sqlConnection.CloseAsync();
                    return result;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occurred While Executing {spName}: {e.Message}");
                DataResult<T> result = new DataResult<T>()
                {
                    DidFail = true,
                    Reason = $"An Error Occurred, Please Try Again",
                };
                return result;
            }

        }
    }
}
