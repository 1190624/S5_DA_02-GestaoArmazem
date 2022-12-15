using DDDSample1.Infrastructure.Shared;
using DDDSample1.Domain.Armazens;
using DDDSample1.Domain.Common;

namespace DDDSample1.Infrastructure.Armazens {
    public class ArmazemRepository : BaseRepository<Armazem, Identificador>, IArmazemRepository {
        public ArmazemRepository(DDDSample1DbContext context) : base(context.armazens) {}
    }
}