using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommantHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommantHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
