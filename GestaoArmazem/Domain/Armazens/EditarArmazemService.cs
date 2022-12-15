using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Common;
using DDDSample1.Domain.Armazens.DTO;
using System;

namespace DDDSample1.Domain.Armazens
{
    public class EditarArmazemService
    {
        private readonly IArmazemRepository _repo;

        private readonly IUnitOfWork gestorPersist;

        public EditarArmazemService(IUnitOfWork gestorPersist, IArmazemRepository repo)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
        }

        public async Task<ArmazemDTO> EditarArmazémAsync(ArmazemDTO novoArmazemDTO)
        {
            var armazem = await this._repo.GetByIdAsync(new Identificador(novoArmazemDTO.GetIdentificador));
            if(armazem == null)
            return null;

            // change all fields
            
            armazem.changeDesignacao(novoArmazemDTO.GetDesignacao);
            armazem.changeEndereco(novoArmazemDTO.codigoPostal, novoArmazemDTO.GetNumeroPorta, novoArmazemDTO.GetNomeRua,
                novoArmazemDTO.GetLocalidade, novoArmazemDTO.GetPais);
            armazem.changeMunicipio(novoArmazemDTO.GetMunicipio);
            armazem.changeCoordenadas(novoArmazemDTO.latitude, novoArmazemDTO.longitude);

            await this.gestorPersist.CommitAsync();

            return ArmazemMapper.toDTO(armazem);
        }
    }
}