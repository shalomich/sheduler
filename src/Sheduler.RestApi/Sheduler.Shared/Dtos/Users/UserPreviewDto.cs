using Sheduler.Shared.Enums;

namespace Sheduler.Shared.Dtos.Users
{
    public class UserPreviewDto
    {
        public string Id { get; init; }

        public string Name { get; init; }

        public UserRole Role { get; init; }

        public string Post { get; init; }
    }
}
