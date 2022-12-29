using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;

namespace LibrarySystem.Data.CategoryDataManagers
{
    public  class CategoryDataManagerCommand : IDataManagerCommand<Category>
    {
        #region PublicMethods
        public async Task<DataResult<int>> Delete(int objId)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.DeleteCategory", objId);
        }

        public async Task<DataResult<int>> Insert(Category obj)
        {
            return await BaseDataManager.ExecuteScalar("dbo.InsertCategory", obj.Name);
        }

        public async Task<DataResult<int>> Update(Category obj)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.UpdateCategory", obj.CategoryId, obj.Name);

        }
        #endregion
    }
}
