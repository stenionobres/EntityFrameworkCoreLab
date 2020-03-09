﻿// <auto-generated />
using System;
using EntityFrameworkCoreLab.Persistence.EntityFrameworkContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFrameworkCoreLab.Persistence.Migrations.Experiments
{
    [DbContext(typeof(ExperimentsDbContext))]
    [Migration("20200309192045_CreatePrincipalAndDependentEntityByFluentApiMTM")]
    partial class CreatePrincipalAndDependentEntityByFluentApiMTM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.DTODataType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ArrayBytesProperty")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("BoolProperty")
                        .HasColumnType("bit");

                    b.Property<bool?>("BoolPropertyNullable")
                        .HasColumnType("bit");

                    b.Property<string>("CharProperty")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("CharPropertyNullable")
                        .HasColumnType("nvarchar(1)");

                    b.Property<DateTime>("DateProperty")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DatePropertyNullable")
                        .HasColumnType("date");

                    b.Property<DateTime>("DateTimeProperty")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimePropertyNullable")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DecimalLowerPrecisionProperty")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<decimal>("DecimalProperty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("DecimalPropertyNullable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("DoubleProperty")
                        .HasColumnType("float");

                    b.Property<double?>("DoublePropertyNullable")
                        .HasColumnType("float");

                    b.Property<float>("FloatProperty")
                        .HasColumnType("real");

                    b.Property<float?>("FloatPropertyNullable")
                        .HasColumnType("real");

                    b.Property<int>("IntProperty")
                        .HasColumnType("int");

                    b.Property<int?>("IntPropertyNullable")
                        .HasColumnType("int");

                    b.Property<long>("LongProperty")
                        .HasColumnType("bigint");

                    b.Property<long?>("LongPropertyNullable")
                        .HasColumnType("bigint");

                    b.Property<string>("StringPropertyLimitedLength")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("StringPropertyMaxLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringPropertyRequired")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeSpanProperty")
                        .HasColumnType("time");

                    b.Property<TimeSpan?>("TimeSpanPropertyNullable")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("DTODataType");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByConventionMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByConventionMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByDataAnnotationMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByDataAnnotationMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByFluentApiMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByFluentApiMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByConventionMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DependentEntityByConventionMTMId")
                        .HasColumnType("int");

                    b.Property<int>("PrincipalEntityByConventionMTMId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DependentEntityByConventionMTMId");

                    b.HasIndex("PrincipalEntityByConventionMTMId");

                    b.ToTable("MiddleEntityByConventionMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByDataAnnotationMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ForeignKeyToDependentEntity")
                        .HasColumnType("int");

                    b.Property<int>("ForeignKeyToPrincipalEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForeignKeyToDependentEntity");

                    b.HasIndex("ForeignKeyToPrincipalEntity");

                    b.ToTable("MiddleEntityByDataAnnotationMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByFluentApiMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ForeignKeyToDependentEntity")
                        .HasColumnType("int");

                    b.Property<int>("ForeignKeyToPrincipalEntity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ForeignKeyToDependentEntity");

                    b.HasIndex("ForeignKeyToPrincipalEntity");

                    b.ToTable("MiddleEntityByFluentApiMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByConventionMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByConventionMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByDataAnnotationMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByDataAnnotationMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByFluentApiMTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByFluentApiMTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByConventionOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<int>("PrincipalEntityByConventionOTMId")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PrincipalEntityByConventionOTMId");

                    b.ToTable("DependentEntityByConventionOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByDataAnnotationOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<int>("ForeignKeyToPrincipalEntity")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ForeignKeyToPrincipalEntity");

                    b.ToTable("DependentEntityByDataAnnotationOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByFluentApiOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<int>("ForeignKeyToPrincipalEntity")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ForeignKeyToPrincipalEntity");

                    b.ToTable("DependentEntityByFluentApiOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByConventionOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByConventionOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByDataAnnotationOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByDataAnnotationOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByFluentApiOTM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PrincipalEntityByFluentApiOTM");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByConventionOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByConventionOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByDataAnnotationOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByDataAnnotationOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByFluentApiOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<decimal>("SecondProperty")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("DependentEntityByFluentApiOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByConventionOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DependentEntityByConventionOTOId")
                        .HasColumnType("int");

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DependentEntityByConventionOTOId");

                    b.ToTable("PrincipalEntityByConventionOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByDataAnnotationOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<int>("ForeignKeyToDependentEntityByDataAnnotationOTO")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ForeignKeyToDependentEntityByDataAnnotationOTO");

                    b.ToTable("PrincipalEntityByDataAnnotationOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByFluentApiOTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DependentEntityByFluentApiOTOId")
                        .HasColumnType("int");

                    b.Property<int>("FirstProperty")
                        .HasColumnType("int");

                    b.Property<string>("SecondProperty")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DependentEntityByFluentApiOTOId");

                    b.ToTable("PrincipalEntityByFluentApiOTO");
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByConventionMTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByConventionMTM", null)
                        .WithMany("MiddleEntitiesByConventionMTM")
                        .HasForeignKey("DependentEntityByConventionMTMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByConventionMTM", null)
                        .WithMany("MiddleEntitiesByConventionMTM")
                        .HasForeignKey("PrincipalEntityByConventionMTMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByDataAnnotationMTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByDataAnnotationMTM", null)
                        .WithMany("MiddleEntitiesByDataAnnotationMTM")
                        .HasForeignKey("ForeignKeyToDependentEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByDataAnnotationMTM", null)
                        .WithMany("MiddleEntitiesByDataAnnotationMTM")
                        .HasForeignKey("ForeignKeyToPrincipalEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.MiddleEntityByFluentApiMTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.DependentEntityByFluentApiMTM", "DependentEntityByFluentApiMTM")
                        .WithMany("MiddleEntitiesByFluentApiMTM")
                        .HasForeignKey("ForeignKeyToDependentEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.ManyToManyRelation.PrincipalEntityByFluentApiMTM", "PrincipalEntityByFluentApiMTM")
                        .WithMany("MiddleEntitiesByFluentApiMTM")
                        .HasForeignKey("ForeignKeyToPrincipalEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByConventionOTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByConventionOTM", null)
                        .WithMany("DependentsEntitiesByConventionOTM")
                        .HasForeignKey("PrincipalEntityByConventionOTMId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByDataAnnotationOTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByDataAnnotationOTM", null)
                        .WithMany("DependentsEntitiesByDataAnnotationOTM")
                        .HasForeignKey("ForeignKeyToPrincipalEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.DependentEntityByFluentApiOTM", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToManyRelation.PrincipalEntityByFluentApiOTM", null)
                        .WithMany("DependentsEntitiesByFluentApiOTM")
                        .HasForeignKey("ForeignKeyToPrincipalEntity")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByConventionOTO", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByConventionOTO", "DependentEntityByConventionOTO")
                        .WithMany()
                        .HasForeignKey("DependentEntityByConventionOTOId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByDataAnnotationOTO", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByDataAnnotationOTO", "DependentEntityByDataAnnotationOTO")
                        .WithMany()
                        .HasForeignKey("ForeignKeyToDependentEntityByDataAnnotationOTO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.PrincipalEntityByFluentApiOTO", b =>
                {
                    b.HasOne("EntityFrameworkCoreLab.Persistence.DataTransferObjects.Experiments.OneToOneRelation.DependentEntityByFluentApiOTO", "DependentEntityByFluentApiOTO")
                        .WithMany()
                        .HasForeignKey("DependentEntityByFluentApiOTOId");
                });
#pragma warning restore 612, 618
        }
    }
}
