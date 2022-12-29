using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;

namespace LibrarySystem.Data.AuthorDataManagers
{
    public class AuthorDataManagerCommand : IDataManagerCommand<Author>
    {
        #region PublicMethods
        public async Task<DataResult<int>> Delete(int objId)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.DeleteAuthor", objId);
        }

        public async Task<DataResult<int>> Insert(Author obj)
        {
            return await BaseDataManager.ExecuteScalar("dbo.InsertAuthor", obj.Name);
        }

        public async Task<DataResult<int>> Update(Author obj)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.UpdateAuthor", obj.AuthorId, obj.Name);

        }
        #endregion
    }
}
