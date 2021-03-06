// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SAACHostel.Models;

#nullable disable

namespace SAACHostel.Migrations
{
    [DbContext(typeof(DataBaseModel))]
    [Migration("20220124221119_Final")]
    partial class Final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Faculty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("Full_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Full_Name_Decan")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone_Decane")
                        .HasColumnType("TEXT");

                    b.Property<string>("Short_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Facultys");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Hostel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count_Room")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("Home_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Hostels");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+LogEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date_Ent")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date_Ext")
                        .HasColumnType("TEXT");

                    b.Property<int>("HostelID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PaymentAndPeriodID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoomID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Total_Paid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("LogEntrys");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+PaymentAndPeriod", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Period")
                        .HasColumnType("TEXT");

                    b.Property<bool>("SelectedPeriod")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("PaymentAndPeriods");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capacity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<int>("HostelID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("HostelID");

                    b.HasIndex("UserID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Specialty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("Full_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Short_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UserID");

                    b.ToTable("Specialtys");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<int>("FacultyID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("First_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Group")
                        .HasColumnType("TEXT");

                    b.Property<string>("Home_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Middle_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Passport_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.Property<int>("SpecialtyID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("FacultyID");

                    b.HasIndex("SpecialtyID");

                    b.HasIndex("UserID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date_Create")
                        .HasColumnType("TEXT");

                    b.Property<string>("First_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Home_address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Last_Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Login")
                        .HasColumnType("TEXT");

                    b.Property<string>("Middle_Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Pasport_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("BLOB");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Faculty", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("Faculty")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Hostel", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("Hostel")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+LogEntry", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("LogEntry")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Room", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+Hostel", "Hostel")
                        .WithMany("Room")
                        .HasForeignKey("HostelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("Room")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hostel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Specialty", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("Specialty")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Student", b =>
                {
                    b.HasOne("SAACHostel.Models.DataBaseModel+Faculty", "Faculty")
                        .WithMany("Student")
                        .HasForeignKey("FacultyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAACHostel.Models.DataBaseModel+Specialty", "Specialty")
                        .WithMany("Student")
                        .HasForeignKey("SpecialtyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SAACHostel.Models.DataBaseModel+User", "User")
                        .WithMany("Student")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Specialty");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Faculty", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Hostel", b =>
                {
                    b.Navigation("Room");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+Specialty", b =>
                {
                    b.Navigation("Student");
                });

            modelBuilder.Entity("SAACHostel.Models.DataBaseModel+User", b =>
                {
                    b.Navigation("Faculty");

                    b.Navigation("Hostel");

                    b.Navigation("LogEntry");

                    b.Navigation("Room");

                    b.Navigation("Specialty");

                    b.Navigation("Student");
                });
#pragma warning restore 612, 618
        }
    }
}
