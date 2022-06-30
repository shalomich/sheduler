﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sheduler.RestApi;

namespace Sheduler.RestApi.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220630032006_RenameTables")]
    partial class RenameTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sheduler.RestApi.Model.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApprovingId")
                        .HasColumnType("int");

                    b.Property<string>("ChoosendDates")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SendingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("_currentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RequestStatus");

                    b.HasKey("Id");

                    b.HasIndex("ApprovingId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Requests");

                    b.HasDiscriminator<string>("RequestType").HasValue("Request");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AccountCreatingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex("PostId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.RemoteWorkRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.Request");

                    b.Property<string>("WorkingPlan")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("На удаленную работу");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.RestRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.Request");

                    b.Property<int?>("ReplacingId")
                        .HasColumnType("int");

                    b.HasIndex("ReplacingId");

                    b.HasDiscriminator().HasValue("RestRequest");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.DayOffRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.RestRequest");

                    b.HasDiscriminator().HasValue("На отгул");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.VacationRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.RestRequest");

                    b.Property<bool>("IsDateChangeable")
                        .HasColumnType("bit");

                    b.Property<string>("VacationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("На отпуск");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.WeekendVacationRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.RestRequest");

                    b.HasDiscriminator().HasValue("На выходной в счет отпуска");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.WeekendWorkOffRequest", b =>
                {
                    b.HasBaseType("Sheduler.RestApi.Model.Requests.RestRequest");

                    b.Property<string>("WorkOffDates")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("В выходной за счет отработки");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.Request", b =>
                {
                    b.HasOne("Sheduler.RestApi.Model.User", "Approving")
                        .WithMany()
                        .HasForeignKey("ApprovingId");

                    b.HasOne("Sheduler.RestApi.Model.User", "Creator")
                        .WithMany("Requests")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approving");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.User", b =>
                {
                    b.HasOne("Sheduler.RestApi.Model.Post", "Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.Requests.RestRequest", b =>
                {
                    b.HasOne("Sheduler.RestApi.Model.User", "Replacing")
                        .WithMany()
                        .HasForeignKey("ReplacingId");

                    b.Navigation("Replacing");
                });

            modelBuilder.Entity("Sheduler.RestApi.Model.User", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
