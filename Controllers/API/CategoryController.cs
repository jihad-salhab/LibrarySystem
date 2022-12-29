using LibrarySystem.Business.CategoryManager;
using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers.API
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private const string _controllerPrefix = "api/[controller]";
        #region Dependencies
        private readonly CategoryManagerCommand _categoryManagerCommand = new CategoryManagerCommand();
        private readonly CategoryManagerQuery _categoryManagerQuery = new CategoryManagerQuery();
        #endregion

        #region Queries

        [HttpGet]
        [Route(_controllerPrefix+"/GetAll")]
        public async Task<DataResult<List<Category>>> GetAll()
        {
            return await _categoryManagerQuery.GetAll();
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetById")]
        public async Task<DataResult<Category>> GetById([FromQuery] int objId)
        {
            return await _categoryManagerQuery.GetById(objId);
        }

        #endregion

        #region Commands
        [HttpPost]
        [Route(_controllerPrefix + "/Insert")]
        public async Task<DataResult<int>> Insert([FromBody]Category category)
        {
            return await _categoryManagerCommand.Insert(category);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Update")]
        public async Task<DataResult<int>> Update([FromBody] Category category)
        {
            return await _categoryManagerCommand.Update(category);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Delete")]
        public async Task<DataResult<int>> Delete([FromBody] Category category)
        {
            return await _categoryManagerCommand.Delete(category.CategoryId);
        }

        #endregion
    }
}
