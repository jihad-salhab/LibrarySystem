using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.CategoryManager
{
    public class CategoryManagerQuery : IManagerQuery<Category>
    {
        private readonly CategoryDataManagerQuery _dataManagerInstance = new CategoryDataManagerQuery();

        public async Task<DataResult<List<Category>>> GetAll()
        {
            //TODO: Gaurd Causes
            var res = await _dataManagerInstance.GetAll();
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get categories";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No categories excesit";
                
            }
            res.Data!.OrderBy(x => x.Name);
            return res;
        }

        public async Task<DataResult<Category>> GetById(int objID)
        {
            var res = await _dataManagerInstance.GetById(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get category by {objID}";
            }
            return res;
        }
    }
}
