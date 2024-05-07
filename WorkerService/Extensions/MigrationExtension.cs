using Infrastructure.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace WorkerService.Extensions
{
    public static class MigrationExtension
    {
        public static async Task<WebApplication> Migration(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                // TODO: need to add check here to only run migrations if it was applicable
                var db = scope.ServiceProvider.GetRequiredService<ApplicationDBcontext>();
                await db.Database.MigrateAsync();
            }
            return app;
        }
    }
}
