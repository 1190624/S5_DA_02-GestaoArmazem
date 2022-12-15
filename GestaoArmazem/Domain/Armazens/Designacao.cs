using System;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens {
    [Owned]
    [DataContract]
    public class Designacao : IValueObject {
        [DataMember(Name = "Texto")]
        private String texto;

        public Designacao() {}

        public Designacao(String texto) {
            this.texto = texto;
        }

        public String GetTexto => texto;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Designacao))
                return false;

            Designacao designação = (Designacao) obj;

            return texto.Equals(designação.texto);
        }

        public override int GetHashCode()
        {
            return texto.GetHashCode();
        }

        public override string ToString()
        {
            return texto;
        }
    }
}