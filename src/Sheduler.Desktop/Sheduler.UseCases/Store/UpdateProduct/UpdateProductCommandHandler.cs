using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sheduler.DomainServices.Store;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Sheduler.UseCases.Store.Common.Dtos;
using Sheduler.UseCases.Store.Common.Exceptions;
using Saritasa.Tools.EFCore;

namespace Sheduler.UseCases.Store.UpdateProduct
{
    /// <summary>
    /// Handler for <see cref="UpdateProductCommand" />.
    /// </summary>
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductSummaryDto>
    {
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;
        private readonly ILogger<UpdateProductCommand> logger;
        private readonly ICurrentUserAccessor loggedUserAccessor;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appDbContext">Database context.</param>
        /// <param name="mapper">Automapper instance.</param>
        /// <param name="logger">Logger.</param>
        /// <param name="loggedUserAccessor">Logger user accessor.</param>
        public UpdateProductCommandHandler(
            IAppDbContext appDbContext,
            IMapper mapper,
            ILogger<UpdateProductCommand> logger,
            ICurrentUserAccessor loggedUserAccessor)
        {
            this.appDbContext = appDbContext;
            this.mapper = mapper;
            this.logger = logger;
            this.loggedUserAccessor = loggedUserAccessor;
        }

        /// <inheritdoc />
        public async Task<ProductSummaryDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // Validation.
            if (!new ProductSkuValidator().IsValid(request.Sku))
            {
                throw new InvalidSkuException();
            }

            var product = await appDbContext.Products.Include(p => p.CreatedByUser)
                .GetAsync(p => p.Id == request.Id, cancellationToken);

            mapper.Map(request, product);
            product.UpdatedByUserId = loggedUserAccessor.GetCurrentUserId();
            product.UpdatedAt = DateTime.UtcNow;
            product.Clean();

            await appDbContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation($"The product with id {product.Id} has been updated.");

            return mapper.Map<ProductSummaryDto>(product);
        }
    }
}
