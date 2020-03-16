using BookStorage.Models;
using System.Data.Entity.ModelConfiguration;

namespace BookStoreApp.Mapping
{
    public class ActorMap
        : EntityTypeConfiguration<Actor>
    {
        public ActorMap()
        {
            ToTable("Actor");

            HasKey(x => x.Id);

            Property(x => x.Name).HasMaxLength(60).IsRequired();

            HasMany(x => x.Books)
                .WithMany(x => x.Actors)
                .Map(x => x.ToTable("BookActor"));


        }
    }
}