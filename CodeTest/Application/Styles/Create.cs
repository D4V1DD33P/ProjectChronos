using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Styles
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Number { get; set; }
            public string Name { get; set; }
            public StyleOption[] Options { get; set; }
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
                var style = new Style
                {
                    Id = request.Id,
                    Number = request.Number,
                    Name = request.Name,
                    Options = request.Options,

                };

                _context.Styles.Add(style);
                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}