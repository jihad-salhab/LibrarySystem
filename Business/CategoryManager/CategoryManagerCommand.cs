using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;
using System.Security.Cryptography;

namespace LibrarySystem.Business.CategoryManager
{
    public class CategoryManagerCommand : IManagerCommand<Category>
    {
        private readonly CategoryDataManagerCommand _dataManagerInstance = new CategoryDataManagerCommand();
        public async Task<DataResult<int>> Delete(int objId)
        {
            var res = await _dataManagerInstance.Delete(objId);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to delete {objId}";
            }
            return res;
        }

        public async Task<DataResult<int>> Insert(Category obj)
        {
            var res = await _dataManagerInstance.Insert(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to insert {obj.Name}";
            }
            return res;
        }

        public async Task<DataResult<int>> Update(Category obj)
        {
            var res = await _dataManagerInstance.Update(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to update {obj.CategoryId}";
            }
            return res;
        }
    }
}
