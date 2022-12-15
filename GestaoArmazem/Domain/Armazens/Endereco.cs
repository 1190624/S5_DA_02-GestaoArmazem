using System;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens {
    [Owned]
    [DataContract]
    public class Endereco : IValueObject {
        [DataMember(Name = "CodigoPostal")]
        private String codigoPostal;
        [DataMember(Name = "NumeroPorta")]
        private Int16 numeroPorta;
        [DataMember(Name = "NomeRua")]
        private String nomeRua;
        [DataMember(Name = "Localidade")]
        private String localidade;
        [DataMember(Name = "Pais")]
        private String pais;

        public Endereco() {}

        public Endereco(String codigoPostal, Int16 numeroPorta, String nomeRua, String localidade, String pais) {
            this.codigoPostal = codigoPostal;
            this.numeroPorta = numeroPorta;
            this.nomeRua = nomeRua;
            this.localidade = localidade;
            this.pais = pais;
        }

        public String GetCódigoPostal => codigoPostal;
        public Int16 GetNúmeroPorta => numeroPorta;
        public String GetNomeRua => nomeRua;
        public String GetLocalidade => localidade;
        public String GetPaís => pais;

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is Endereco))
                return false;

            Endereco endereço = (Endereco) obj;

            return this.codigoPostal.Equals(endereço.codigoPostal)
                && this.numeroPorta.Equals(endereço.numeroPorta)
                && this.nomeRua.Equals(endereço.nomeRua)
                && this.localidade.Equals(endereço.localidade)
                && this.pais.Equals(endereço.pais);
        }

        public override int GetHashCode() {
            return HashCode.Combine(codigoPostal, numeroPorta, nomeRua, localidade, pais);
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            builder.Append(nomeRua).Append(", ")
                .Append(numeroPorta).Append("\n")
                .Append(codigoPostal).Append(", ")
                .Append(localidade).Append("\n")
                .Append(pais);

            return builder.ToString();
        }
    }
}