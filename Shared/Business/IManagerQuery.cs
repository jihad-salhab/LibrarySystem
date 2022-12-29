using LibrarySystem.Shared.Models;

namespace LibrarySystem.Shared.Business
{
    public interface IManagerQuery<T>
    {
        Task<DataResult<List<T>>> GetAll();
        Task<DataResult<T>> GetById(int objID);

    }
}
