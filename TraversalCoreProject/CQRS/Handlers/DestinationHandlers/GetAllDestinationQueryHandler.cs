using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                dayNight = x.DayNight,
                price = x.Price,

            }).AsNoTracking().ToList();
            return values;
            //sorgulanan verilerin takip edilmesini (tracking) devre dışı bırakır.


        }
    }
}
