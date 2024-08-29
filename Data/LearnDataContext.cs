using LearnAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Data
{
    public class LearnDataContext : DbContext
    {
        public LearnDataContext(DbContextOptions<LearnDataContext> options) : base(options)
        {

        }

        public DbSet<TblCustomer> TblCustomers {get; set;}
    }
}