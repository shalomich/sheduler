using MediatR;
using Sheduler.UseCases.Store.Common.Dtos;

namespace Sheduler.UseCases.Store.GetProductById
{
    /// <summary>
    /// Get product by id query.
    /// </summary>
    public record GetProductByIdQuery : IRequest<ProductDto>
    {
        /// <summary>
        /// Product identifier.
        /// </summary>
        public int Id { get; init; }
    }
}
