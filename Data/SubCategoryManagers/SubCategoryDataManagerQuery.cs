using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.Data.SubCategoryManagers
{
    public class SubCategoryDataManagerQuery : IDataManagerQuery<SubCategory>
    {
        private CategoryDataManagerQuery _categoryDataManagerQuery = new CategoryDataManagerQuery();
        private async Task<Category> GetCategoryById(int objId)
        {
            var res = await _categoryDataManagerQuery!.GetById(objId);
            return res.Data!;

        }
        #region Mapper
        private SubCategory _subCategoryMapper(SqlDataReader row)
        {
            return new SubCategory()
            {
                SubCategoryId = int.Parse(row["SubCategoryId"].ToString()!),
                Name = row["Name"].ToString()!,
                CategoryId = int.Parse(row["CategoryId"].ToString()!),

            };
        }
        #endregion

        #region Public Methods
        public async Task<DataResult<List<SubCategory>>> GetAll()
        {
            var res = await BaseDataManager.GetSPItems("dbo.GetAllSubCategories", _subCategoryMapper);
            foreach (var item in res.Data!)
            {
                item.Category = await GetCategoryById(item.CategoryId);
            }
            return res;


        }

        public async Task<DataResult<SubCategory>> GetById(int objId)
        {
            var res = await BaseDataManager.GetSPItem<SubCategory>("dbo.GetSubCategoryById", _subCategoryMapper, objId);
            res.Data!.Category = await GetCategoryById(res.Data!.CategoryId);
            return res;
        }

        public async Task<DataResult<List<SubCategory>>> GetByCategoryId(int objId)
        {
            var res = await BaseDataManager.GetSPItems<SubCategory>("dbo.GetSubCategoriesByCategoryId", _subCategoryMapper, objId);
            foreach (var item in res.Data!)
            {
                item.Category = await GetCategoryById(item.CategoryId);
            }
            return res;
        }
        #endregion
    }
}
