using AutoMapper;
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
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var toilet = await _context.Toilets.FindAsync(request.Toilet.Id);
            _mapper.Map(request.Toilet, toilet);
            await _context.SaveChangesAsync();
            return Unit.Value;

        }
    }

}