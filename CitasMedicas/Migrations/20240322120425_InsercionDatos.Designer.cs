﻿// <auto-generated />
using CitasMedicas.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasMedicas.Migrations
{
    [DbContext(typeof(CitasMedicasDbContext))]
    [Migration("20240322120425_InsercionDatos")]
    partial class InsercionDatos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CitasMedicas.Models.UsuarioModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UsuarioModel");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MedicoModelPacienteModel", b =>
                {
                    b.Property<long>("medicosId")
                        .HasColumnType("bigint");

                    b.Property<long>("pacientesId")
                        .HasColumnType("bigint");

                    b.HasKey("medicosId", "pacientesId");

                    b.HasIndex("pacientesId");

                    b.ToTable("MedicoModelPacienteModel");
                });

            modelBuilder.Entity("CitasMedicas.Models.MedicoModel", b =>
                {
                    b.HasBaseType("CitasMedicas.Models.UsuarioModel");

                    b.Property<string>("numColegiado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroColegiado");

                    b.HasDiscriminator().HasValue("MedicoModel");

                    b.HasData(
                        new
                        {
                            Id = -1L,
                            apellidos = "Camboya",
                            clave = "1234",
                            nombre = "Sixam",
                            usuario = "Pepitos",
                            numColegiado = "1234"
                        });
                });

            modelBuilder.Entity("CitasMedicas.Models.PacienteModel", b =>
                {
                    b.HasBaseType("CitasMedicas.Models.UsuarioModel");

                    b.Property<string>("NSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NSS");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Direccion");

                    b.Property<string>("numTarjeta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumeroTarjeta");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Telefono");

                    b.HasDiscriminator().HasValue("PacienteModel");

                    b.HasData(
                        new
                        {
                            Id = -2L,
                            apellidos = "Casandra",
                            clave = "1234",
                            nombre = "Carlos",
                            usuario = "",
                            NSS = "1234",
                            direccion = "Mi casa",
                            numTarjeta = "1",
                            telefono = "123456789"
                        });
                });

            modelBuilder.Entity("MedicoModelPacienteModel", b =>
                {
                    b.HasOne("CitasMedicas.Models.MedicoModel", null)
                        .WithMany()
                        .HasForeignKey("medicosId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("CitasMedicas.Models.PacienteModel", null)
                        .WithMany()
                        .HasForeignKey("pacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
