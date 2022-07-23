using System;
using System.ComponentModel.DataAnnotations;
using Saritasa.RedMan.Domain.Users.Entities;

namespace Saritasa.RedMan.Domain.Store.Entities
{
    /// <summary>
    /// Product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product identifier.
        /// </summary>
        [Key]
        public int Id { get; private set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// SKU.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Sku { get; set; }

        /// <summary>
        /// Product status.
        /// </summary>
        public ProductStatus Status { get; set; } = ProductStatus.InStore;

        #region Metadata

        /// <summary>
        /// Created at.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Create by user identifier.
        /// </summary>
        public int CreatedByUserId { get; set; }

        /// <summary>
        /// Created by user.
        /// </summary>
        public User CreatedByUser { get; set; }

        /// <summary>
        /// Updated at.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Updated by user identifier.
        /// </summary>
        public int? UpdatedByUserId { get; set; }

        /// <summary>
        /// Updated by user.
        /// </summary>
        public User UpdatedByUser { get; set; }

        #endregion

        /// <summary>
        /// Clean entity state.
        /// </summary>
        public void Clean()
        {
            Name = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(Name).Trim();
            Sku = Saritasa.Tools.Common.Utils.StringUtils.NullSafe(Sku).Trim();
        }
    }
}
