using System;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas.Factory {
    public interface IEntregasFactory {
        public Entrega CriarEntrega(String identificador,
            String armazem,
            String dia,
            String mes,
            String ano,
            Double massa,
            Double tempoColocacao,
            Double tempoRetirada);
    }
}