using Domain;
using MediatR;
using Persistance;

namespace Application.Toilets;

public class Create
{
    public class Command : IRequest
    {
        public Toilet Toilet { get; set; }
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
           _context.Toilets.Add(request.Toilet);
           await _context.SaveChangesAsync();
           return Unit.Value;
        }
    }
}