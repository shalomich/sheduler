using Sheduler.Desktop.Infrastructure.Navigation;
using Sheduler.Mvvm.ViewModels.Common;

namespace Sheduler.Desktop.Views.Common
{
    /// <summary>
    /// Save dialog view.
    /// </summary>
    [UsesViewModel(typeof(SaveViewModel))]
    public partial class SaveDialog : BaseDialog
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SaveDialog()
        {
            InitializeComponent();
        }
    }
}
