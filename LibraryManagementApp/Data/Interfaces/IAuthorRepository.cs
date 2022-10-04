using LibraryManagementApp.Data.Model;
using System.Collections.Generic;

namespace LibraryManagementApp.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();  
        Author GetWithBooks(int id);
    }
}
