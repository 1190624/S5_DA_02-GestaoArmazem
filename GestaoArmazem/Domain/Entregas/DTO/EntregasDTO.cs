using System;
using System.Runtime.Serialization;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas.DTO {
    [DataContract]
    public class EntregasDTO{
        [DataMember(Name = "Identificador")]
        public String identificador;

        [DataMember(Name = "ArmazemId")]
        public String armazemID;

        [DataMember(Name = "Dia")]
        public String dia;

        [DataMember(Name = "Mes")]
        public String mes;

        [DataMember(Name = "Ano")]
        public String ano;

        [DataMember(Name = "Massa")]
        public Double massa;

        [DataMember(Name = "TempoColocacao")]
        public Double tempoColocacao;

        [DataMember(Name = "TempoRetirada")]
        public Double tempoRetirada;

        //What?!
        public Armazem armazem{get;set;}

        public EntregasDTO(String identificador,
            String armazemID,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocacao,
            Double tempoRetirada){
            this.identificador = identificador;
            this.armazemID = armazemID;
            this.dia = dia;
            this.mes = mes;
            this.ano = ano;
            this.massa = massa;
            this.tempoColocacao = tempoColocacao;
            this.tempoRetirada = tempoRetirada;
        }

        public String GetIdentificador => identificador;
        public String GetArmazemID => armazemID;
        public String GetDia => dia;
        public String GetMes => mes;
        public String GetAno => ano;
        public Double GetMassa => massa;
        public Double GetTempoColocacao => tempoColocacao;
        public Double GetTempoRetirada => tempoRetirada;
        
    }

}