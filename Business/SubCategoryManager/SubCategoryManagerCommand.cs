using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Data.SubCategoryManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.SubCategoryManager
{
    public class SubCategoryManagerCommand : IManagerCommand<SubCategory>
    {
        private readonly SubCategoryDataManagerCommand _subDataManagerInstance = new SubCategoryDataManagerCommand();
        public async Task<DataResult<int>> Delete(int objId)
        {
            var res = await _subDataManagerInstance.Delete(objId);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to delete {objId}";
            }
            return res;
        }

        public async Task<DataResult<int>> Insert(SubCategory obj)
        {
            var res = await _subDataManagerInstance.Insert(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to insert {obj.Name}";
            }
            return res;
        }

        public async Task<DataResult<int>> Update(SubCategory obj)
        {
            var res = await _subDataManagerInstance.Update(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to update {obj.SubCategoryId}";
            }
            return res;
        }
    }
}
