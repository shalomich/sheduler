using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sodium.XRayImage.Mvvm.Utils.Commands;

public class AsyncCommand : AsyncCommand<object>
{
    public AsyncCommand(
        Func<Task> execute,
        Func<bool> canExecute = null,
        Action<Exception> onException = null,
        bool continueOnCapturedContext = true) :
        base(execute: async _ => await execute(),
            canExecute: _ => canExecute?.Invoke() ?? true,
            onException: onException,
            continueOnCapturedContext: continueOnCapturedContext)
    {
    }
}

public class AsyncCommand<T> : ICommand, IRelayCommand<T>
{
    private readonly Func<T, Task> execute;
    private readonly Func<T, bool> canExecute;
    private readonly Action<Exception> onException;
    private readonly bool continueOnCapturedContext;

    private bool isExecuting;

    public event EventHandler CanExecuteChanged;

    public AsyncCommand(
        Func<T, Task> execute,
        Func<T, bool> canExecute = null,
        Action<Exception> onException = null,
        bool continueOnCapturedContext = true)
    {
        this.execute = execute;
        this.canExecute = canExecute;
        this.onException = onException;
        this.continueOnCapturedContext = continueOnCapturedContext;
    }

    /// <inheritdoc/>
    public async Task ExecuteAsync(T parameter)
    {
        if (CanExecute(parameter))
        {
            try
            {
                isExecuting = true;
                await execute(parameter);
            }
            finally
            {
                isExecuting = false;
            }
        }

        NotifyCanExecuteChanged();
    }

    /// <summary>
    /// Notifies that the <see cref="ICommand.CanExecute"/> has changed.
    /// </summary>
    public void NotifyCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <inheritdoc/>
    public bool CanExecute(T parameter)
    {
        if (isExecuting)
        {
            return false;
        }

        return canExecute?.Invoke(parameter) ?? true;
    }

    #region IRelayCommand

    /// <inheritdoc/>
    public bool CanExecute(object parameter)
    {
        if (default(T) != null && parameter == null)
        {
            return false;
        }

        return CanExecute((T)parameter);
    }

    /// <inheritdoc/>
    public void Execute(object parameter)
    {
        Execute((T)parameter);
    }

    /// <inheritdoc/>
    public void Execute(T parameter)
    {
        ExecuteAsync(parameter).Wait();
    }

    #endregion
}
