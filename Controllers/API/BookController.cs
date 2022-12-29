using LibrarySystem.Business.BookManager;
using LibrarySystem.Business.SubCategoryManager;
using LibrarySystem.Models;
using LibrarySystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers.API
{
    [ApiController]
    public class BookController : ControllerBase
    {
        private const string _controllerPrefix = "api/[controller]";
        #region Dependencies
        private readonly BookManagerCommand _bookManagerCommand = new BookManagerCommand();
        private readonly BookManagerQuery _bookManagerQuery = new BookManagerQuery();
        #endregion

        #region Queries

        [HttpGet]
        [Route(_controllerPrefix + "/GetAll")]
        public async Task<DataResult<List<Book>>> GetAll()
        {
            return await _bookManagerQuery.GetAll();
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetById")]
        public async Task<DataResult<Book>> GetById([FromQuery] int objId)
        {
            return await _bookManagerQuery.GetById(objId);
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetByCategoryId")]
        public async Task<DataResult<List<Book>>> GetByCategoryId([FromQuery] int objId)
        {
            return await _bookManagerQuery.GetByCategoryId(objId);
        }
        [HttpGet]
        [Route(_controllerPrefix + "/GetBySubCategoryId")]
        public async Task<DataResult<List<Book>>> GetBySubCategoryId([FromQuery] int objId)
        {
            return await _bookManagerQuery.GetBySubCategoryId(objId);
        }

        #endregion

        #region Commands
        [HttpPost]
        [Route(_controllerPrefix + "/Insert")]
        public async Task<DataResult<int>> Insert([FromBody] Book book)
        {
            return await _bookManagerCommand.Insert(book);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Update")]
        public async Task<DataResult<int>> Update([FromBody] Book book)
        {
            return await _bookManagerCommand.Update(book);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Delete")]
        public async Task<DataResult<int>> Delete([FromBody] Book book)
        {
            return await _bookManagerCommand.Delete(book.BookId);
        }

        #endregion
    }
}
