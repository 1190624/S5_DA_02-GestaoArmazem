using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens {
    [Owned]
    [DataContract]
    public class Municipio : IValueObject { 
        [DataMember(Name = "Nome")]
        private String nome;

        public Municipio() {}

        public Municipio(String nome) {
            this.nome = nome;
        }

        public String GetNome => nome;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Municipio))
                return false;

            Municipio municipio = (Municipio) obj;

            return this.nome.Equals(municipio.nome);
        }
        
        public override int GetHashCode() {
            return nome.GetHashCode();
        }

        public override string ToString() {
            return nome;
        }
    }
}