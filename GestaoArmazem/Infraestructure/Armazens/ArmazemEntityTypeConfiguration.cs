using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Infrastructure.Armazens {
    public class ArmazemEntityTypeConfiguration : IEntityTypeConfiguration<Armazem> {
        public void Configure(EntityTypeBuilder<Armazem> entityTypeBuilder) {
            entityTypeBuilder.HasKey(armazem => armazem.Id);
            entityTypeBuilder.OwnsOne(armazem => armazem.Designacao,
                designação => {designação.Property("texto").IsRequired(true);});
            entityTypeBuilder.OwnsOne(armazem => armazem.Endereco, endereco => { 
                endereco.Property("códigoPostal").IsRequired(true);
                endereco.Property("númeroPorta").IsRequired(true);
                endereco.Property("nomeRua").IsRequired(true);
                endereco.Property("localidade").IsRequired(true);
                endereco.Property("país").IsRequired(true);
                });
            entityTypeBuilder.OwnsOne(armazem => armazem.Municipio,
                municipio => {municipio.Property("nome").IsRequired(true);});
            entityTypeBuilder.OwnsOne(armazem => armazem.Coordenadas, coordenadas => {
                coordenadas.Property("latitude").IsRequired(true);
                coordenadas.Property("longitude").IsRequired(true);
            });
        }
    }
}