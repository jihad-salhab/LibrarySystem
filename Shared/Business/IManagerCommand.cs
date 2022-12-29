using LibrarySystem.Shared.Models;

namespace LibrarySystem.Shared.Business
{
    public interface IManagerCommand <T>
    {
        Task<DataResult<int>> Insert(T obj);
        Task<DataResult<int>> Delete(int objId);
        Task<DataResult<int>> Update(T obj);
    }
}
