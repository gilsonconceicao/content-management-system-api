﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cmsapplication.src.Contexts;

#nullable disable

namespace cmsapplication.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230817011521_added-biography")]
    partial class addedbiography
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cmsapplication.src.Models.Comments", b =>
                {
                    b.Property<Guid>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PostId1")
                        .HasColumnType("char(36)");

                    b.HasKey("PostId");

                    b.HasIndex("PostId1");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Biography")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("DisableComments")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HideLikesNumber")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Comments", b =>
                {
                    b.HasOne("cmsapplication.src.Models.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Post", b =>
                {
                    b.HasOne("cmsapplication.src.Models.Person", "Person")
                        .WithMany("RelatedPosts")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Person", b =>
                {
                    b.Navigation("RelatedPosts");
                });

            modelBuilder.Entity("cmsapplication.src.Models.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
