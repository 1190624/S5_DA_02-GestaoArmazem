using System;
using DDDSample1.Domain.Armazens.Validator;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazens.Factory {
    public class ArmazemFactory : IArmazemFactory {
        public Armazem CriarArmazem(String identificador,
            String designacao, 
            String codigoPostal, 
            Int16 numeroPorta, 
            String nomeRua, 
            String localidade,
            String pais,
            String municipio,
            Double latitude,
            Double longitude) {
                ArmazemValidator armazemValidator = new ArmazemValidator();

                if (armazemValidator.IsValid(identificador,
                    designacao, 
                    codigoPostal, 
                    numeroPorta, 
                    nomeRua, 
                    localidade,
                    pais, 
                    municipio, 
                    latitude, 
                    longitude))
                    return new Armazem(new Identificador(identificador),
                        new Designacao(designacao),
                        new Endereco(codigoPostal, numeroPorta, nomeRua, localidade, pais),
                        new Municipio(municipio),
                        new Coordenadas(latitude, longitude));

                return null;
            }
    }
}