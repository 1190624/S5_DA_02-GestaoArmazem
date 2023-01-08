using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using System;
using System.Collections.Generic;
using DDDSample1.Domain.Entregas;

namespace DDDSample1.Domain.Armazens
{
    [DataContract]
    public class Armazem : Entity<Identificador>, IAggregateRoot
    {
        [DataMember(Name = "Designacao")]
        private Designacao designacao;
        [DataMember(Name = "Endereco")]
        private Endereco endereco;
        [DataMember(Name = "Municipio")]
        private Municipio municipio;
        [DataMember(Name = "Coordenadas")]
        private Coordenadas coordenadas;
        [DataMember(Name = "Altitude")]
        private Altitude altitude;

        [DataMember(Name = "Estado")]
        private Boolean estado;

        public ICollection<Entrega> entregas { get; private set; }


        public bool Active { get; private set; }
        public Armazem()
        {
            this.Active = true;
        }

        public Armazem(Identificador identificador, Designacao designacao, Endereco endereco, Municipio municipio, Coordenadas coordenadas, Altitude altitude)
        {
            this.Id = identificador;
            this.designacao = designacao;
            this.endereco = endereco;
            this.municipio = municipio;
            this.coordenadas = coordenadas;
            this.altitude = altitude;
            this.Active = true;
        }

        public Designacao Designacao => designacao;
        public Endereco Endereco => endereco;
        public Endereco GetEndereço()
        {
            return endereco;
        }
        public Municipio Municipio => municipio;
        public Coordenadas Coordenadas => coordenadas;
        public Altitude Altitude => altitude;

        public void changeDesignacao(String designacao)
        {
            this.designacao = new Designacao(designacao);
        }

        public void changeEndereco(String codigoPostal, Int16 numeroPorta, String nomeRua, String localidade, String pais)
        {
            this.endereco = new Endereco(codigoPostal, numeroPorta, nomeRua, localidade, pais);
        }

        public void changeMunicipio(String municipio)
        {
            this.municipio = new Municipio(municipio);
        }

        public void changeCoordenadas(Double latitude, Double longitude)
        {
            this.coordenadas = new Coordenadas(latitude, longitude);
        }

        public void changeAltitude(Double altitude)
        {
            this.altitude = new Altitude(altitude);
        }

        public void changeEstado(){
            this.Active = !Active;
        }


        public void AddEntrega(Entrega e)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("Não é possivel adicionar uma entrega ao armazém.");
            if (e == null)
                throw new BusinessRuleValidationException("A entrega não pode ser nula.");
            this.entregas.Add(e);
        }
    }
}