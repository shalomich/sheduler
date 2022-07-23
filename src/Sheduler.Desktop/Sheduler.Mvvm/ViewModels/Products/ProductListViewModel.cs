using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.Toolkit.Mvvm.Input;
using Sheduler.Infrastructure.Common.Configuration;
using Sheduler.Infrastructure.Common.Reactive;
using Sheduler.Mvvm.ServiceAbstractions;
using Sheduler.Mvvm.ServiceAbstractions.Navigation;
using Sheduler.UseCases.Store.Common.Dtos;
using Sheduler.UseCases.Store.RemoveProduct;
using Sheduler.UseCases.Store.SearchProducts;

namespace Sheduler.Mvvm.ViewModels.Products
{
    /// <summary>
    /// Displays a list of products.
    /// </summary>
    public class ProductListViewModel : BaseViewModel
    {
        private readonly IMediator mediator;
        private readonly IUiContext uiContext;
        private readonly IDialogService dialogService;
        private readonly ReplaySubject<Unit> refreshProductsSubject = new(1);
        private readonly ReplaySubject<string> searchTextSubject = new(1);

        /// <summary>
        /// Current products.
        /// </summary>
        public ObservableCollection<ProductSummaryDto> Products { get; } = new();

        /// <summary>
        /// Remove product command.
        /// </summary>
        public AsyncRelayCommand<ProductSummaryDto> RemoveProductCommand { get; }

        /// <summary>
        /// Edit product command.
        /// </summary>
        public AsyncRelayCommand<ProductSummaryDto> EditProductCommand { get; }

        /// <summary>
        /// Create product command.
        /// </summary>
        public AsyncRelayCommand CreateProductCommand { get; }

        /// <summary>
        /// Keyword text.
        /// </summary>
        public string KeywordText { get; set; }

        /// <summary>
        /// Initializes a new `Product List` view model.
        /// </summary>
        /// <param name="mediator">Mediator.</param>
        /// <param name="uiConfiguration">UI configuration.</param>
        /// <param name="uiContext">UI context.</param>
        /// <param name="dialogService">Dialog service.</param>
        public ProductListViewModel(
            IMediator mediator,
            IOptions<UIConfiguration> uiConfiguration,
            IUiContext uiContext,
            IDialogService dialogService)
        {
            this.mediator = mediator;
            this.uiContext = uiContext;
            this.dialogService = dialogService;

            RemoveProductCommand = new AsyncRelayCommand<ProductSummaryDto>(RemoveProductCommandExecute);
            EditProductCommand = new AsyncRelayCommand<ProductSummaryDto>(EditProductCommandExecute);
            CreateProductCommand = new AsyncRelayCommand(CreateProductCommandExecute);

            PropertyChanged += ProductListViewModelPropertyChanged;

            InitializeTableSearch(uiConfiguration.Value);
        }

        private async Task CreateProductCommandExecute()
        {
            var hasProductCreated = await dialogService.OpenAsync<ProductDetailsViewModel, bool>();
            if (hasProductCreated)
            {
                ReloadProduts();
            }
        }

        private async Task EditProductCommandExecute(ProductSummaryDto product)
        {
            var hasProductChanged = await dialogService.OpenAsync<ProductDetailsViewModel, bool>(product.Id);
            if (hasProductChanged)
            {
                ReloadProduts();
            }
        }

        /// <inheritdoc/>
        public override async Task LoadAsync()
        {
            await base.LoadAsync();
            ReloadProduts();
        }

        private void InitializeTableSearch(UIConfiguration uiConfiguration)
        {
            var searchTextObservable = searchTextSubject
                .Do(_ =>
                {
                    // Mark as busy even before we start searching to not make it look like the app is lagging
                    IsBusy = true;
                })
                .Debounce(uiConfiguration.SearchDelay)
                .StartWith(KeywordText);

            refreshProductsSubject.CombineLatest(
                searchTextObservable,
                (_, searchTerm) => searchTerm)
                .ThrottleUI()
                .Select(searchTerm =>
                {
                    IsBusy = true;
                    var query = new SearchProductsQuery()
                    {
                        NameTerm = searchTerm
                    };
                    return Observable.FromAsync(cancellationToken => mediator.Send(query, cancellationToken));
                })
                .Switch()
                .ObserveOn(uiContext.UiSynchronizationContext)
                .TakeUntil(Unload)
                .Subscribe(productsData =>
                {
                    Products.Clear();

                    foreach (var product in productsData)
                    {
                        Products.Add(product);
                    }
                    IsBusy = false;
                });
        }

        private void ProductListViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(KeywordText))
            {
                searchTextSubject.OnNext(KeywordText);
            }
        }

        private void ReloadProduts()
        {
            refreshProductsSubject.OnNext(Unit.Value);
        }

        private async Task RemoveProductCommandExecute(ProductSummaryDto product)
        {
            var result = await dialogService.GetDialogBuilder("Delete")
                .AsAlert()
                .WithMessage($"Are you sure you want to delete the product #{product.Id}?")
                .WithOkButton("Delete")
                .Show();

            if (!result)
            {
                return;
            }

            await mediator.Send(new RemoveProductCommand()
            {
                Id = product.Id
            });

            Products.Remove(product);
        }
    }
}
