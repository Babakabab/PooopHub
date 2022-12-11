using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }
        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var creator = await _context.Users.FirstOrDefaultAsync(x=>x.UserName== _userAccessor.GetUsername());
            request.Toilet.Creator = creator;
            request.Toilet.CreatorUserId = creator.Id;
           _context.Toilets.Add(request.Toilet);
           await _context.SaveChangesAsync();
           return Unit.Value;
        }
    }
}