﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Sheduler.UseCases.Common.Behaviors
{
    /// <summary>
    /// Cancellation handling behavior.
    /// Sometimes SQL provider throws <see cref="Microsoft.Data.SqlClient.SqlException"/> exception instead of <see cref="OperationCanceledException"/>.
    /// This behavior wraps such exceptions.
    /// </summary>
    public class CancellationHandlingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        /// <inheritdoc/>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Microsoft.Data.SqlClient.SqlException e)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException(e.Message, e, cancellationToken);
                }
                throw;
            }
        }
    }
}
