using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Styles
{
    public class List
    {
        public class Query : IRequest<List<Style>> { }
        public class Handler : IRequestHandler<Query, List<Style>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Style>> Handle(Query request, CancellationToken cancellationToken)
            {
                var styles = await _context.Styles.ToListAsync(); 
                return styles; 
            }
        }
    }
}