using eTickets.Data.Base;
using eTickets.Models;

namespace eTickets.Data.Services.Producers
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
        }
    }
}
