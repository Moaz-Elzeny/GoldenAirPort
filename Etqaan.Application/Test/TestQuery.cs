namespace Etqaan.Application.Test
{
    public class TestQuery : IRequest<object>
    {
        public class TestQueryHandler : IRequestHandler<TestQuery, object>
        {
            private readonly IApplicationDbContext _context;

            public TestQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<object> Handle(TestQuery request, CancellationToken cancellationToken)
            {
                var x = 10;
                return x;

            }



        }
    }
}
