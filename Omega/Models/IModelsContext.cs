using Microsoft.EntityFrameworkCore;

namespace Omega.Models;

public interface IModelsContext
{
    public DbSet<Data> datas { get; set; }
    public DbSet<User> users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}