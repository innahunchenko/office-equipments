using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OfficeEquipment.DbRepository.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity<TEntity>(entityConfiguration.Configuration);
        }
    }

    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configuration(EntityTypeBuilder<TEntity> entity);
    }
}