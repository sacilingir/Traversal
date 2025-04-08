using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            var values = _context.Destinations.Find(command.DestinationID);

            if (values == null)
            {
                throw new InvalidOperationException($"Destination with ID {command.DestinationID} not found.");
            }

            values.City = command.City;
            values.DayNight = command.DayNight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
