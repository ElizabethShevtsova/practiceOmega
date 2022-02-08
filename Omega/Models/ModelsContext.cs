using Microsoft.EntityFrameworkCore;

namespace Omega.Models;

public class ModelsContext:DbContext,IModelsContext
{
    public DbSet<Data> datas { get; set; }
    public DbSet<User> users { get; set; }


    public ModelsContext(DbContextOptions<ModelsContext> options) : base(options)
    { 
        
    }
}