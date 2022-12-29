using LibrarySystem.Data.AuthorDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.AuthorManager
{

    public class AuthorManagerCommand : IManagerCommand<Author>
    {
        private readonly AuthorDataManagerCommand _dataManagerInstance = new AuthorDataManagerCommand();
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

        public async Task<DataResult<int>> Insert(Author obj)
        {
            var res = await _dataManagerInstance.Insert(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to insert {obj.Name}";
            }
            return res;
        }

        public async Task<DataResult<int>> Update(Author obj)
        {
            var res = await _dataManagerInstance.Update(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to update {obj.AuthorId}";
            }
            return res;
        }
    }

}
