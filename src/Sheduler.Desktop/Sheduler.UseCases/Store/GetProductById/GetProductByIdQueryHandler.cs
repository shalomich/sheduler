using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Sheduler.UseCases.Store.Common.Dtos;
using Saritasa.Tools.EFCore;

namespace Sheduler.UseCases.Store.GetProductById
{
    /// <summary>
    /// Handler for <see cref="GetProductByIdQuery" />.
    /// </summary>
    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appDbContext">Database context.</param>
        /// <param name="mapper">Automapper instance.</param>
        public GetProductByIdQueryHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await appDbContext.Products.Include(p => p.CreatedByUser)
                .GetAsync(p => p.Id == request.Id, cancellationToken);
            return mapper.Map<ProductDto>(product);
        }
    }
}
