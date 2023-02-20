using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Toilets;

public class Use
{
    public class Command : IRequest
    {
        public Toilet Toilet { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());
            var toilet = await _context.Toilets.FindAsync(request.Toilet.Id);
            var pooper = new Pooper
            {
                AppUser = user,
                AppUserId = user.Id,
                Toilet = toilet,
                ToiletId = toilet.Id
            };
            toilet.Poopers.Add(pooper);
            _mapper.Map(request.Toilet, toilet);

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}