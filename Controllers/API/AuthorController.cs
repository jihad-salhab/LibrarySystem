using LibrarySystem.Business.AuthorManager;
using LibrarySystem.Business.CategoryManager;
using LibrarySystem.Models;
using LibrarySystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers.API
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private const string _controllerPrefix = "api/[controller]";
        #region Dependencies
        private readonly AuthorManagerCommand _authorManagerCommand = new AuthorManagerCommand();
        private readonly AuthorManagerQuery _authorManagerQuery = new AuthorManagerQuery();
        #endregion

        #region Queries

        [HttpGet]
        [Route(_controllerPrefix + "/GetAll")]
        public async Task<DataResult<List<Author>>> GetAll()
        {
            return await _authorManagerQuery.GetAll();
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetById")]
        public async Task<DataResult<Author>> GetById([FromQuery] int objId)
        {
            return await _authorManagerQuery.GetById(objId);
        }

        #endregion

        #region Commands
        [HttpPost]
        [Route(_controllerPrefix + "/Insert")]
        public async Task<DataResult<int>> Insert([FromBody] Author author)
        {
            return await _authorManagerCommand.Insert(author);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Update")]
        public async Task<DataResult<int>> Update([FromBody] Author author)
        {
            return await _authorManagerCommand.Update(author);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Delete")]
        public async Task<DataResult<int>> Delete([FromBody] Author author)
        {
            return await _authorManagerCommand.Delete(author.AuthorId);
        }

        #endregion
    }
}

