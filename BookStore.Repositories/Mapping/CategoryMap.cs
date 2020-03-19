using BookStorage.Models;
using System.Data.Entity.ModelConfiguration;

namespace BookStore.Persistence.Mapping
{
    public class CategoryMap
        : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .HasMaxLength(30).IsRequired();

            HasMany(x => x.Books)
                .WithRequired(x => x.Category);

        }

    }
}