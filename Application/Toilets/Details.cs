using Domain;
using MediatR;
using Persistance;

namespace Application.Toilets;

public class Details
{
    public class Query : IRequest<Toilet>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Toilet>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Toilet> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Toilets.FindAsync(request.Id);
        }
    }
}