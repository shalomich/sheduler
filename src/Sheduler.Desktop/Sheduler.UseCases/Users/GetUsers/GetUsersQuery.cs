using System.Collections.Generic;
using MediatR;

namespace Sheduler.UseCases.Users.GetUsers
{
    public record GetUsersQuery() : IRequest<IEnumerable<UserPreviewModel>>;
}
