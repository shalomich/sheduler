using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;
using Sheduler.Domain.Store.Entities;
using Sheduler.UseCases.Store.Common.Dtos;

namespace Sheduler.UseCases.Store.UpdateProduct
{
    /// <summary>
    /// Update product command.
    /// </summary>
    public record UpdateProductCommand : IRequest<ProductSummaryDto>
    {
        /// <inheritdoc cref="Product.Id"/>
        [JsonIgnore]
        public int Id { get; set; }

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
