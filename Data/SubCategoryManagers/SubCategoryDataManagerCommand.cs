using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;

namespace LibrarySystem.Data.SubCategoryManagers
{
    public class SubCategoryDataManagerCommand : IDataManagerCommand<SubCategory>
    {
        #region PublicMethods
        public async Task<DataResult<int>> Delete(int objId)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.DeleteSubCategory", objId);
        }

        public async Task<DataResult<int>> Insert(SubCategory obj)
        {
            return await BaseDataManager.ExecuteScalar("dbo.InsertSubCategory", obj.Name, obj.CategoryId);
        }

        public async Task<DataResult<int>> Update(SubCategory obj)
        {
            return await BaseDataManager.ExecuteNonQuery("dbo.UpdateSubCategory", obj.SubCategoryId, obj.Name, obj.CategoryId);

        }
        #endregion
    }
}