using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Toilets;

public class List
{
    public class Query : IRequest<List<Toilet>>
    {

    }
    public class Handler:IRequestHandler<Query,List<Toilet>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Toilet>> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Toilets.ToListAsync();
        }
    }
}