using System.Threading.Tasks;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Armazens.DTO;

namespace DDDSample1.Domain.Armazens
{
    public class ListarArmazensService
    {
        private readonly IArmazemRepository _repo;

        private readonly IUnitOfWork gestorPersist;

        public ListarArmazensService(IUnitOfWork gestorPersist, IArmazemRepository repo)
        {
            this.gestorPersist = gestorPersist;
            this._repo = repo;
        }
        public async Task<List<ArmazemDTO>> GetAllAsync()
        {
            var list = await this._repo.GetAllAsync();

            foreach(Armazem armazem in list){
                //TODO
            }

            List<ArmazemDTO> listaArmazemDTO = list.ConvertAll<ArmazemDTO>(armazem => ArmazemMapper.toDTO(armazem));

            return listaArmazemDTO;
        }
    }
}