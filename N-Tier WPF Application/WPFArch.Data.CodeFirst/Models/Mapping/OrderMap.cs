using System.Data.Entity.ModelConfiguration;

namespace WPFArch.Data.CodeFirst.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            HasKey(t => t.OrderId);

            // Properties
            Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            ToTable("Orders");
            Property(t => t.OrderId).HasColumnName("OrderId");
            Property(t => t.CustomerId).HasColumnName("CustomerId");
            Property(t => t.Description).HasColumnName("Description");
            Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            HasOptional(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
