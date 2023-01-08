using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazens.DTO;
using DDDSample1.Domain.Common;

namespace DDDSample1.Domain.Armazens {
    public class RegistarArmazemService {
        private readonly IArmazemRepository armazemRepo;
        private readonly IUnitOfWork gestorPersist;

        public RegistarArmazemService(IArmazemRepository armazemRepo, IUnitOfWork gestorPersist) {
            this.armazemRepo = armazemRepo;
            this.gestorPersist = gestorPersist;
        }
 
        public async Task<ArmazemDTO> RegistarArmazem(ArmazemDTO armazemDTO) {
            Armazem armazem = ArmazemMapper.toArmazem(armazemDTO);

            await armazemRepo.AddAsync(armazem);
            await gestorPersist.CommitAsync();

            return ArmazemMapper.toDTO(armazem);
        }

        public async Task<List<ArmazemDTO>> GetAllAsync() {
            var list = await armazemRepo.GetAllAsync();

            List<ArmazemDTO> armazemDTOList = list.ConvertAll<ArmazemDTO>(armazem => ArmazemMapper.toDTO(armazem));

            return armazemDTOList;
        }

        public async Task<ArmazemDTO> GetByIdAsync(String Id) {
            Identificador identificador = new Identificador(Id);
            var armazem = await armazemRepo.GetByIdAsync(identificador);

            if (armazem == null)
                return null;

            return ArmazemMapper.toDTO(armazem);
        }

        public async Task<ArmazemDTO> DeleteAsync(String Id)
        {
            Identificador identificador = new Identificador(Id);
            var armazém = await armazemRepo.GetByIdAsync(identificador); 

            if (armazém == null)
                return null;   

            this.armazemRepo.Remove(armazém);
            await this.gestorPersist.CommitAsync();

            return ArmazemMapper.toDTO(armazém);
        }

        public async Task<ArmazemDTO> AtivarDesativarArmazem(String Id)
        {
            Identificador identificador = new Identificador(Id);
            var armazém = await armazemRepo.GetByIdAsync(identificador); 

            if (armazém == null)
                return null;   

            armazém.changeEstado();
            await this.gestorPersist.CommitAsync();

            return ArmazemMapper.toDTO(armazém);
        }
    }
}