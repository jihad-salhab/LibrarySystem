using LibrarySystem.Data.BookDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.BookManager
{
    public class BookManagerQuery : IManagerQuery<Book>
    {
        private readonly BookDataManagerQuery _bookDataManagerInstance = new BookDataManagerQuery();

        public async Task<DataResult<List<Book>>> GetAll()
        {
            //TODO: Gaurd Causes
            var res = await _bookDataManagerInstance.GetAll();
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Books";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No Books excesit";

            }
            res.Data!.OrderBy(x => x.Title);
            return res;
        }

        public async Task<DataResult<Book>> GetById(int objID)
        {
            var res = await _bookDataManagerInstance.GetById(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Book by {objID}";
            }
            return res;
        }


        public async Task<DataResult<List<Book>>> GetByCategoryId(int objID)
        {
            var res = await _bookDataManagerInstance.GetByCategoryId(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Books";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No Books excesit";

            }
            res.Data!.OrderBy(x => x.Title);
            return res;
        }
        public async Task<DataResult<List<Book>>> GetBySubCategoryId(int objID)
        {
            var res = await _bookDataManagerInstance.GetBySubCategoryId(objID);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to get Books";
                return res;
            }
            if (res.Data!.Count == 0)
            {
                res.Reason = $"No Books excesit";

            }
            res.Data!.OrderBy(x => x.Title);
            return res;
        }
    }
}
