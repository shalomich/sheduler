using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Mvvm.ViewModels.Products;

namespace Sheduler.Desktop.Views.Products
{
    /// <summary>
    /// Interaction logic for ProductDetailsDialog.xaml.
    /// </summary>
    [UsesViewModel(typeof(ProductDetailsViewModel))]
    public partial class ProductDetailsDialog : BaseDialog
    {
        /// <summary>
        /// Initializes a new instance of the `Product Details` dialog.
        /// </summary>
        public ProductDetailsDialog()
        {
            InitializeComponent();
        }
    }
}
