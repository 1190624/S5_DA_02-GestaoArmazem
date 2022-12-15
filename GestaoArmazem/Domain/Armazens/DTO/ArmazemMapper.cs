using System;
using DDDSample1.Domain.Armazens.Factory;

namespace DDDSample1.Domain.Armazens.DTO {
    public class ArmazemMapper {

        public static ArmazemDTO toDTO(Armazem armazém) {
            return new ArmazemDTO(armazém.Id.GetValue, 
                armazém.Designacao.GetTexto, 
                armazém.Endereco.GetCódigoPostal, 
                armazém.Endereco.GetNúmeroPorta,
                armazém.Endereco.GetNomeRua,
                armazém.Endereco.GetLocalidade,
                armazém.Endereco.GetPaís,
                armazém.Municipio.GetNome,
                armazém.Coordenadas.GetLatitude,
                armazém.Coordenadas.GetLongitude);
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