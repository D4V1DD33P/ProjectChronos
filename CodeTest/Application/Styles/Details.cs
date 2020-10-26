using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;


namespace Application.Styles
{
    public class Details
    {
        public class Query : IRequest<Style> 
        { 
            public Guid Id { get; set;}
        }
        public class Handler : IRequestHandler<Query, Style>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Style> Handle(Query request, CancellationToken cancellationToken)
            {
                var style = await _context.Styles.FindAsync(request.Id); 
                return style; 
            }
        }
    }
}