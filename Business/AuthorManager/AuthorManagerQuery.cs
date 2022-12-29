using LibrarySystem.Data.AuthorDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.AuthorManager
{
    public class AuthorManagerQuery : IManagerQuery<Author>
    {
        private readonly AuthorDataManagerQuery _dataManagerInstance = new AuthorDataManagerQuery();

        public async Task<DataResult<List<Author>>> GetAll()
        {
            //TODO: Gaurd Causes
            var res = await _dataManagerInstance.GetAll();
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Authors";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No Authors excesit";

            }
            res.Data!.OrderBy(x => x.Name);
            return res;
        }

        public async Task<DataResult<Author>> GetById(int objID)
        {
            var res = await _dataManagerInstance.GetById(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Author by {objID}";
            }
            return res;
        }
    }
}
