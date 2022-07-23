using Sheduler.UseCases.Users.Common.Dtos;
using Sheduler.Domain.Store.Entities;

namespace Sheduler.UseCases.Store.Common.Dtos
{
    /// <summary>
    /// Product summary DTO.
    /// </summary>
    public class ProductSummaryDto
    {
        /// <inheritdoc cref="Product.Id"/>
        public int Id { get; set; }

        /// <inheritdoc cref="Product.Name"/>
        public string Name { get; set; }

        /// <summary>
        /// Created by user.
        /// </summary>
        public UserDto CreatedByUser { get; set; }
    }
}
