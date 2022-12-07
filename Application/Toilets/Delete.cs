using MediatR;
using Persistance;

namespace Application.Toilets;

public class Delete
{
    public class Command : IRequest
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var toilet = await _context.Toilets.FindAsync(request.Id);
            _context.Toilets.Remove(toilet);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}