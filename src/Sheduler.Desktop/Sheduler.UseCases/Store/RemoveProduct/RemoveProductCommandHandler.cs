using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Sheduler.Infrastructure.Abstractions.Interfaces;
using Saritasa.Tools.EFCore;

namespace Sheduler.UseCases.Store.RemoveProduct
{
    /// <summary>
    /// Handler for <see cref="RemoveProductCommand" />.
    /// </summary>
    internal class RemoveProductCommandHandler : AsyncRequestHandler<RemoveProductCommand>
    {
        private readonly IAppDbContext appDbContext;
        private readonly ILogger<RemoveProductCommandHandler> logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appDbContext">Database context.</param>
        /// <param name="logger">Logger.</param>
        public RemoveProductCommandHandler(IAppDbContext appDbContext, ILogger<RemoveProductCommandHandler> logger)
        {
            this.appDbContext = appDbContext;
            this.logger = logger;
        }

        /// <inheritdoc />
        protected override async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await appDbContext.Products.GetAsync(cancellationToken, request.Id);
            appDbContext.Products.Remove(product);
            await appDbContext.SaveChangesAsync(cancellationToken);
            logger.LogInformation($"Product {product.Id} has been removed.");
        }
    }
}
