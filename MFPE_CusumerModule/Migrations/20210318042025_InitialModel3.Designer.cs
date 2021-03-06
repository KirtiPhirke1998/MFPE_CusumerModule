// <auto-generated />
using System;
using MFPE_CusumerModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MFPE_CusumerModule.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20210318042025_InitialModel3")]
    partial class InitialModel3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MFPE_CusumerModule.Models.Business", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BussinessMasterId")
                        .HasColumnType("int");

                    b.Property<string>("BussinessName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BussinessType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalEmployees")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BussinessMasterId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.BusinessMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnnualTurnover")
                        .HasColumnType("int");

                    b.Property<int>("BusinessValue")
                        .HasColumnType("int");

                    b.Property<bool>("HasBusinessTypes")
                        .HasColumnType("bit");

                    b.Property<int>("capitalInvested")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("BusinessMasters");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.Consumer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BussinessId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ValidityOfConsumer")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("BussinessId");

                    b.ToTable("Consumers");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.Property", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingAge")
                        .HasColumnType("int");

                    b.Property<string>("BuildingType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BussinessId")
                        .HasColumnType("int");

                    b.Property<int>("PropertMasterId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("BussinessId");

                    b.HasIndex("PropertMasterId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.PropertyMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CostofAsset")
                        .HasColumnType("int");

                    b.Property<bool>("HasPropertyTypes")
                        .HasColumnType("bit");

                    b.Property<int>("PropertyValue")
                        .HasColumnType("int");

                    b.Property<int>("SalvageValue")
                        .HasColumnType("int");

                    b.Property<int>("UsefulLifeOfAsset")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("PropertyMasters");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.Business", b =>
                {
                    b.HasOne("MFPE_CusumerModule.Models.BusinessMaster", "BusinessMaster")
                        .WithMany()
                        .HasForeignKey("BussinessMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BusinessMaster");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.Consumer", b =>
                {
                    b.HasOne("MFPE_CusumerModule.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BussinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("MFPE_CusumerModule.Models.Property", b =>
                {
                    b.HasOne("MFPE_CusumerModule.Models.Business", "Business")
                        .WithMany()
                        .HasForeignKey("BussinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MFPE_CusumerModule.Models.PropertyMaster", "PropertyMaster")
                        .WithMany()
                        .HasForeignKey("PropertMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");

                    b.Navigation("PropertyMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
