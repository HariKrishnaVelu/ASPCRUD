using Microsoft.EntityFrameworkCore;

namespace ASPCRUD.Model
{
    public class CRUDContext: DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options)
        {

        }
        public DbSet<Student> students { get; set; }
    }
}
