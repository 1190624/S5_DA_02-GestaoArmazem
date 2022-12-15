using System;
using DDDSample1.Domain.Entregas.Factory;

namespace DDDSample1.Domain.Entregas.DTO {
    public class EntregasMapper {
        public static EntregasDTO toDTO(Entrega entrega){
            return new EntregasDTO(entrega.Id.GetValue,
            entrega.ArmazemId.GetValue,
            entrega.DataEntrega.GetDia,
            entrega.DataEntrega.GetMes,
            entrega.DataEntrega.GetAno,
            entrega.Massa.GetMassa,
            entrega.TempoColocacao.GetTempoColocacao,
            entrega.TempoRetirada.GetTempoRetirada);
        }

        public static Entrega toEntrega(EntregasDTO entregasDTO){
            return new EntregasFactory().CriarEntrega(entregasDTO.GetIdentificador,
            entregasDTO.GetArmazemID,
            entregasDTO.GetDia,
            entregasDTO.GetMes,
            entregasDTO.GetAno,
            entregasDTO.GetMassa,
            entregasDTO.GetTempoColocacao,
            entregasDTO.GetTempoRetirada);
        }
        
    }
}