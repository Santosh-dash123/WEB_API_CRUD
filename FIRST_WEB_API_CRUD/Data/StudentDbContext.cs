using FIRST_WEB_API_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace FIRST_WEB_API_CRUD.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<STUDENT> STUDENT { get; set; }
    }
}
