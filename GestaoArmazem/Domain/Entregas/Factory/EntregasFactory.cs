using System;
using DDDSample1.Domain.Entregas.Validator;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas.Factory {
    public class EntregasFactory : IEntregasFactory {
        public Entrega CriarEntrega(String identificador,
            String armazem,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocacao,
            Double tempoRetirada
            ){
            EntregasValidator entregasValidator = new EntregasValidator();
        
            if(entregasValidator.IsValid(identificador,
                armazem,
                dia,
                mes,
                ano,
                massa,
                tempoColocacao,
                tempoRetirada))
                return new Entrega(new Identificador(identificador), armazem, new DataEntrega(dia,mes,ano), new Massa(massa), new TempoColocacao(tempoColocacao), new TempoRetirada(tempoRetirada));

            return null;
        }
    }
}