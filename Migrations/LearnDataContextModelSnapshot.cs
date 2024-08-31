﻿// <auto-generated />
using System;
using LearnAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearnAPI.Migrations
{
    [DbContext(typeof(LearnDataContext))]
    partial class LearnDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LearnAPI.Models.TblCustomer", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal?>("Creditlimit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Code");

                    b.ToTable("tbl_customer");
                });

            modelBuilder.Entity("LearnAPI.Models.TblRefreshToken", b =>
                {
                    b.Property<string>("Userid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("userid");

                    b.Property<string>("Refreshtoken")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("refreshtoken");

                    b.Property<string>("Tokenid")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("tokenid");

                    b.HasKey("Userid");

                    b.ToTable("tbl_refreshtoken");
                });

            modelBuilder.Entity("LearnAPI.Models.TblUser", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<int?>("Failattempt")
                        .HasColumnType("int")
                        .HasColumnName("failattempt");

                    b.Property<bool?>("Isactive")
                        .HasColumnType("bit")
                        .HasColumnName("isactive");

                    b.Property<bool?>("Islocked")
                        .HasColumnType("bit")
                        .HasColumnName("islocked");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("password");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("phone");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("role");

                    b.HasKey("Username");

                    b.ToTable("tbl_user");
                });
#pragma warning restore 612, 618
        }
    }
}
