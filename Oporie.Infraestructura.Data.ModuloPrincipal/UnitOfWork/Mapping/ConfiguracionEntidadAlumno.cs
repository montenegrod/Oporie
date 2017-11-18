
namespace Oporie.Infraestructura.Data.ModuloPrincipal.UnitOfWork.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Oporie.Dominio.ModuloPrincipal.Entidades;

    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The customer entity type configuration
    /// </summary>
    class ConfiguracionEntidadAlumno
        : EntityTypeConfiguration<ALUMNO>
    {
        /// <summary>
        /// Create a new instance of customer entity configuration
        /// </summary>
        public ConfiguracionEntidadAlumno()
        {
            //configure keys and properties
            this.HasKey(c => c.ID_ALUMNO);

            this.Property(c => c.ALU_FIRSTNAME)
                .HasMaxLength(50)
                .IsRequired();

            this.Property(c => c.ALU_LASTNAME)
                .HasMaxLength(100)
                .IsRequired();

            this.Property(c => c.ALU_ESTADO)
                .IsRequired();

            //configure associations
            this.HasRequired(c => c.ALU_FOTO) // this is a table-splitting
                .WithRequiredPrincipal();

            this.HasRequired(c => c.TELEFONO) // 1..*
                .WithMany()
                .HasForeignKey(c => c.ID_TELEFONO)
                .WillCascadeOnDelete(false);


            //configure table map
            this.ToTable("Alumnos");
        }
    }
}
