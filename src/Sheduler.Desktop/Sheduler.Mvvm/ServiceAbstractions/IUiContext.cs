using System.Threading;
using Sheduler.Mvvm.Utils;

namespace Sheduler.Mvvm.ServiceAbstractions
{
    /// <summary>
    /// Service for working with UI context.
    /// </summary>
    public interface IUiContext
    {
        /// <summary>
        /// Switch to the UI thread.
        /// </summary>
        IAwaitable SwitchToUi();

        /// <summary>
        /// Synchronization context of the UI thread.
        /// </summary>
        SynchronizationContext UiSynchronizationContext { get; }
    }
}
