using LibrarySystem.Data.BookDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Business;
using LibrarySystem.Shared.Models;
using System.Diagnostics;

namespace LibrarySystem.Business.BookManager
{
    public class BookManagerCommand : IManagerCommand<Book>
    {
        private readonly BookDataManagerCommand _bookDataManagerInstance = new BookDataManagerCommand();
        public async Task<DataResult<int>> Delete(int objId)
        {
            var res = await _bookDataManagerInstance.Delete(objId);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to delete {objId}";
            }
            return res;
        }

        public async Task<DataResult<int>> Insert(Book obj)
        {
            var res = await _bookDataManagerInstance.Insert(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to insert {obj.Title}";
            }
            return res;
        }

        public async Task<DataResult<int>> Update(Book obj)
        {
            var res = await _bookDataManagerInstance.Update(obj);
            if (res.DidFail)
            {
                Debug.WriteLine(res.Reason);
                res.Reason = $"Failed to update {obj.BookId}";
            }
            return res;
        }
    }
}
