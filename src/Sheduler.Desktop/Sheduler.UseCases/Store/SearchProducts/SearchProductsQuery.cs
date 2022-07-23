using MediatR;
using Sheduler.UseCases.Common.Pagination;
using Sheduler.UseCases.Store.Common.Dtos;
using Saritasa.Tools.Common.Pagination;

namespace Sheduler.UseCases.Store.SearchProducts
{
    /// <summary>
    /// Search products query.
    /// </summary>
    public class SearchProductsQuery : PageQueryFilter, IRequest<PagedList<ProductSummaryDto>>
    {
        /// <summary>
        /// Name search term.
        /// </summary>
        public string NameTerm { get; init; }
    }
}
