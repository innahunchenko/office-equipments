using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OfficeEquipment.DbRepository.Extensions;
using OfficeEquipment.DbRepository.Models;

namespace OfficeEquipment.Repository.Configuration
{
    public class EquipmentConfiguration : DbEntityConfiguration<Equipment>
    {
        public override void Configuration(EntityTypeBuilder<Equipment> modelBuilder)
        {
            modelBuilder.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

            modelBuilder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            modelBuilder.HasOne(d => d.TypeEquipment)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TypeEquipmentId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}