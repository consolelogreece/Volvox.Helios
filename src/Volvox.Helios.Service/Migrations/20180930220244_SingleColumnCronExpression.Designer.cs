﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Volvox.Helios.Domain.Module;
using Volvox.Helios.Service;

namespace Volvox.Helios.Service.Migrations
{
    [DbContext(typeof(VolvoxHeliosContext))]
    [Migration("20180930220244_SingleColumnCronExpression")]
    partial class SingleColumnCronExpression
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Volvox.Helios.Domain.Module.ChatTracker.Message", b =>
                {
                    b.Property<decimal>("Id")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("AuthorId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("ChannelId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Deleted");

                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.Module.RecurringReminderMessage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("ChannelId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("CronExpression")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<bool>("Enabled");

                    b.Property<int>("Fault")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(0);

                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<string>("Message")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("GuildId");

                    b.ToTable("RecurringReminderMessages");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.Module.StreamAnnouncerChannelSettings", b =>
                {
                    b.Property<decimal>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<decimal>("GuildId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("RemoveMessage");

                    b.HasKey("ChannelId");

                    b.HasIndex("GuildId");

                    b.ToTable("StreamAnnouncerChannelSettings");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.ModuleSettings.ChatTrackerSettings", b =>
                {
                    b.Property<decimal>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Enabled");

                    b.HasKey("GuildId");

                    b.ToTable("ChatTrackerSettings");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.ModuleSettings.RemembotSettings", b =>
                {
                    b.Property<decimal>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Enabled");

                    b.HasKey("GuildId");

                    b.ToTable("ReminderSettings");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.ModuleSettings.StreamAnnouncerSettings", b =>
                {
                    b.Property<decimal>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Enabled");

                    b.HasKey("GuildId");

                    b.ToTable("StreamAnnouncerSettings");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.ModuleSettings.StreamerRoleSettings", b =>
                {
                    b.Property<decimal>("GuildId")
                        .ValueGeneratedOnAdd()
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.Property<bool>("Enabled");

                    b.Property<decimal>("RoleId")
                        .HasConversion(new ValueConverter<decimal, decimal>(v => default(decimal), v => default(decimal), new ConverterMappingHints(precision: 20, scale: 0)));

                    b.HasKey("GuildId");

                    b.ToTable("StreamerRoleSettings");
                });

            modelBuilder.Entity("Volvox.Helios.Domain.Module.RecurringReminderMessage", b =>
                {
                    b.HasOne("Volvox.Helios.Domain.ModuleSettings.RemembotSettings")
                        .WithMany("RecurringReminders")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Volvox.Helios.Domain.Module.StreamAnnouncerChannelSettings", b =>
                {
                    b.HasOne("Volvox.Helios.Domain.ModuleSettings.StreamAnnouncerSettings", "StreamAnnouncerSettings")
                        .WithMany("ChannelSettings")
                        .HasForeignKey("GuildId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
