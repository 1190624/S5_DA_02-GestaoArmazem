using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Entregas.DTO;
using System;
using DDDSample1.Domain.Armazens;

namespace DDDSample1.Domain.Entregas
{
    public class EntregaService
    {
        private readonly IEntregasRepository _repo;
        private readonly IArmazemRepository armazemRepo;

        private readonly IUnitOfWork gestorPersist;

        //private readonly IArmazémRepository armazémRepo;

        public EntregaService(IUnitOfWork gestorPersist, IEntregasRepository repo, IArmazemRepository armazemRepository)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
            this.armazemRepo = armazemRepository;
        }

        public async Task<EntregasDTO> editarEntregaAsync(EntregasDTO novaEntregaDTO)
        {
            var entrega = await this._repo.GetByIdAsync(new Identificador(novaEntregaDTO.GetIdentificador));
            if(entrega == null)
            return null;

            var armazem = await this.armazemRepo.GetByIdAsync(new Identificador(novaEntregaDTO.GetArmazemID));
            if(armazem == null)
            return null; 
            

            entrega.changeArmazem(novaEntregaDTO.armazemID);
            entrega.changeDataEntrega(novaEntregaDTO.GetDia, novaEntregaDTO.GetMes, novaEntregaDTO.GetAno);
            entrega.changeMassa(novaEntregaDTO.GetMassa);
            entrega.changeTempoColocacao(novaEntregaDTO.GetTempoColocacao);
            entrega.changeTempoRetirada(novaEntregaDTO.GetTempoRetirada);

            await this.gestorPersist.CommitAsync();

            return EntregasMapper.toDTO(entrega);
        }


        public async Task<EntregasDTO> RegistarEntrega(EntregasDTO entregasDTO) {
            Entrega entrega = EntregasMapper.toEntrega(entregasDTO);

            var armazem = await this.armazemRepo.GetByIdAsync(new Identificador(entregasDTO.GetArmazemID));
            if(armazem == null)
                return null;

            await _repo.AddAsync(entrega);
            await gestorPersist.CommitAsync();
            

            return EntregasMapper.toDTO(entrega);
        }


/*
            public async Task<EntregasDTO> AddAsync(EntregasDTO dto)
    {
        Entrega entrega = EntregasMapper.toEntrega(dto);
        //var delivery = new Delivery(dto.DeliveryIdentifier,dto.Day, dto.Month, dto.Year, dto.Mass, dto.StoreId,
          // dto.PlacingTime, dto.WithdrawalTime);

        await _repo.AddAsync(entrega);

        await gestorPersist.CommitAsync();

        return  EntregasMapper.toDTO(entrega);
    }
    */

        public async Task<EntregasDTO> GetByIdAsync(String Id) {
            Identificador identificador = new Identificador(Id);
            var entrega = await _repo.GetByIdAsync(identificador);

            if (entrega == null)
                return null;

            return EntregasMapper.toDTO(entrega);
        }
        
        public async Task<List<EntregasDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            List<EntregasDTO> listaEntregasDTO = list.ConvertAll<EntregasDTO>(entrega => EntregasMapper.toDTO(entrega));

            return listaEntregasDTO;
        }



    }
}