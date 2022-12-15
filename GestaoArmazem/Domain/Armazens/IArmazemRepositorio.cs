using DDDSample1.Domain.Common;
using DDDSample1.Domain.Shared;

namespace DDDSample1.Domain.Armazens {
    public interface IArmazemRepository : IRepository<Armazem, Identificador> {}
}