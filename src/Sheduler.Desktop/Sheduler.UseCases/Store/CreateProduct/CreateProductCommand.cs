using System.ComponentModel.DataAnnotations;
using MediatR;
using Sheduler.Domain.Store.Entities;
using Sheduler.UseCases.Store.Common.Dtos;

namespace Sheduler.UseCases.Store.CreateProduct
{
    /// <summary>
    /// Create product command.
    /// </summary>
    public record CreateProductCommand : IRequest<ProductSummaryDto>
    {
        /// <inheritdoc cref="Product.Name"/>
        [Required]
        [MaxLength(256)]
        public string Name { get; init; }

        /// <inheritdoc cref="Product.Sku"/>
        [Required]
        [MaxLength(100)]
        public string Sku { get; init; }

        /// <inheritdoc cref="Product.Status"/>
        public ProductStatus Status { get; init; }
    }
}
