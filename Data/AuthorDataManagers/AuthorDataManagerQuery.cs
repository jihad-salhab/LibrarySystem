using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.Data.AuthorDataManagers
{
    public class AuthorDataManagerQuery : IDataManagerQuery<Author>
    {

        #region Mapper
        private Author _authorMapper(SqlDataReader row)
        {
            return new Author()
            {
                AuthorId = int.Parse(row["AuthorId"].ToString()!),
                Name = row["Name"].ToString()!

            };
        }
        #endregion

        #region Public Methods
        public async Task<DataResult<List<Author>>> GetAll()
        {
            return await BaseDataManager.GetSPItems("dbo.GetAllAuthors", _authorMapper);
        }

        public async Task<DataResult<Author>> GetById(int objId)
        {
            return await BaseDataManager.GetSPItem<Author>("dbo.GetAuthorById", _authorMapper, objId);
        }
        #endregion
    }
}
