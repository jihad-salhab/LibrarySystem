using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;

namespace LibrarySystem.Data.BookDataManagers
{
    public class BookDataManagerCommand : IDataManagerCommand<Book>
    {
        #region PublicMethods
        public async Task<DataResult<int>> Delete(int objId)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.DeleteBook", objId);
        }

        public async Task<DataResult<int>> Insert(Book obj)
        {
            return await BaseDataManager.ExecuteScalar("dbo.InsertBook", obj.Title, obj.AuthorId, obj.CategoryId, obj.SubCategoryId);
        }

        public async Task<DataResult<int>> Update(Book obj)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.UpdateBook", obj.BookId, obj.Title, obj.AuthorId, obj.CategoryId, obj.SubCategoryId);

        }
        #endregion

    }
}

