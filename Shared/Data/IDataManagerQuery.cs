using LibrarySystem.Shared.Models;

namespace LibrarySystem.Shared.Data
{
    public interface IDataManagerQuery <T>
    {
        Task<DataResult<T>> GetById(int objId);
        Task<DataResult<List<T>>> GetAll();
    }
}
