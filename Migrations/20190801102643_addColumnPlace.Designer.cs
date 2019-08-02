﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using wevi.Models;

namespace wevi.Migrations
{
    [DbContext(typeof(WevDbContext))]
    [Migration("20190801102643_addColumnPlace")]
    partial class addColumnPlace
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("wevi.Models.Banner", b =>
                {
                    b.Property<int>("bannerid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("image");

                    b.HasKey("bannerid");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("wevi.Models.Comment", b =>
                {
                    b.Property<int>("commentid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("comment")
                        .IsRequired();

                    b.Property<DateTime?>("commentdate")
                        .IsRequired();

                    b.Property<int>("productid");

                    b.Property<int>("userid");

                    b.HasKey("commentid");

                    b.HasIndex("productid");

                    b.HasIndex("userid");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("wevi.Models.Event", b =>
                {
                    b.Property<int>("eventid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bannerevent");

                    b.Property<int>("countingevent");

                    b.Property<string>("detailevent");

                    b.Property<string>("eventcode");

                    b.Property<DateTime?>("eventdate");

                    b.Property<string>("eventname");

                    b.Property<string>("linkstring");

                    b.Property<string>("place");

                    b.Property<string>("statusevent");

                    b.HasKey("eventid");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("wevi.Models.HistoryEvent", b =>
                {
                    b.Property<int>("hisevid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("eventid");

                    b.Property<int>("userid");

                    b.HasKey("hisevid");

                    b.HasIndex("eventid");

                    b.HasIndex("userid");

                    b.ToTable("HistoryEvent");
                });

            modelBuilder.Entity("wevi.Models.HistoryProduct", b =>
                {
                    b.Property<int>("hisproid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("productid");

                    b.Property<int>("userid");

                    b.HasKey("hisproid");

                    b.HasIndex("productid");

                    b.HasIndex("userid");

                    b.ToTable("HistoryProduct");
                });

            modelBuilder.Entity("wevi.Models.Product", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bannerproduct");

                    b.Property<string>("linkstring");

                    b.Property<string>("productcode");

                    b.Property<string>("productdetail");

                    b.Property<string>("productname");

                    b.HasKey("productid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("wevi.Models.User", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<DateTime?>("createdon");

                    b.Property<DateTime?>("dateofbirth");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("fullname")
                        .HasMaxLength(200);

                    b.Property<string>("gender")
                        .HasMaxLength(20);

                    b.Property<string>("interest")
                        .HasMaxLength(100);

                    b.Property<string>("major")
                        .HasMaxLength(50);

                    b.Property<string>("participantcode");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("phone")
                        .HasMaxLength(20);

                    b.Property<string>("profilepicture");

                    b.Property<int>("role");

                    b.Property<string>("school")
                        .HasMaxLength(80);

                    b.HasKey("userid");

                    b.ToTable("User");
                });

            modelBuilder.Entity("wevi.Models.Comment", b =>
                {
                    b.HasOne("wevi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wevi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("wevi.Models.HistoryEvent", b =>
                {
                    b.HasOne("wevi.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("eventid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wevi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("wevi.Models.HistoryProduct", b =>
                {
                    b.HasOne("wevi.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("wevi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
