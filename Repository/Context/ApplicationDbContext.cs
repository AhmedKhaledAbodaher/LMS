
using DomainLayer.Configuration;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext:DbContext
{
    #region Props
    public DbSet<Category> Category { get; set; }          
    public DbSet<Material> Material { get; set; }          
    public DbSet<Level> Level { get; set; }          
    public DbSet<Course> Courses { get; set; }          
    public DbSet<CourseFiles> CourseFiles { get; set; }          
    public DbSet<CourseFileType> CourseFileType { get; set; }          
    #endregion 

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>op):base(op)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);

    }
}