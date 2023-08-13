﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cmsapplication.src.Contexts;

#nullable disable

namespace cmsapplication.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cmsapplication.src.Models.Comments", b =>
                {
                    b.Property<Guid>("PostId")
                        .HasColumnType("char(36)");

                    b.Property<string>("comment")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("PostId", "comment");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("disableComments")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("hideLikesNumber")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Comments", b =>
                {
                    b.HasOne("cmsapplication.src.Models.Post", "Post")
                        .WithMany("comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Post", b =>
                {
                    b.Navigation("comments");
                });
#pragma warning restore 612, 618
        }
    }
}