using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeEquipment.DbRepository.Extensions;
using OfficeEquipment.DbRepository.Models;

namespace OfficeEquipment.Repository.Configuration
{
    public class TypeEquipmentConfiguration : DbEntityConfiguration<TypeEquipment>
    {
        public override void Configuration(EntityTypeBuilder<TypeEquipment> modelBuilder)
        {
            modelBuilder.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

            modelBuilder.Property(e => e.Kind).HasMaxLength(50);

            modelBuilder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}