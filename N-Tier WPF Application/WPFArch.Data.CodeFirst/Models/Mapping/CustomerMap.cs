using System.Data.Entity.ModelConfiguration;
using WPFArch.Data.CodeFirst.Models;

namespace WPFArch.Data.CodeFirst.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            HasKey(t => t.CustomerId);

            // Properties
            Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            ToTable("Customer");
            Property(t => t.CustomerId).HasColumnName("CustomerId");
            Property(t => t.FirstName).HasColumnName("FirstName");
            Property(t => t.LastName).HasColumnName("LastName");
        }
    }
}
