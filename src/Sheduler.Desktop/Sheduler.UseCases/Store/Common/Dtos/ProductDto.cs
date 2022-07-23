using Sheduler.Domain.Store.Entities;
using Sheduler.UseCases.Users.Common.Dtos;

namespace Sheduler.UseCases.Store.Common.Dtos
{
    /// <summary>
    /// Product DTO.
    /// </summary>
    public class ProductDto
    {
        /// <inheritdoc cref="Product.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="Product.Name"/>
        public string Name { get; set; }

        /// <inheritdoc cref="Product.Sku"/>
        public string Sku { get; set; }

        /// <inheritdoc cref="Product.Status"/>
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Created by user.
        /// </summary>
        public UserDto CreatedByUser { get; set; }
    }
}
