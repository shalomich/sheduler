using AutoMapper;
using Sheduler.Domain.Store.Entities;
using Sheduler.UseCases.Store.Common.Dtos;
using Sheduler.UseCases.Store.CreateProduct;
using Sheduler.UseCases.Store.UpdateProduct;

namespace Sheduler.UseCases.Store
{
    /// <summary>
    /// Store mapping profile.
    /// </summary>
    public class StoreMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public StoreMappingProfile()
        {
            CreateMap<Product, ProductSummaryDto>();
            CreateMap<CreateProductCommand, Product>(MemberList.Source);
            CreateMap<UpdateProductCommand, Product>(MemberList.Source);
            CreateMap<Product, ProductDto>();
        }
    }
}
