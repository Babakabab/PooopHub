using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Toilets;

public class List
{
    public class Query : IRequest<List<ToiletDto>>
    {

    }
    public class Handler:IRequestHandler<Query,List<ToiletDto>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ToiletDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var toilets = await _context.Toilets
                .Include(o=>o.Poopers)
                .ThenInclude(u=>u.AppUser)
                .Include(o => o.Creator)
                .Include(o=>o.ToiletModifiers)
                .ToListAsync(cancellationToken);
            var toiletsToReturn = _mapper.Map<List<ToiletDto>>(toilets);
            //ThenInclude later on when we also wanna load the reviews
            return toiletsToReturn;
        }
    }
}