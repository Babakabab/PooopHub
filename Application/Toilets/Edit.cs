using Domain;
using MediatR;
using Persistance;

namespace Application.Toilets;

public class Edit
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
            var toilet = await _context.Toilets.FindAsync(request.Toilet.Id);
            toilet.Title = request.Toilet.Title ?? toilet.Title;
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }

}