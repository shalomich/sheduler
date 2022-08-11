using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using RestSharp;
using RestSharp.Authenticators;
using Sheduler.Infrastructure.Abstractions.Interfaces;

namespace Sheduler.UseCases.Users.GetUsers
{
    internal class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserPreviewModel>>
    {
        private readonly RestClient restClient;
        private readonly IAuthenticationTokenStorage authenticationTokenStorage;
        private readonly IMapper mapper;

        public GetUsersQueryHandler(
            RestClient restClient,
            IAuthenticationTokenStorage authenticationTokenStorage,
            IMapper mapper)
        {
            this.restClient = restClient;
            this.authenticationTokenStorage = authenticationTokenStorage;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserPreviewModel>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var restRequest = new RestRequest(ApiPaths.UsersPath);

            restClient.Authenticator = new JwtAuthenticator(authenticationTokenStorage.AccessToken);

            var previews = await restClient.GetAsync<IEnumerable<UserPreviewModel>>(restRequest, cancellationToken);

            return previews.Select(preview => mapper.Map<UserPreviewModel>(preview));
        }
    }
}
