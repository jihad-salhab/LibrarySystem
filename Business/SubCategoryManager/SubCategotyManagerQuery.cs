using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Data.SubCategoryManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.SubCategoryManager
{
    public class SubCategoryManagerQuery : IManagerQuery<SubCategory>
    {
        private readonly SubCategoryDataManagerQuery _subDataManagerInstance = new SubCategoryDataManagerQuery();

        public async Task<DataResult<List<SubCategory>>> GetAll()
        {
            //TODO: Gaurd Causes
            var res = await _subDataManagerInstance.GetAll();
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get sub categories";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No sub categories excesit";

            }
            res.Data!.OrderBy(x => x.Name);
            return res;
        }

        public async Task<DataResult<SubCategory>> GetById(int objID)
        {
            var res = await _subDataManagerInstance.GetById(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get sub category by {objID}";
            }
            return res;
        }


        public async Task<DataResult<List<SubCategory>>> GetByCategoryId(int objID)
        {
            var res = await _subDataManagerInstance.GetByCategoryId(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get sub categories";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No sub categories excesit";

            }
            res.Data!.OrderBy(x => x.Name);
            return res;
        }
    }
}
