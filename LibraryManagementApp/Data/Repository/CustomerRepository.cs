using LibraryManagementApp.Data.Interfaces;
using LibraryManagementApp.Data.Model;

namespace LibraryManagementApp.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
