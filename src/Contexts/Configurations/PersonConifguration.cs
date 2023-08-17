using cmsapplication.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmsapplication.src.Contexts.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    { 
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => new { 
                p.Id  
            });

            builder.HasMany(p => p.RelatedPosts)
                .WithOne(p => p.Person)
                .OnDelete(DeleteBehavior.Cascade);
        }
    } 
}
