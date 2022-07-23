using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using Sheduler.Domain.Store.Entities;
using Sheduler.DomainServices.Store;
using Sheduler.Mvvm.Utils;

namespace Sheduler.Mvvm.ViewModels.Products.Models
{
    /// <summary>
    /// Product details models.
    /// </summary>
    public class ProductDetailsModel : EditableModel
    {
        /// <inheritdoc cref="Product.Name"/>
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        /// <inheritdoc cref="Product.Sku"/>
        [Required]
        [StringLength(100)]
        [CustomValidation(typeof(ProductDetailsModel), nameof(ValidateSkuCode))]
        public string Sku { get; set; }

        /// <inheritdoc cref="Product.Status"/>
        public ProductStatus Status { get; set; }

        /// <summary>
        /// Validate SKU code.
        /// </summary>
        /// <param name="sku">SKU code.</param>
        /// <param name="context">Validation context.</param>
        /// <returns>Validation result.</returns>
        public static ValidationResult ValidateSkuCode(string sku, ValidationContext context)
        {
            var validator = context.GetRequiredService<ProductSkuValidator>();
            if (!validator.IsValid(sku))
            {
                return new ValidationResult("Invalid SKU number. It must start with SK characters.", new[] { nameof(Sku) });
            }

            return ValidationResult.Success;
        }
    }
}
