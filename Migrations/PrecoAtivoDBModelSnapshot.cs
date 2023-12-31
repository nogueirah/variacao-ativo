﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using variacao_ativo;

#nullable disable

namespace variacao_ativo.Migrations
{
    [DbContext(typeof(PrecoAtivoDB))]
    partial class PrecoAtivoDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("variacao_ativo.Model.PrecoAtivoDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15, 5)");

                    b.HasKey("Id");

                    b.ToTable("PrecosAtivos");
                });
#pragma warning restore 612, 618
        }
    }
}
