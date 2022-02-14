using Microsoft.EntityFrameworkCore;

namespace BlazorOmega.Data;

public class ApplicationContext:DbContext
{
    public DbSet<Data> datas { get; set; }
    public DbSet<User> users { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    { 
        
    }
}