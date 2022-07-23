using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Sheduler.Domain.Store.Entities;
using Sheduler.DomainServices.Store;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Sheduler.UseCases.Store.Common.Dtos;
using Sheduler.UseCases.Store.Common.Exceptions;
using Saritasa.Tools.EFCore;

namespace Sheduler.UseCases.Store.CreateProduct
{
    /// <summary>
    /// Handler for <see cref="CreateProductCommand" />.
    /// </summary>
    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductSummaryDto>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly ILogger<CreateProductCommandHandler> logger;
        private readonly ICurrentUserAccessor loggedUserAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appDbContext">Database context.</param>
        /// <param name="mapper">Automapper instance.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="loggedUserAccessor">Logger user accessor.</param>
        public CreateProductCommandHandler(
            IAppDbContext appDbContext,
            IMapper mapper,
            ILogger<CreateProductCommandHandler> logger,
            ICurrentUserAccessor loggedUserAccessor)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.logger = logger;
            this.loggedUserAccessor = loggedUserAccessor;
        }

        /// <inheritdoc />
        public async Task<ProductSummaryDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validation.
            if (!new ProductSkuValidator().IsValid(request.Sku))
            {
                throw new InvalidSkuException();
            }

            // Creation.
            var currentUserId = loggedUserAccessor.GetCurrentUserId();

            var product = mapper.Map<Product>(request);
            product.CreatedByUser = await appDbContext.Users.GetAsync(u => u.Id == currentUserId, cancellationToken);
            product.Clean();

            appDbContext.Products.Add(product);
            await appDbContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation($"The product with id {product.Id} has been created.");

            return mapper.Map<ProductSummaryDto>(product);
        }
    }
}
