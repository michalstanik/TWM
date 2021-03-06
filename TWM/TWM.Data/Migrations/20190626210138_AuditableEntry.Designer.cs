﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TWM.Data;

namespace TWM.Data.Migrations
{
    [DbContext(typeof(TripWMeContext))]
    [Migration("20190626210138_AuditableEntry")]
    partial class AuditableEntry
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TWM.Data.Domain.Admin.AuditLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("KeyValues");

                    b.Property<string>("NewValues");

                    b.Property<string>("OldValues");

                    b.Property<string>("TableName");

                    b.HasKey("Id");

                    b.ToTable("AuditLog");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alpha2Code");

                    b.Property<string>("Alpha3Code");

                    b.Property<long>("Area");

                    b.Property<string>("Name");

                    b.Property<string>("OfficialName");

                    b.Property<int?>("RegionId");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<double>("Latitude");

                    b.Property<int>("LocationTypeId");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("LocationTypeId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.LocationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.ToTable("LocationType");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContinentId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("TWM.Data.Domain.Stops.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Arrival");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("Departure");

                    b.Property<int?>("LocationId");

                    b.Property<int>("Order");

                    b.Property<string>("StopDescription");

                    b.Property<string>("StopName");

                    b.Property<int>("TripId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("TripId");

                    b.ToTable("Stop");
                });

            modelBuilder.Entity("TWM.Data.Domain.Trips.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Name");

                    b.Property<double>("StarRating");

                    b.Property<string>("TripCode")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasComputedColumnSql("'TR-' + CONVERT(varchar(10),[Id])");

                    b.Property<string>("TripManagerId");

                    b.Property<int?>("TripTypeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.HasIndex("TripManagerId");

                    b.HasIndex("TripTypeId");

                    b.ToTable("Trip");
                });

            modelBuilder.Entity("TWM.Data.Domain.Trips.TripType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TripTypeName");

                    b.HasKey("Id");

                    b.ToTable("TripType");
                });

            modelBuilder.Entity("TWM.Data.Domain.Users.TUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("TUser");
                });

            modelBuilder.Entity("TWM.Data.Domain.Users.UserCountryAssessment", b =>
                {
                    b.Property<int>("CountryId");

                    b.Property<string>("TUserId");

                    b.Property<long>("AreaLevelAssessment");

                    b.Property<int>("CountryKnowledgeType");

                    b.HasKey("CountryId", "TUserId");

                    b.HasIndex("TUserId");

                    b.ToTable("UserCountryAssessment");
                });

            modelBuilder.Entity("TWM.Data.Domain.Users.UserTrip", b =>
                {
                    b.Property<int>("TripId");

                    b.Property<string>("TUserId");

                    b.Property<bool>("IsMain");

                    b.Property<bool>("IsOrganiser");

                    b.HasKey("TripId", "TUserId");

                    b.HasIndex("TUserId");

                    b.ToTable("UserTrip");
                });

            modelBuilder.Entity("TWM.Data.Domain.WorldHeritage.WorldHeritage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("IsoCodes");

                    b.Property<string>("Latitude");

                    b.Property<string>("Location");

                    b.Property<string>("Longitude");

                    b.Property<string>("Region");

                    b.Property<string>("UnescoId");

                    b.HasKey("Id");

                    b.ToTable("WorldHeritage");
                });

            modelBuilder.Entity("TWM.Data.Domain.WorldHeritage.WorldHeritageCountry", b =>
                {
                    b.Property<int>("WorldHeritageId");

                    b.Property<int>("CountryId");

                    b.HasKey("WorldHeritageId", "CountryId");

                    b.HasIndex("CountryId");

                    b.ToTable("WorldHeritageCountry");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Country", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Region", "Region")
                        .WithMany("Countries")
                        .HasForeignKey("RegionId");
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Location", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Country", "Country")
                        .WithMany("Locations")
                        .HasForeignKey("CountryId");

                    b.HasOne("TWM.Data.Domain.GeoEntities.LocationType", "LocationType")
                        .WithMany("Locations")
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TWM.Data.Domain.GeoEntities.Region", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Continent", "Continent")
                        .WithMany("Regions")
                        .HasForeignKey("ContinentId");
                });

            modelBuilder.Entity("TWM.Data.Domain.Stops.Stop", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Location", "Location")
                        .WithMany("Stops")
                        .HasForeignKey("LocationId");

                    b.HasOne("TWM.Data.Domain.Trips.Trip", "Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TWM.Data.Domain.Trips.Trip", b =>
                {
                    b.HasOne("TWM.Data.Domain.Users.TUser", "TripManager")
                        .WithMany()
                        .HasForeignKey("TripManagerId");

                    b.HasOne("TWM.Data.Domain.Trips.TripType", "TripType")
                        .WithMany("Trips")
                        .HasForeignKey("TripTypeId");
                });

            modelBuilder.Entity("TWM.Data.Domain.Users.UserCountryAssessment", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Country", "Country")
                        .WithMany("UserCountryAssessments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TWM.Data.Domain.Users.TUser", "TUser")
                        .WithMany("UserCountryAssessments")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TWM.Data.Domain.Users.UserTrip", b =>
                {
                    b.HasOne("TWM.Data.Domain.Users.TUser", "TUser")
                        .WithMany("UserTrips")
                        .HasForeignKey("TUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TWM.Data.Domain.Trips.Trip", "Trip")
                        .WithMany("UserTrips")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TWM.Data.Domain.WorldHeritage.WorldHeritageCountry", b =>
                {
                    b.HasOne("TWM.Data.Domain.GeoEntities.Country", "Country")
                        .WithMany("WoldHeritageCountries")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TWM.Data.Domain.WorldHeritage.WorldHeritage", "WorldHeritage")
                        .WithMany("WoldHeritageCountries")
                        .HasForeignKey("WorldHeritageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
