using System;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Entregas {
    public class TempoColocacao : IValueObject {

// em minutos
    private Double tempoColocacao;

    public TempoColocacao(Double tempoColocacao){
        this.tempoColocacao = tempoColocacao;
    }

    public Double GetTempoColocacao => tempoColocacao;
    
    public override bool Equals(object obj){
        if (ReferenceEquals(null, obj))
                return false;
            if (!(obj is TempoColocacao))
                return false;

        TempoColocacao tempoColocação = (TempoColocacao) obj;

        return this.tempoColocacao.Equals(tempoColocação.tempoColocacao);
    }

    public override int GetHashCode() {
        return tempoColocacao.GetHashCode();
    }

    public override string ToString() {
        return tempoColocacao.ToString();
    }

    }
}