using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Sheduler.Mvvm.ServiceAbstractions.Navigation;
using Sheduler.Mvvm.Utils;
using Sheduler.Mvvm.ViewModels.Products.Models;
using Sheduler.UseCases.Store.CreateProduct;
using Sheduler.UseCases.Store.GetProductById;
using Sheduler.UseCases.Store.UpdateProduct;

namespace Sheduler.Mvvm.ViewModels.Products
{
    /// <summary>
    /// Product details view model.
    /// </summary>
    public class ProductDetailsViewModel : EditableDialogViewModel<ProductDetailsModel>
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly int? id;

        /// <summary>
        /// Indicates whether the current product is a new or not.
        /// </summary>
        public bool IsNew => id == null;

        /// <inheritdoc/>
        public override ProductDetailsModel Model { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the `Editable Dialog` view model.
        /// </summary>
        /// <param name="dialogService">Dialog service.</param>
        /// <param name="mediator">Mediator.</param>
        /// <param name="mapper">Auto mapper.</param>
        /// <param name="id">Product Id (optional).</param>
        public ProductDetailsViewModel(
            IDialogService dialogService,
            IMediator mediator,
            IMapper mapper,
            int? id = null) : base(dialogService)
        {
            this.id = id;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public override async Task LoadAsync()
        {
            await base.LoadAsync();

            Model = new();

            if (!IsNew)
            {
                var query = new GetProductByIdQuery()
                {
                    Id = id.Value
                };
                var product = await mediator.Send(query);
                mapper.Map(product, Model);
            }

            Model.IsDirty = false;
        }

        /// <inheritdoc/>
        protected override async Task OnSave()
        {
            if (IsNew)
            {
                var command = mapper.Map<CreateProductCommand>(Model);
                await mediator.Send(command);
            }
            else
            {
                var command = mapper.Map<UpdateProductCommand>(Model);
                command.Id = id.Value;
                await mediator.Send(command);
            }
        }
    }
}
