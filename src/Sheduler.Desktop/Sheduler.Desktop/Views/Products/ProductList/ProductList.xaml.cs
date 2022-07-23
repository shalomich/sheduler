using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Mvvm.ViewModels.Products;

namespace Sheduler.Desktop.Views.Products.ProductList
{
    /// <summary>
    /// Interaction logic for ProductList.xaml.
    /// </summary>
    [UsesViewModel(typeof(ProductListViewModel))]
    public partial class ProductList : NavigationPage
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ProductList()
        {
            InitializeComponent();
        }
    }
}
