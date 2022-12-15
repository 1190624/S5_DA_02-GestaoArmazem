using System;
using System.Runtime.Serialization;

namespace DDDSample1.Domain.Armazens.DTO {
    [DataContract]
    public class ArmazemDTO {
        [DataMember(Name = "Identificador")]
        public String identificador;
        [DataMember(Name = "Designacao")]
        public String designacao;
        [DataMember(Name = "CodigoPostal")]
        public String codigoPostal;
        [DataMember(Name = "NumeroPorta")]
        public Int16 numeroPorta;
        [DataMember(Name = "NomeRua")]
        public String nomeRua;
        [DataMember(Name = "Localidade")]
        public String localidade;
        [DataMember(Name = "Pais")]
        public String pais;
        [DataMember(Name = "Municipio")]
        public String municipio;
        [DataMember(Name = "Latitude")]
        public Double latitude;
        [DataMember(Name = "Longitude")]
        public Double longitude;

        public ArmazemDTO(String identificador,
            String designacao, 
            String codigoPostal, 
            Int16 numeroPorta, 
            String nomeRua, 
            String localidade,
            String pais, 
            String municipio, 
            Double latitude, 
            Double longitude) {
            this.identificador = identificador;
            this.designacao = designacao;
            this.codigoPostal = codigoPostal;
            this.numeroPorta = numeroPorta;
            this.nomeRua = nomeRua;
            this.localidade = localidade;
            this.pais = pais;
            this.municipio = municipio;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        
        public String GetIdentificador => identificador;
        public String GetDesignacao => designacao;
        public String GetCodigoPostal => codigoPostal;
        public Int16 GetNumeroPorta => numeroPorta;
        public String GetNomeRua => nomeRua;
        public String GetLocalidade => localidade;
        public String GetPais => pais;
        public String GetMunicipio => municipio;
        public Double GetLatitude => latitude;
        public Double GetLongitude => longitude;
    }
}