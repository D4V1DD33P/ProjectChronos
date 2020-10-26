using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Styles
{
    public class Edit
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
                var style = await _context.Styles.FindAsync(request.Id);
                if (style == null)
                {
                    throw new Exception("Could not find style");
                }

                style.Number = request.Number ?? style.Number;
                style.Name = request.Name ?? style.Name;
                style.Options = request.Options ?? style.Options;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}