﻿using cmsapplication.src.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cmsapplication.src.Contexts.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(p => new {p.Id});
        }
    }
}
