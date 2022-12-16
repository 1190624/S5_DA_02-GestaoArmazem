using System;
using DDDSample1.Domain.Armazens.Factory;

namespace DDDSample1.Domain.Armazens.DTO {
    public class ArmazemMapper {

        public static ArmazemDTO toDTO(Armazem armazem) {
            return new ArmazemDTO(armazem.Id.GetValue, 
                armazem.Designacao.GetTexto, 
                armazem.Endereco.GetCodigoPostal, 
                armazem.Endereco.GetNumeroPorta,
                armazem.Endereco.GetNomeRua,
                armazem.Endereco.GetLocalidade,
                armazem.Endereco.GetPais,
                armazem.Municipio.GetNome,
                armazem.Coordenadas.GetLatitude,
                armazem.Coordenadas.GetLongitude);
        }

        public static Armazem toArmazem(ArmazemDTO armazemDTO) {
            return new ArmazemFactory().CriarArmazem(armazemDTO.GetIdentificador,
                armazemDTO.GetDesignacao, 
                armazemDTO.GetCodigoPostal,
                armazemDTO.GetNumeroPorta,
                armazemDTO.GetNomeRua,
                armazemDTO.GetLocalidade,
                armazemDTO.GetPais,
                armazemDTO.GetMunicipio,
                armazemDTO.GetLatitude,
                armazemDTO.GetLongitude);
        }
    }
}