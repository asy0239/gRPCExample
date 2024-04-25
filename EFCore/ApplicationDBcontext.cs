using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCore
{

    public class ApplicationDBcontext : DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null;
        
    }
}