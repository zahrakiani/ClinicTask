﻿// <auto-generated />
using System;
using Appointment.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Appointment.Infrastructure.Database.Migrations
{
    [DbContext(typeof(AppointmentDbContext))]
    [Migration("20231004104647_Seed-DoctorWeeklySchedule")]
    partial class SeedDoctorWeeklySchedule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Appointments", "Appointment");
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.ClinicAggregate.Clinic", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EndDay")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StartDay")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("Clinics", "Appointment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("03483fd2-2537-4da7-bc5f-2c5051f4f3db"),
                            Description = "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.",
                            EndDay = 3,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            Name = "KarizmaClinic",
                            StartDay = 6,
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DoctorTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors", "Appointment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                            DoctorTypeId = new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"),
                            Email = "Tehrani@clinic.com",
                            Mobile = "09121211212"
                        },
                        new
                        {
                            Id = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                            DoctorTypeId = new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"),
                            Email = "Ahmadi@clinic.com",
                            Mobile = "09121231313"
                        });
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate.DoctorType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("MaxDurationAppointmentTime")
                        .HasColumnType("time");

                    b.Property<int>("MaxOverlap")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("MinDurationAppointmentTime")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DoctorTypes", "Appointment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2"),
                            Description = "Specialist Doctor",
                            MaxDurationAppointmentTime = new TimeSpan(0, 0, 30, 0, 0),
                            MaxOverlap = 3,
                            MinDurationAppointmentTime = new TimeSpan(0, 0, 10, 0, 0),
                            Title = "Specialist"
                        },
                        new
                        {
                            Id = new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70"),
                            Description = "General Doctor",
                            MaxDurationAppointmentTime = new TimeSpan(0, 0, 15, 0, 0),
                            MaxOverlap = 2,
                            MinDurationAppointmentTime = new TimeSpan(0, 0, 5, 0, 0),
                            Title = "General"
                        });
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.PatientAggregate.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients", "Appointment");

                    b.HasData(
                        new
                        {
                            Id = new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66"),
                            Email = "client1@gmail.com",
                            Mobile = "09124214242"
                        },
                        new
                        {
                            Id = new Guid("8fce7d4f-2607-4588-8211-373b21850844"),
                            Email = "client2@yahoo.com",
                            Mobile = "09125235353"
                        });
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment", b =>
                {
                    b.HasOne("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Doctor", null)
                        .WithMany("Appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Appointment.Domain.Core.AggregatesModel.PatientAggregate.Patient", null)
                        .WithMany("Appointments")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects.AppointmentTime", "AppointmentTime", b1 =>
                        {
                            b1.Property<Guid>("AppointmentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<TimeSpan>("DurationTime")
                                .HasColumnType("time");

                            b1.Property<DateTime>("EndTime")
                                .HasColumnType("datetime2");

                            b1.Property<DateTime>("StartTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("AppointmentId");

                            b1.ToTable("Appointments", "Appointment");

                            b1.WithOwner()
                                .HasForeignKey("AppointmentId");
                        });

                    b.Navigation("AppointmentTime")
                        .IsRequired();
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Doctor", b =>
                {
                    b.OwnsMany("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.DailySchedule", "WeeklySchedule", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("Date")
                                .HasColumnType("datetime2");

                            b1.Property<TimeSpan>("EndTime")
                                .HasColumnType("time");

                            b1.Property<TimeSpan>("StartTime")
                                .HasColumnType("time");

                            b1.HasKey("DoctorId", "Id");

                            b1.ToTable("DoctorDailySchedules", "Appointment");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");

                            b1.HasData(
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    Id = new Guid("7674b44d-064a-453c-afd8-eb32cc75f03a"),
                                    Date = new DateTime(2023, 10, 7, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(6977),
                                    EndTime = new TimeSpan(0, 12, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 9, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    Id = new Guid("ba0340f6-79e5-4676-b65b-966c8d38e380"),
                                    Date = new DateTime(2023, 10, 8, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7003),
                                    EndTime = new TimeSpan(0, 18, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 14, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    Id = new Guid("6f5df522-404b-4288-a510-93c8c287fa41"),
                                    Date = new DateTime(2023, 10, 9, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7006),
                                    EndTime = new TimeSpan(0, 12, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 9, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    Id = new Guid("445389f6-1caf-439e-8896-d3751a2875b5"),
                                    Date = new DateTime(2023, 10, 10, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7009),
                                    EndTime = new TimeSpan(0, 18, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 14, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    Id = new Guid("17fa0b02-05ef-46af-9cea-04b8da99ebe9"),
                                    Date = new DateTime(2023, 10, 11, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7012),
                                    EndTime = new TimeSpan(0, 12, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 9, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                                    Id = new Guid("87f3dcc4-255b-445d-b8b2-5b35a05a373a"),
                                    Date = new DateTime(2023, 10, 7, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7014),
                                    EndTime = new TimeSpan(0, 14, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 10, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                                    Id = new Guid("582ab276-142c-4992-8168-8c45f3701c3c"),
                                    Date = new DateTime(2023, 10, 8, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7017),
                                    EndTime = new TimeSpan(0, 18, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 14, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                                    Id = new Guid("ac918875-76e9-4c3a-80ac-5ccfc542308a"),
                                    Date = new DateTime(2023, 10, 9, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7025),
                                    EndTime = new TimeSpan(0, 17, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 13, 0, 0, 0)
                                },
                                new
                                {
                                    DoctorId = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                                    Id = new Guid("2193079e-00b3-4de2-abb5-2a49b118756a"),
                                    Date = new DateTime(2023, 10, 10, 14, 16, 46, 809, DateTimeKind.Local).AddTicks(7029),
                                    EndTime = new TimeSpan(0, 14, 0, 0, 0),
                                    StartTime = new TimeSpan(0, 10, 0, 0, 0)
                                });
                        });

                    b.OwnsOne("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.ValueObjects.PersonalInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("DoctorId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Prefix")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DoctorId");

                            b1.ToTable("Doctors", "Appointment");

                            b1.WithOwner()
                                .HasForeignKey("DoctorId");

                            b1.HasData(
                                new
                                {
                                    DoctorId = new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0"),
                                    FirstName = "Sara",
                                    LastName = "Tehrani",
                                    Prefix = "Neurologists"
                                },
                                new
                                {
                                    DoctorId = new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d"),
                                    FirstName = "Hamid",
                                    LastName = "Ahmadi",
                                    Prefix = "Dermatologist"
                                });
                        });

                    b.Navigation("Info")
                        .IsRequired();

                    b.Navigation("WeeklySchedule");
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.PatientAggregate.Patient", b =>
                {
                    b.OwnsOne("Appointment.Domain.Core.AggregatesModel.PatientAggregate.ValueObject.PersonalInfo", "Info", b1 =>
                        {
                            b1.Property<Guid>("PatientId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("NationalCode")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("nvarchar(10)");

                            b1.HasKey("PatientId");

                            b1.ToTable("Patients", "Appointment");

                            b1.WithOwner()
                                .HasForeignKey("PatientId");

                            b1.HasData(
                                new
                                {
                                    PatientId = new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66"),
                                    FirstName = "Ali",
                                    LastName = "Alizade",
                                    NationalCode = "0023456789"
                                },
                                new
                                {
                                    PatientId = new Guid("8fce7d4f-2607-4588-8211-373b21850844"),
                                    FirstName = "Mina",
                                    LastName = "Amiri",
                                    NationalCode = "1230012300"
                                });
                        });

                    b.Navigation("Info")
                        .IsRequired();
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.DoctorAggregate.Doctor", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("Appointment.Domain.Core.AggregatesModel.PatientAggregate.Patient", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
