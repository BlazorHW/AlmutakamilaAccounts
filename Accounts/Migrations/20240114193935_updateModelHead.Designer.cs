﻿// <auto-generated />
using System;
using Accounts.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Accounts.Migrations
{
    [DbContext(typeof(AccountingDbContext))]
    [Migration("20240114193935_updateModelHead")]
    partial class updateModelHead
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Accounts.Model.AccountType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccNumer")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("accountTypes");
                });

            modelBuilder.Entity("Accounts.Model.Accountss", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccNumer")
                        .HasColumnType("int");

                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsProfit")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccName")
                        .IsUnique();

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("ParentId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("Accounts.Model.CostCenter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccNumer")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AccName")
                        .IsUnique();

                    b.ToTable("costCenters");
                });

            modelBuilder.Entity("Accounts.Model.MakeJournalBody", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AccNumer")
                        .HasColumnType("int");

                    b.Property<Guid>("AccountssId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("BalanceMovement")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CostCenterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Credit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Debit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Details")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid?>("MakeJournalHeadId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AccountssId");

                    b.HasIndex("CostCenterId");

                    b.HasIndex("MakeJournalHeadId");

                    b.ToTable("makeJournalBodies");
                });

            modelBuilder.Entity("Accounts.Model.MakeJournalHead", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("EntryJournal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("makeJournalHeads");
                });

            modelBuilder.Entity("Accounts.Model.Accountss", b =>
                {
                    b.HasOne("Accounts.Model.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Accounts.Model.Accountss", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AccountType");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Accounts.Model.MakeJournalBody", b =>
                {
                    b.HasOne("Accounts.Model.Accountss", "accountss")
                        .WithMany()
                        .HasForeignKey("AccountssId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Accounts.Model.CostCenter", "costCenter")
                        .WithMany()
                        .HasForeignKey("CostCenterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Accounts.Model.MakeJournalHead", null)
                        .WithMany("makeJournals")
                        .HasForeignKey("MakeJournalHeadId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("accountss");

                    b.Navigation("costCenter");
                });

            modelBuilder.Entity("Accounts.Model.MakeJournalHead", b =>
                {
                    b.Navigation("makeJournals");
                });
#pragma warning restore 612, 618
        }
    }
}
