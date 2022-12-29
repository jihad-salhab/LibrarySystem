using LibrarySystem.Shared.Models;

namespace LibrarySystem.Shared.Data
{
    public interface IDataManagerCommand<T>
    {
        Task<DataResult<int>> Insert(T obj);
        Task<DataResult<int>> Delete(int objId);
        Task<DataResult<int>> Update(T obj);

    }
}
