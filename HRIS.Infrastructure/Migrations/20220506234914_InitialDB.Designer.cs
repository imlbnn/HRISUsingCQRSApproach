﻿// <auto-generated />
using System;
using HRIS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HRIS.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220506234914_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRIS.Domain.Entities.CivilStatus", b =>
                {
                    b.Property<string>("Code")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Code");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Code");

                    b.ToTable("t_CivilStatus", "dbo");
                });

            modelBuilder.Entity("HRIS.Domain.Entities.Department", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Code");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Code");

                    b.ToTable("t_Department", "dbo");
                });

            modelBuilder.Entity("HRIS.Domain.Entities.DepartmentSection", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("Code");

                    b.Property<string>("DepartmentCode")
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("DepartmentCode");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Code", "DepartmentCode");

                    b.ToTable("t_DepartmentalSection", "dbo");
                });

            modelBuilder.Entity("HRIS.Domain.Entities.Employee", b =>
                {
                    b.Property<string>("EmpID")
                        .HasColumnType("nvarchar(12)")
                        .HasColumnName("EmpID");

                    b.Property<int>("BatchNo")
                        .HasColumnType("int")
                        .HasColumnName("BatchNo");

                    b.Property<string>("CivilStatusCode")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("CivilStatusCode");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("DepartmentCode");

                    b.Property<string>("DepartmentSectionCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasColumnName("DepartmentSectionCode");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("LastName");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("MiddleName");

                    b.Property<int>("SerialID")
                        .HasColumnType("int")
                        .HasColumnName("SerialID");

                    b.HasKey("EmpID");

                    b.ToTable("t_Employees", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}
