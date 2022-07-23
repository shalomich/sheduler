using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Mvvm.ViewModels.Common;

namespace Sheduler.Desktop.Views.Common
{
    /// <summary>
    /// Interaction logic for ConfirmationDialog.xaml.
    /// </summary>
    [UsesViewModel(typeof(ConfirmationViewModel))]
    public partial class ConfirmationDialog : BaseDialog
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ConfirmationDialog()
        {
            InitializeComponent();
        }
    }
}
