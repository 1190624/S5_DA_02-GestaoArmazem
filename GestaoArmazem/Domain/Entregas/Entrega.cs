using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazens;
using System;

namespace DDDSample1.Domain.Entregas {
    public class Entrega : Entity<Identificador>, IAggregateRoot {

        private Identificador armazemId;
        private DataEntrega dataEntrega;
        private Massa massa;

        private TempoColocacao tempoColocacao;

        private TempoRetirada tempoRetirada;

         public Armazem armazem{get;set;}

        public Entrega() {}

        public Entrega(Identificador identificador, String armazemId, DataEntrega dataEntrega, Massa massa, TempoColocacao tempoColocacao, TempoRetirada tempoRetirada) {

            if(armazemId == null){
                throw new BusinessRuleValidationException("Armazém não pode ter um valor nulo");
            }
            this.Id = identificador;
           // this.armazém = armazém;
            this.armazemId = new Identificador(armazemId);
            this.dataEntrega = dataEntrega;
            this.massa = massa;
            this.tempoColocacao = tempoColocacao;
            this.tempoRetirada = tempoRetirada;
        }

        public Identificador ArmazemId => armazemId;
        public DataEntrega DataEntrega => dataEntrega;

        public Massa Massa => massa;

        public TempoColocacao TempoColocacao => tempoColocacao;

        public TempoRetirada TempoRetirada => tempoRetirada;
        


        public void changeArmazem (String armazem){
            this.armazemId = new Identificador(armazem);
        }

        public void changeDataEntrega(String dia, String mes, String ano){
            this.dataEntrega = new DataEntrega(dia, mes, ano);
        }

        public void changeMassa(Double massa){
            this.massa = new Massa(massa);
        }

        public void changeTempoColocacao(Double tempoColocacao){
            this.tempoColocacao = new TempoColocacao(tempoColocacao);
        }

        public void changeTempoRetirada(Double tempoRetirada){
            this.tempoRetirada = new TempoRetirada(tempoRetirada);
        }
    }
}