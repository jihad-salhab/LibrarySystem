using LibrarySystem.Business.SubCategoryManager;
using LibrarySystem.Models;
using LibrarySystem.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers.API
{
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private const string _controllerPrefix = "api/[controller]";
        #region Dependencies
        private readonly SubCategoryManagerCommand _subCategoryManagerCommand = new SubCategoryManagerCommand();
        private readonly SubCategoryManagerQuery _subCategoryManagerQuery = new SubCategoryManagerQuery();
        #endregion

        #region Queries

        [HttpGet]
        [Route(_controllerPrefix + "/GetAll")]
        public async Task<DataResult<List<SubCategory>>> GetAll()
        {
            return await _subCategoryManagerQuery.GetAll();
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetById")]
        public async Task<DataResult<SubCategory>> GetById([FromQuery] int objId)
        {
            return await _subCategoryManagerQuery.GetById(objId);
        }

        [HttpGet]
        [Route(_controllerPrefix + "/GetByCategoryId")]
        public async Task<DataResult<List<SubCategory>>> GetByCategoryId([FromQuery] int objId)
        {
            return await _subCategoryManagerQuery.GetByCategoryId(objId);
        }

        #endregion

        #region Commands
        [HttpPost]
        [Route(_controllerPrefix + "/Insert")]
        public async Task<DataResult<int>> Insert([FromBody] SubCategory subCategory)
        {
            return await _subCategoryManagerCommand.Insert(subCategory);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Update")]
        public async Task<DataResult<int>> Update([FromBody] SubCategory subCategory)
        {
            return await _subCategoryManagerCommand.Update(subCategory);
        }

        [HttpPost]
        [Route(_controllerPrefix + "/Delete")]
        public async Task<DataResult<int>> Delete([FromBody] SubCategory subCategory)
        {
            return await _subCategoryManagerCommand.Delete(subCategory.SubCategoryId);
        }

        #endregion
    }
}
