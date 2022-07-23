using AutoMapper;
using Sheduler.Mvvm.ViewModels.Products.Models;
using Sheduler.UseCases.Store.Common.Dtos;
using Sheduler.UseCases.Store.CreateProduct;
using Sheduler.UseCases.Store.UpdateProduct;

namespace Sheduler.Mvvm.ViewModels.Products
{
    /// <summary>
    /// Products mapping profile.
    /// </summary>
    public class ProductsMappingProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductsMappingProfile()
        {
            CreateMap<ProductDetailsModel, CreateProductCommand>();
            CreateMap<ProductDetailsModel, UpdateProductCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<ProductDto, ProductDetailsModel>()
                .ForMember(dest => dest.IsDirty, opt => opt.Ignore());
        }
    }
}
