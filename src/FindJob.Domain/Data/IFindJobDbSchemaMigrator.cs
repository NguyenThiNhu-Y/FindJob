using System.Threading.Tasks;

namespace FindJob.Data
{
    public interface IFindJobDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
