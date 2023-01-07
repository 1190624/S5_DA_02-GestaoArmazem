using System;

namespace DDDSample1.Domain.Armazens.Factory {
    public interface IArmazemFactory {
        public Armazem CriarArmazem(String identifier,
            String designacao, 
            String codigoPostal, 
            Int16 numeroPorta, 
            String nomeRua, 
            String localidade,
            String pais,
            String municipio,
            Double latitude,
            Double longitude,
            Double altitude);
    }
}