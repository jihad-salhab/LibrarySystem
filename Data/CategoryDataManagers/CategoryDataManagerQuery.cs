using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.Data.CategoryDataManagers
{
    public  class CategoryDataManagerQuery : IDataManagerQuery<Category>
    {

        #region Mapper
        private Category _categoryMapper(SqlDataReader row)
        {
            return new Category()
            {
                CategoryId = int.Parse(row["CategoryId"].ToString()!),
                Name = row["Name"].ToString()!

            };
        }
        #endregion

        #region Public Methods
        public async Task<DataResult<List<Category>>> GetAll()
        {
            return await BaseDataManager.GetSPItems("dbo.GetAllCategories", _categoryMapper);
        }

        public async Task<DataResult<Category>> GetById(int objId)
        {
            return await BaseDataManager.GetSPItem<Category>("dbo.GetCategoryById", _categoryMapper, objId);
        }
        #endregion
    }
}
