
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext
{


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>op):base(op)
    {
        
    }
}