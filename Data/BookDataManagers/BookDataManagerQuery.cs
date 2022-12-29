using LibrarySystem.Data.AuthorDataManagers;
using LibrarySystem.Data.CategoryDataManagers;
using LibrarySystem.Data.SubCategoryManagers;
using LibrarySystem.Models;
using LibrarySystem.Shared.Data;
using LibrarySystem.Shared.Models;
using Microsoft.Data.SqlClient;

namespace LibrarySystem.Data.BookDataManagers
{
    public class BookDataManagerQuery : IDataManagerQuery<Book>
    {
        private CategoryDataManagerQuery _categoryDataManagerQuery = new CategoryDataManagerQuery();
        private SubCategoryDataManagerQuery _subCategoryDataManagerQuery = new SubCategoryDataManagerQuery();
        private AuthorDataManagerQuery _authorDataManagerQuery = new AuthorDataManagerQuery();
        private async Task<Category> GetCategoryById(int objId)
        {
            var res = await _categoryDataManagerQuery!.GetById(objId);
            return res.Data!;

        }
        private async Task<SubCategory> GetSubCategoryById(int objId)
        {
            var res = await _subCategoryDataManagerQuery!.GetById(objId);
            return res.Data!;

        }
        private async Task<Author> GetAuthorById(int objId)
        {
            var res = await _authorDataManagerQuery!.GetById(objId);
            return res.Data!;

        }
        private async Task<Book> InitBookObjects(Book book)
        {
            book.Author = await GetAuthorById(book.AuthorId);
            book.Category = await GetCategoryById(book.CategoryId);
            book.SubCategory = await GetSubCategoryById(book.SubCategoryId);
            return book;
        }
        #region Mapper
        private Book _bookMapper(SqlDataReader row)
        {
            return new Book()
            {
                BookId = int.Parse(row["BookId"].ToString()!),
                Title = row["Title"].ToString()!,
                AuthorId = int.Parse(row["AuthorId"].ToString()!),
                CategoryId = int.Parse(row["CategoryId"].ToString()!),
                SubCategoryId = int.Parse(row["SubCategoryId"].ToString()!),

            };
        }
        #endregion

        #region Public Methods
        public async Task<DataResult<List<Book>>> GetAll()
        {
            var res = await BaseDataManager.GetSPItems("dbo.GetAllBooks", _bookMapper);
            for (int i = 0; i < res.Data!.Count; i++)
            {
                res.Data[i] = await InitBookObjects( res.Data[i]);
            }
            return res;


        }

        public async Task<DataResult<Book>> GetById(int objId)
        {
            var res = await BaseDataManager.GetSPItem<Book>("dbo.GetBookById", _bookMapper, objId);
            res.Data= await InitBookObjects(res.Data!);
            return res;
        }

        public async Task<DataResult<List<Book>>> GetByCategoryId(int objId)
        {
            var res = await BaseDataManager.GetSPItems<Book>("dbo.GetBooksByCategoryId", _bookMapper, objId);
            for (int i = 0; i < res.Data!.Count; i++)
            {
                res.Data[i] = await InitBookObjects(res.Data[i]);
            }
            return res;
        }
        public async Task<DataResult<List<Book>>> GetBySubCategoryId(int objId)
        {
            var res = await BaseDataManager.GetSPItems<Book>("dbo.GetBooksBySubCategoryId", _bookMapper, objId);
            for (int i = 0; i < res.Data!.Count; i++)
            {
                res.Data[i] = await InitBookObjects(res.Data[i]);
            }
            return res;
        }
        #endregion
    }
}
