using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Saritasa.Tools.EFCore;
using Sheduler.Domain.Users.Entities;
using Sheduler.Infrastructure.Abstractions.Interfaces;

namespace Sheduler.UseCases.Users.GetUserById
{
    /// <summary>
    /// Handler for <see cref="GetUserByIdQuery" />.
    /// </summary>
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDetailsDto>
    {
        private readonly IAppDbContext dbContext;
        private readonly IMapper mapper;

        internal class GetUserByIdQueryMappingProfile : Profile
        {
            public GetUserByIdQueryMappingProfile()
            {
                CreateMap<User, UserDetailsDto>();
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dbContext">Database context.</param>
        /// <param name="mapper">Automapper instance.</param>
        public GetUserByIdQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public async Task<UserDetailsDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await dbContext.Users.GetAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);
            return mapper.Map<UserDetailsDto>(user);
        }
    }
}
